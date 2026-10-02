using System.Data;
using System.Windows.Forms;

namespace eShopping.Forms
{
    static class Ui
    {
        public static Label Nhan(Control cha, string chu, int x, int y, int rong = 110)
        {
            var l = new Label { Text = chu, Left = x, Top = y + 3, Width = rong };
            cha.Controls.Add(l);
            return l;
        }

        public static TextBox OText(Control cha, int x, int y, int rong = 200)
        {
            var t = new TextBox { Left = x, Top = y, Width = rong };
            cha.Controls.Add(t);
            return t;
        }

        public static Button Nut(Control cha, string chu, int x, int y, int rong = 110)
        {
            var b = new Button { Text = chu, Left = x, Top = y, Width = rong, Height = 28 };
            cha.Controls.Add(b);
            return b;
        }

        public static ComboBox OChon(Control cha, int x, int y, int rong = 200)
        {
            var c = new ComboBox { Left = x, Top = y, Width = rong, DropDownStyle = ComboBoxStyle.DropDownList };
            cha.Controls.Add(c);
            return c;
        }

        public static NumericUpDown OSo(Control cha, int x, int y, int rong, decimal nho, decimal lon, decimal giaTri)
        {
            var n = new NumericUpDown { Left = x, Top = y, Width = rong, Minimum = nho, Maximum = lon, Value = giaTri };
            cha.Controls.Add(n);
            return n;
        }

        public static DataGridView Luoi(Control cha, int x, int y, int rong, int cao)
        {
            var g = new DataGridView
            {
                Left = x,
                Top = y,
                Width = rong,
                Height = cao,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };
            cha.Controls.Add(g);
            return g;
        }

        public static void NapComboBox(ComboBox c, DataTable dt, string hienThi, string giaTri)
        {
            c.DataSource = dt;
            c.DisplayMember = hienThi;
            c.ValueMember = giaTri;
        }

        public static string GiaTri(ComboBox c)
        {
            return c.SelectedValue == null ? "" : c.SelectedValue.ToString();
        }
    }
}
