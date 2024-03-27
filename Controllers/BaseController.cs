using Microsoft.AspNetCore.Mvc;
using SaleOfProductsJWT.Models.BaseClassModels;
using SaleOfProductsJWT.Services;

namespace SaleOfProductsJWT.Controllers
{
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        protected readonly IBaseService<TEntity> _service;
        protected readonly ILogger<BaseController<TEntity>> _logger;
        public BaseController(ILogger<BaseController<TEntity>> logger, IBaseService<TEntity> service)
        {
            _logger = logger;
            _service = service;
        }

    }
}
