using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Forms
{
    // Hàm dựng giao diện bằng code (không cần Designer) và hàm dùng chung cho các Form
    public static class Ui
    {
        public static bool Bao(KetQuaXuLy k)
        {
            MessageBox.Show(k.ThongBao, k.ThanhCong ? "Thành công" : "Từ chối",
                MessageBoxButtons.OK, k.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            return k.ThanhCong;
        }
        public static string V(ComboBox c) { return c.SelectedValue == null ? "" : c.SelectedValue.ToString(); }
        public static void Nap(ComboBox c, object nguon, string hienThi, string giaTri)
        { c.DataSource = nguon; c.DisplayMember = hienThi; c.ValueMember = giaTri; }

        public static void CauHinh(Form f, string tieuDe, int rong, int cao)
        {
            f.Text = tieuDe;
            f.ClientSize = new Size(rong, cao);
            f.StartPosition = FormStartPosition.CenterParent;
            f.Font = new Font("Segoe UI", 9.5f);
        }

        public static Label Lbl(string text)
        { return new Label { Text = text, AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(6, 8, 3, 3) }; }
        public static TextBox Txt(bool nhieuDong = false)
        {
            var t = new TextBox { Dock = DockStyle.Fill, Margin = new Padding(3, 5, 12, 3) };
            if (nhieuDong) { t.Multiline = true; t.Height = 60; t.ScrollBars = ScrollBars.Vertical; }
            return t;
        }
        public static ComboBox Cbo()
        { return new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList, Margin = new Padding(3, 5, 12, 3) }; }
        public static ComboBox CboList(params string[] muc)
        {
            var c = Cbo();
            c.Items.AddRange(muc);
            if (muc.Length > 0) c.SelectedIndex = 0;
            return c;
        }
        public static DateTimePicker Dtp()
        { return new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", Dock = DockStyle.Fill, Margin = new Padding(3, 5, 12, 3) }; }
        public static DateTimePicker Gio()
        { return new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "HH:mm", ShowUpDown = true, Dock = DockStyle.Fill, Margin = new Padding(3, 5, 12, 3) }; }
        public static NumericUpDown Num(decimal max = 2000000000m, int thapPhan = 0, decimal giaTri = 0)
        {
            return new NumericUpDown { Minimum = 0, Maximum = max, DecimalPlaces = thapPhan, ThousandsSeparator = true,
                Value = giaTri, Dock = DockStyle.Fill, Margin = new Padding(3, 5, 12, 3) };
        }
        public static Button Btn(string text)
        { return new Button { Text = text, AutoSize = true, Padding = new Padding(10, 3, 10, 3), Margin = new Padding(6, 6, 6, 6) }; }

        // cao > 0: lưới cao cố định; cao = 0: lưới chiếm phần còn lại
        public static DataGridView Dgv(int cao = 0)
        {
            var d = new DataGridView
            {
                Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false, AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false, RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells, BackgroundColor = SystemColors.Window,
                Margin = new Padding(6, 3, 6, 3)
            };
            if (cao > 0) d.Tag = cao;
            d.DataBindingComplete += (o, ev) =>
            {
                foreach (DataGridViewColumn c in d.Columns)
                {
                    if (c.ValueType == typeof(DateTime)) c.DefaultCellStyle.Format = "dd/MM/yyyy";
                    else if (c.ValueType == typeof(decimal) || c.ValueType == typeof(double))
                        c.DefaultCellStyle.Format = (c.Name.Contains("Gio") || c.Name.Contains("HeSo") || c.Name.Contains("MucDong")) ? "0.##" : "N0";
                }
            };
            return d;
        }

        // Lưới nhập: cap = số cặp (nhãn + ô nhập) trên một hàng
        public static TableLayoutPanel Luoi(int cap)
        {
            var t = new TableLayoutPanel { ColumnCount = cap * 2, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Dock = DockStyle.Fill, Tag = new int[] { 0, 0, cap } };
            for (int i = 0; i < cap; i++)
            {
                t.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cap));
            }
            return t;
        }
        public static void Them(TableLayoutPanel t, string nhan, Control c, int span = 1)
        {
            var p = (int[])t.Tag;          // p[0] = cột hiện tại, p[1] = hàng, p[2] = số cặp
            if (p[0] + span > p[2]) { p[0] = 0; p[1]++; }
            t.Controls.Add(Lbl(nhan), p[0] * 2, p[1]);
            t.Controls.Add(c, p[0] * 2 + 1, p[1]);
            t.SetColumnSpan(c, span * 2 - 1);
            p[0] += span;
        }
        public static FlowLayoutPanel Hang(params Control[] cs)
        {
            var f = new FlowLayoutPanel { AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Dock = DockStyle.Fill, WrapContents = true };
            foreach (var c in cs)
                if (c is ComboBox || c is TextBox || c is NumericUpDown || c is DateTimePicker) c.Dock = DockStyle.None;
            f.Controls.AddRange(cs);
            return f;
        }
        public static TabPage Tab(TabControl tc, string ten)
        {
            var p = new TabPage(ten) { Padding = new Padding(4) };
            tc.TabPages.Add(p);
            return p;
        }
        // Xếp các thành phần theo chiều dọc: lưới DataGridView chiếm phần còn lại (hoặc cao cố định), phần khác tự co theo nội dung
        public static void Doc(Control cha, params Control[] hang)
        {
            var t = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = hang.Length };
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            int nFill = 0;
            foreach (var c in hang) if (DangChiemCho(c)) nFill++;
            foreach (var c in hang)
            {
                var d = c as DataGridView;
                if (d != null && d.Tag is int) t.RowStyles.Add(new RowStyle(SizeType.Absolute, (int)d.Tag));
                else if (DangChiemCho(c)) t.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / nFill));
                else t.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                c.Dock = DockStyle.Fill;
                t.Controls.Add(c);
            }
            cha.Controls.Add(t);
        }
        static bool DangChiemCho(Control c)
        {
            var d = c as DataGridView;
            if (d != null) return !(d.Tag is int);
            return c is TabControl || (c.Tag is string && (string)c.Tag == "fill");
        }
    }
}
