using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoCtr
{
    public partial class Form3 : Form
    {
        public class TienTrinh
        {
            public string Ten { get; set; } = "";
            public int AT { get; set; }
            public int BT { get; set; }
            public int ST { get; set; }
            public int CT { get; set; }
            public int TAT { get; set; }
            public int WT { get; set; }
            public bool DaXong { get; set; } = false;
        }

        public class OGantt
        {
            public string Ten { get; set; } = "";
            public int ThoiGianBatDau { get; set; }
            public int ThoiGianKetThuc { get; set; }
        }

        private List<OGantt> ganttList = new List<OGantt>();
        public Form3()
        {
            InitializeComponent();
            //MessageBox.Show("file nay ok rooi");
        }
        // =============================================================
        // NÚT "THÊM TIẾN TRÌNH": Bật cửa sổ nhập Tên, AT, BT
        // =============================================================
        private void BtnThem_Click(object sender, EventArgs e)
        {
            // Tự động gợi ý tên tiếp theo (P1, P2, P3...)
            string tenGoiY = $"P{dgvInput.Rows.Count + 1}";

            // Tạo form nhập liệu nhỏ (Popup)
            Form f = new Form
            {
                Text = "Thêm tiến trình mới",
                Size = new Size(480, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl1 = new Label { Text = "Tên tiến trình:", Location = new Point(25, 25), AutoSize = true };
            TextBox txtTen = new TextBox { Text = tenGoiY, Location = new Point(230, 22), Width = 180 };

            Label lbl2 = new Label { Text = "Arrival Time (AT):", Location = new Point(25, 75), AutoSize = true };
            TextBox txtAT = new TextBox { Text = "0", Location = new Point(230, 72), Width = 180 };

            Label lbl3 = new Label { Text = "Burst Time (BT):", Location = new Point(25, 125), AutoSize = true };
            TextBox txtBT = new TextBox { Text = "1", Location = new Point(230, 122), Width = 180 };

            Button btnXacNhan = new Button
            {
                Text = "Lưu",
                Location = new Point(130, 180),
                Size = new Size(160, 40),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat
            };

            btnXacNhan.Click += (s, args) =>
            {
                string ten = txtTen.Text.Trim();
                if (string.IsNullOrEmpty(ten))
                {
                    MessageBox.Show("Vui lòng nhập tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtAT.Text.Trim(), out int at) || at < 0)
                {
                    MessageBox.Show("Arrival Time phải là số >= 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtBT.Text.Trim(), out int bt) || bt <= 0)
                {
                    MessageBox.Show("Burst Time phải là số > 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm vào bảng
                dgvInput.Rows.Add(ten, at, bt);
                f.Close();
            };

            f.Controls.AddRange(new Control[] { lbl1, txtTen, lbl2, txtAT, lbl3, txtBT, btnXacNhan });
            f.ShowDialog(this);
        }
        // =============================================================
        // NÚT "XÓA TẤT CẢ"
        // =============================================================
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            dgvInput.Rows.Clear();
            dgvOutput.Rows.Clear();
            lblKetQua.Text = "";
            lblKetQua.Visible = false;
            ganttList.Clear();
            pnlGantt.Invalidate();
        }

        // =============================================================
        // NÚT "CHẠY THUẬT TOÁN" (SJF Non-preemptive)
        // =============================================================
        private void BtnChay_Click(object sender, EventArgs e)
        {
            List<TienTrinh> danhSach = new List<TienTrinh>();

            for (int i = 0; i < dgvInput.Rows.Count; i++)
            {
                var row = dgvInput.Rows[i];
                if (row.Cells[0].Value == null) continue;

                string ten = row.Cells[0].Value.ToString() ?? "";
                int at = int.Parse(row.Cells[1].Value.ToString());
                int bt = int.Parse(row.Cells[2].Value.ToString());

                danhSach.Add(new TienTrinh { Ten = ten, AT = at, BT = bt });
            }

            if (danhSach.Count == 0)
            {
                MessageBox.Show("Vui lòng bấm '➕ Thêm tiến trình' trước khi chạy!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            danhSach = danhSach.OrderBy(p => p.AT).ThenBy(p => p.BT).ToList();

            int soTienTrinh = danhSach.Count;
            int daXong = 0;
            int currentTime = 0;
            ganttList = new List<OGantt>();

            while (daXong < soTienTrinh)
            {
                int viTriChon = -1;
                int btNhoNhat = int.MaxValue;

                for (int i = 0; i < soTienTrinh; i++)
                {
                    if (!danhSach[i].DaXong && danhSach[i].AT <= currentTime)
                    {
                        if (danhSach[i].BT < btNhoNhat ||
                           (danhSach[i].BT == btNhoNhat && viTriChon != -1 &&
                            danhSach[i].AT < danhSach[viTriChon].AT))
                        {
                            btNhoNhat = danhSach[i].BT;
                            viTriChon = i;
                        }
                    }
                }

                if (viTriChon == -1)
                {
                    if (ganttList.Count > 0 && ganttList[ganttList.Count - 1].Ten == "Idle")
                    {
                        ganttList[ganttList.Count - 1].ThoiGianKetThuc = currentTime + 1;
                    }
                    else
                    {
                        ganttList.Add(new OGantt
                        {
                            Ten = "Idle",
                            ThoiGianBatDau = currentTime,
                            ThoiGianKetThuc = currentTime + 1
                        });
                    }
                    currentTime++;
                }
                else
                {
                    TienTrinh p = danhSach[viTriChon];
                    p.ST = currentTime;
                    p.CT = currentTime + p.BT;
                    p.TAT = p.CT - p.AT;
                    p.WT = p.TAT - p.BT;
                    p.DaXong = true;

                    ganttList.Add(new OGantt
                    {
                        Ten = p.Ten,
                        ThoiGianBatDau = currentTime,
                        ThoiGianKetThuc = p.CT
                    });

                    currentTime = p.CT;
                    daXong++;
                }
            }

            dgvOutput.Rows.Clear();
            double tongWT = 0;
            double tongTAT = 0;

            var ketQua = danhSach.OrderBy(p => p.Ten).ToList();
            foreach (var p in ketQua)
            {
                dgvOutput.Rows.Add(p.Ten, p.AT, p.BT, p.ST, p.CT, p.TAT, p.WT);
                tongWT += p.WT;
                tongTAT += p.TAT;
            }

            double awt = tongWT / soTienTrinh;
            double atat = tongTAT / soTienTrinh;

            lblKetQua.Text = $"📌 Kết quả trung bình:\n\n" +
                             $"• AWT  (Avg Waiting Time):\n" +
                             $"   {tongWT}/{soTienTrinh} = {awt:F2}\n\n" +
                             $"• ATAT (Avg Turnaround Time):\n" +
                             $"   {tongTAT}/{soTienTrinh} = {atat:F2}";
            lblKetQua.Visible = true;

            pnlGantt.Invalidate();
        }
        // =============================================================
        // VẼ SƠ ĐỒ GANTT
        // =============================================================
        private void PnlGantt_Paint(object sender, PaintEventArgs e)
        {
            if (ganttList.Count == 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int chieuCaoO = 50;
            int y = 10;
            int hesoRong = 45;
            int xBatDau = 30;

            Color[] bangMau = new Color[]
            {
                Color.FromArgb(255, 179, 186),
                Color.FromArgb(186, 225, 255),
                Color.FromArgb(186, 255, 201),
                Color.FromArgb(255, 255, 186),
                Color.FromArgb(218, 186, 255),
                Color.FromArgb(255, 218, 186),
                Color.FromArgb(186, 255, 255),
                Color.FromArgb(255, 186, 255),
                Color.FromArgb(200, 230, 201),
                Color.FromArgb(255, 224, 178)
            };

            Dictionary<string, Color> mauTienTrinh = new Dictionary<string, Color>();
            int demMau = 0;

            int tongThoiGian = ganttList[ganttList.Count - 1].ThoiGianKetThuc;
            int tongRong = xBatDau + tongThoiGian * hesoRong + 50;
            pnlGantt.AutoScrollMinSize = new Size(tongRong, chieuCaoO + 60);

            g.TranslateTransform(pnlGantt.AutoScrollPosition.X, pnlGantt.AutoScrollPosition.Y);

            Font fontTen = new Font("Segoe UI", 10, FontStyle.Bold);
            Font fontThoiGian = new Font("Segoe UI", 8);
            Pen penVien = new Pen(Color.DarkSlateGray, 2);
            Brush brushChu = Brushes.Black;

            foreach (var o in ganttList)
            {
                int x = xBatDau + o.ThoiGianBatDau * hesoRong;
                int w = (o.ThoiGianKetThuc - o.ThoiGianBatDau) * hesoRong;
                Rectangle rect = new Rectangle(x, y, w, chieuCaoO);

                Color mau;
                if (o.Ten == "Idle")
                {
                    mau = Color.LightGray;
                }
                else
                {
                    if (!mauTienTrinh.ContainsKey(o.Ten))
                    {
                        mauTienTrinh[o.Ten] = bangMau[demMau % bangMau.Length];
                        demMau++;
                    }
                    mau = mauTienTrinh[o.Ten];
                }

                using (Brush b = new SolidBrush(mau))
                {
                    g.FillRectangle(b, rect);
                }
                g.DrawRectangle(penVien, rect);

                SizeF sizeText = g.MeasureString(o.Ten, fontTen);
                float textX = x + (w - sizeText.Width) / 2;
                float textY = y + (chieuCaoO - sizeText.Height) / 2;
                g.DrawString(o.Ten, fontTen, brushChu, textX, textY);

                g.DrawString(o.ThoiGianBatDau.ToString(), fontThoiGian, brushChu,
                             x, y + chieuCaoO + 3);
            }

            var oCuoi = ganttList[ganttList.Count - 1];
            int xCuoi = xBatDau + oCuoi.ThoiGianKetThuc * hesoRong;
            g.DrawString(oCuoi.ThoiGianKetThuc.ToString(), fontThoiGian, brushChu,
                         xCuoi, y + chieuCaoO + 3);

            fontTen.Dispose();
            fontThoiGian.Dispose();
            penVien.Dispose();
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
