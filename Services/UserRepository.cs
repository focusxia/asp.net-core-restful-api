using AutoMapper;
using DotnetRestFulWebApi.Entities;
using DotnetRestFulWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetRestFulWebApi.Helper;

namespace DotnetRestFulWebApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly FutrueContext _context;
        public UserRepository(IMapper mapper, FutrueContext context)
        {
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _context = context ?? throw new ArgumentException(nameof(mapper));
        }

        public async Task<UserModelSelect> Get(Guid userId)
        {

            var user = await _context.User.Where(x => x.Id == userId)
                .Select(x => new UserModelSelect
                {
                    Name = x.Name,
                    Password = x.Password,  
                    Roles = _mapper.Map<ICollection<RoleModelSelect>>(x.UserRoleRelationship.Select(x => new RoleModelSelect
                    {
                        Name = x.Role.Name,
                        Permissions = _mapper.Map<ICollection<PermissionModelSelect>>(x.Role.RolePermissionRelationship.Select(x => x.Permission))
                    }))
                })
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<bool> Insert(UserModelAdd user)
        {
            var userEntity = _mapper.Map<User>(user);

            if (user.RoleIds.Count() > 0)
            {
                user.RoleIds.ForEach(x =>
                {
                    userEntity.UserRoleRelationship.Add(new UserRoleRelationship
                    {
                        RoleId = x
                    });
                });
            }

            _context.User.Add(userEntity);

            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> Update(UserModelUpdate user)
        {
            var userEntity = await _context.User.Include(x => x.UserRoleRelationship).FirstOrDefaultAsync(x => x.Id == user.Id);
            if (userEntity != null)
            {
                _context.TryUpdateManyToMany(userEntity.UserRoleRelationship,
                    user.RoleIds.Select(x => new UserRoleRelationship
                    {
                        UserId = userEntity.Id,
                        RoleId = x
                    }), x => x.RoleId);
            }

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Delete(Guid userId)
        {
            var userEntity = await _context.User.Include(x => x.UserRoleRelationship).FirstOrDefaultAsync(x => x.Id == userId);
            _context.User.Remove(userEntity);

            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
