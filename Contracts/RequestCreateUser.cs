namespace SaleOfProductsJWT.Contracts
{
    public class RequestCreateUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
