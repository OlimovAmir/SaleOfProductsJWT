

namespace SaleOfProductsJWT.Models.BaseClassModels
{
    public abstract class BaseEntity
    {
        
        public virtual  Guid Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"Id:{Id} ({GetType().Name})";
        }
    }
}
