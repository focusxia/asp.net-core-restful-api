using AutoMapper;
using DotnetRestFulWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotnetRestFulWebApi.Entities;
using DotnetRestFulWebApi.Helper;

namespace DotnetRestFulWebApi.Services
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IMapper _mapper;
        private readonly FutrueContext _context;
        public RoleRepository(IMapper mapper, FutrueContext context)
        {
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _context = context ?? throw new ArgumentException(nameof(mapper));
        }

        public async Task<RoleModelSelect> Get(Guid roleId)
        {
            var result = await _context.Role.Where(x => x.Id == roleId)
                        .Select(x => new RoleModelSelect
                        {
                            Name = x.Name,
                            Permissions = _mapper.Map<ICollection<PermissionModelSelect>>
                            (x.RolePermissionRelationship.Select(x => x.Permission))
                        })
                        .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> Insert(RoleModelAdd role) 
        {
            var roleEntity = _mapper.Map<Role>(role);

            role.Permissions.ForEach(x =>
            {
                roleEntity.RolePermissionRelationship.Add(new RolePermissionRelationship
                {
                    PermissionId = x
                });
            });

            _context.Role.Add(roleEntity);
            var result = await _context.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> Update(RoleModelUpdate roleModel) 
        {
            var roleEntity = await _context.Role.Include(x => x.RolePermissionRelationship).FirstOrDefaultAsync(x => x.Id == roleModel.RoleId);

            if (roleEntity != null)
            {
                _context.TryUpdateManyToMany(roleEntity.RolePermissionRelationship,
                    roleModel.Permissions.Select(x => new RolePermissionRelationship
                    {
                        RoleId = roleEntity.Id,
                        PermissionId = x
                    }), x => x.PermissionId);
            }

            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> Delete(Guid roleId)
        {
            var roleEntity = await _context.Role.Include(x => x.RolePermissionRelationship).FirstOrDefaultAsync(x => x.Id == roleId);
            _context.Role.Remove(roleEntity);
            var result = await _context.SaveChangesAsync() > 0;

            return result;
        }
    }
}
