using AutoMapper;
using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Colleges;
using EsportsCmsApplication.Interfaces.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Services
{
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return _mapper.Map<List<RoleDto>>(roles);
        }

    }
}
