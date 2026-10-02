namespace eShopping.Adapters
{
    public static class DichVuNgoai
    {
        public static IProductSystem SanPham = new MockProductSystem();
        public static IPaymentGateway ThanhToan = new MockPaymentGateway();
        public static IEmailService Email = new MockEmailService();
    }
}
