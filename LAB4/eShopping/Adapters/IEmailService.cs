namespace eShopping.Adapters
{
    public interface IEmailService
    {
        bool Gui(string den, string tieuDe, string noiDung, out string loi);
    }
}
