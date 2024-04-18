﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Services.IService;

namespace SaleOfProductsJWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : BaseController<User>
    {
        private readonly IMapper _mapper;
        public UserController(ILogger<UserController> logger, IUserService service, IMapper mapper) : base(logger, service)
        {
            _mapper = mapper;
        }

        
    }
}
