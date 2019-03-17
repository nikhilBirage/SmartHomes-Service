using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.API.Dtos;
using SmartHome.API.Models;
using SmartHome.API.Repositories;

namespace SmartHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private IUserManagementRepository _userManagementRepository;
        public UserManagementController(IUserManagementRepository userManagementRepository)
        {
            _userManagementRepository = userManagementRepository;
        }

        [HttpGet]
        [Route("getUsers")]
        public IEnumerable<UserMeterDetail> GetAllUser()
        {
            return _userManagementRepository.GetUsers();
        }

    }
}