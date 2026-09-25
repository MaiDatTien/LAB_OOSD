using System.Drawing;
using System.Drawing.Drawing2D;

namespace QuanLyKhachSan.Forms
{
    public static class IconHelper
    {
        private static Bitmap NewBmp(int size = 32)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
                g.SmoothingMode = SmoothingMode.AntiAlias;
            return bmp;
        }

    
        public static Bitmap DanhMuc()
        {
            var bmp = NewBmp();
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillRectangle(new SolidBrush(Color.FromArgb(230, 240, 255)), 6, 4, 20, 26);
                g.DrawRectangle(new Pen(Color.FromArgb(60, 110, 180), 2), 6, 4, 20, 26);
                g.FillRectangle(Brushes.SteelBlue, 12, 2, 8, 4);
                for (int i = 0; i < 3; i++)
                    g.DrawLine(new Pen(Color.FromArgb(60, 110, 180), 2), 10, 13 + i * 5, 22, 13 + i * 5);
            }
            return bmp;
        }

        
        public static Bitmap Phong()
        {
            var bmp = NewBmp();
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillRectangle(Brushes.SaddleBrown, 4, 20, 24, 3);
                g.FillRectangle(new SolidBrush(Color.SteelBlue), 6, 12, 20, 8);
                g.FillEllipse(Brushes.White, 7, 10, 8, 6);
                g.DrawLine(new Pen(Color.SaddleBrown, 2), 5, 12, 5, 25);
                g.DrawLine(new Pen(Color.SaddleBrown, 2), 27, 15, 27, 25);
            }
            return bmp;
        }

      
        public static Bitmap DatPhong()
        {
            var bmp = NewBmp();
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawEllipse(new Pen(Color.Goldenrod, 3), 5, 5, 12, 12);
                g.DrawLine(new Pen(Color.Goldenrod, 3), 15, 15, 27, 27);
                g.DrawLine(new Pen(Color.Goldenrod, 3), 22, 22, 26, 18);
                g.DrawLine(new Pen(Color.Goldenrod, 3), 25, 25, 29, 21);
            }
            return bmp;
        }

       
        public static Bitmap DichVu()
        {
            var bmp = NewBmp();
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillEllipse(Brushes.Gray, 8, 8, 16, 16);
                g.FillEllipse(Brushes.White, 12, 12, 8, 8);
                for (int i = 0; i < 8; i++)
                {
                    double a = i * Math.PI / 4;
                    int x = 16 + (int)(11 * Math.Cos(a));
                    int y = 16 + (int)(11 * Math.Sin(a));
                    g.FillRectangle(Brushes.Gray, x - 1, y - 1, 3, 3);
                }
            }
            return bmp;
        }

        
        public static Bitmap TraPhong()
        {
            var bmp = NewBmp();
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillRectangle(Brushes.LightGreen, 6, 8, 16, 10);
                g.DrawRectangle(new Pen(Color.ForestGreen, 2), 6, 8, 16, 10);
                g.DrawString("$", new Font("Arial", 9, FontStyle.Bold), Brushes.ForestGreen, 10, 8);
                g.DrawArc(new Pen(Color.SaddleBrown, 3), 4, 16, 22, 12, 0, 180);
            }
            return bmp;
        }

    
        public static Bitmap ThongKe()
        {
            var bmp = NewBmp();
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillRectangle(Brushes.SteelBlue, 7, 18, 5, 10);
                g.FillRectangle(Brushes.SeaGreen, 14, 10, 5, 18);
                g.FillRectangle(Brushes.Goldenrod, 21, 14, 5, 14);
            }
            return bmp;
        }


        public static Bitmap Thoat()
        {
            var bmp = NewBmp();
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillRectangle(Brushes.SaddleBrown, 6, 5, 12, 22);
                g.FillEllipse(Brushes.SaddleBrown, 15, 15, 2, 2);
                using (var pen = new Pen(Color.ForestGreen, 3))
                {
                    g.DrawLine(pen, 20, 16, 28, 16);
                    g.DrawLine(pen, 24, 12, 28, 16);
                    g.DrawLine(pen, 24, 20, 28, 16);
                }
            }
            return bmp;
        }
    }
}