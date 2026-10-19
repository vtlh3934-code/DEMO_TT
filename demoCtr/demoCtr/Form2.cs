using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace demoCtr
{
    public partial class Form2 : Form
    {
        // Lưu kết quả để panel vẽ lại được (kể cả khi đổi kích thước form)
        private List<ProcessInfo> ketQua = new List<ProcessInfo>();

        public Form2()
        {
            InitializeComponent();
            dataGridView1.Columns["Column2"].ValueType = typeof(int);
            dataGridView1.Columns["Column3"].ValueType = typeof(int);

            panelGantt.Paint += panelGantt_Paint;       // gắn sự kiện vẽ
            panelGantt.Resize += (s, e) => panelGantt.Invalidate();
        }

        public class ProcessInfo
        {
            public string ProcessName { get; set; }
            public int ArrivalTime { get; set; }       // Thời gian đến
            public int BurstTime { get; set; }         // Thời gian sử dụng CPU
            public int StoreSystemTime { get; set; }   // Thời gian lưu lại hệ thống
            public int WaitTime { get; set; }          // Thời gian chờ
            public int StartTime { get; set; }         // Dùng để vẽ Gantt
            public int EndTime { get; set; }           // Dùng để vẽ Gantt
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int processCount) || processCount <= 0)
            {
                MessageBox.Show("So luong tien trinh khong hop le!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataGridView1.Rows.Clear();
            for (int i = 0; i < processCount; i++)
            {
                dataGridView1.Rows.Add("P" + (i + 1), 0, 0, 0, 0);
            }
            ketQua.Clear();
            panelGantt.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Đọc dữ liệu từ bảng
            List<ProcessInfo> list;
            try
            {
                list = dataGridView1.Rows
                    .Cast<DataGridViewRow>()// ep kieu
                    .Where(row => !row.IsNewRow)// loc 
                    .Select(row => new ProcessInfo // chuyen doi
                    {
                        ProcessName = row.Cells[0].Value.ToString(),
                        ArrivalTime = Convert.ToInt32(row.Cells["Column2"].Value),
                        BurstTime = Convert.ToInt32(row.Cells["Column3"].Value)
                    })
                    .OrderBy(process => process.ArrivalTime)
                    .ToList();
            }
            catch
            {
                MessageBox.Show("Du lieu trong bang khong hop le!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (list.Count == 0) return;

            // 2. Tính FCFS
            int currentTime = 0;
            foreach (var p in list)
            {
                if (currentTime < p.ArrivalTime)
                    currentTime = p.ArrivalTime;            // CPU rảnh, đợi tiến trình đến

                p.StartTime = currentTime;
                p.EndTime = currentTime + p.BurstTime;
                p.WaitTime = p.StartTime - p.ArrivalTime;
                p.StoreSystemTime = p.EndTime - p.ArrivalTime;

                currentTime = p.EndTime;
            }

            // 3. Hiển thị lại bảng theo thứ tự đã sắp xếp
            dataGridView1.Rows.Clear();
            foreach (var p in list)
            {
                dataGridView1.Rows.Add(p.ProcessName, p.ArrivalTime, p.BurstTime, p.StoreSystemTime, p.WaitTime);
            }

            // 4. Tính trung bình
            double tbCho = list.Average(p => p.WaitTime);

            MessageBox.Show(
                "Thoi gian cho trung binh: " + tbCho.ToString("0.00"));

            // 5. Vẽ Gantt
            ketQua = list;
            panelGantt.Invalidate();   // yêu cầu panel vẽ lại
        }

        private void panelGantt_Paint(object sender, PaintEventArgs e)
        {
            if (ketQua == null || ketQua.Count == 0) return;

            int totalTime = ketQua.Max(p => p.EndTime);
            if (totalTime == 0) return;

            Graphics g = e.Graphics;
            int left = 20, top = 40, height = 50;
            float scale = (panelGantt.Width - 2 * left) / (float)totalTime;   // số pixel / 1 đơn vị thời gian

            Color[] mau = { Color.LightSkyBlue, Color.LightGreen, Color.Khaki,
                            Color.LightPink, Color.Plum, Color.LightSalmon };

            using (Font font = new Font("Arial", 10))
            {
                for (int i = 0; i < ketQua.Count; i++)
                {
                    var p = ketQua[i];
                    float x = left + p.StartTime * scale;
                    float w = p.BurstTime * scale;

                    // Khối của tiến trình
                    using (Brush b = new SolidBrush(mau[i % mau.Length]))
                        g.FillRectangle(b, x, top, w, height);
                    g.DrawRectangle(Pens.Black, x, top, w, height);

                    // Tên tiến trình ở giữa khối
                    SizeF size = g.MeasureString(p.ProcessName, font);
                    g.DrawString(p.ProcessName, font, Brushes.Black,
                                 x + (w - size.Width) / 2, top + (height - size.Height) / 2);

                    // Mốc thời gian bắt đầu
                    g.DrawString(p.StartTime.ToString(), font, Brushes.Black, x - 5, top + height + 5);

                    // Mốc kết thúc: chỉ vẽ nếu là tiến trình cuối hoặc có khoảng trống phía sau
                    bool laCuoi = (i == ketQua.Count - 1);
                    if (laCuoi || ketQua[i + 1].StartTime != p.EndTime)
                        g.DrawString(p.EndTime.ToString(), font, Brushes.Black, x + w - 5, top + height + 5);
                }
            }
        }
    }
}