using System;
using System.IO;

namespace eShopping.Adapters
{
    public class MockEmailService : IEmailService
    {
        public bool Gui(string den, string tieuDe, string noiDung, out string loi)
        {
            loi = null;
            if (den.IndexOf("fail", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                loi = "Máy chủ email từ chối.";
                return false;
            }
            try
            {
                string thuMuc = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Outbox");
                Directory.CreateDirectory(thuMuc);
                string tep = Path.Combine(thuMuc, DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + ".txt");
                File.WriteAllText(tep, "TO: " + den + "\r\nSUBJECT: " + tieuDe + "\r\n\r\n" + noiDung);
                return true;
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                return false;
            }
        }
    }
}
