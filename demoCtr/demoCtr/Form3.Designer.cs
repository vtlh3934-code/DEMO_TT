using System.Drawing;
using System.Windows.Forms;

namespace demoCtr
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInput = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnChay = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvOutput = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.pnlGantt = new System.Windows.Forms.Panel();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblGantt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thuật toán SJF";
            // 
            // dgvInput
            // 
            this.dgvInput.AllowUserToAddRows = false;
            this.dgvInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInput.ColumnHeadersHeight = 46;
            this.dgvInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvInput.Location = new System.Drawing.Point(45, 113);
            this.dgvInput.Name = "dgvInput";
            this.dgvInput.RowHeadersWidth = 82;
            this.dgvInput.Size = new System.Drawing.Size(974, 190);
            this.dgvInput.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên (P)";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Arrival Time";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Burst Time";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(1039, 113);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(180, 42);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "➕ Thêm tiến trình";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // btnChay
            // 
            this.btnChay.BackColor = System.Drawing.Color.LightGreen;
            this.btnChay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChay.Location = new System.Drawing.Point(1039, 191);
            this.btnChay.Name = "btnChay";
            this.btnChay.Size = new System.Drawing.Size(180, 42);
            this.btnChay.TabIndex = 3;
            this.btnChay.Text = "▶ Chạy thuật toán";
            this.btnChay.UseVisualStyleBackColor = false;
            this.btnChay.Click += new System.EventHandler(this.BtnChay_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.LightCoral;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Location = new System.Drawing.Point(1039, 261);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(180, 42);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "🗑 Xóa tất cả";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            // 
            // dgvOutput
            // 
            this.dgvOutput.AllowUserToAddRows = false;
            this.dgvOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOutput.ColumnHeadersHeight = 46;
            this.dgvOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dgvOutput.Location = new System.Drawing.Point(45, 349);
            this.dgvOutput.Name = "dgvOutput";
            this.dgvOutput.ReadOnly = true;
            this.dgvOutput.RowHeadersWidth = 82;
            this.dgvOutput.Size = new System.Drawing.Size(883, 225);
            this.dgvOutput.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Tiến trình";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "AT";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "BT";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Start";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "CT";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "TAT";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "WT";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // lblKetQua
            // 
            this.lblKetQua.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblKetQua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKetQua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKetQua.ForeColor = System.Drawing.Color.DarkRed;
            this.lblKetQua.Location = new System.Drawing.Point(934, 349);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(300, 225);
            this.lblKetQua.TabIndex = 7;
            this.lblKetQua.Visible = false;
            // 
            // pnlGantt
            // 
            this.pnlGantt.AutoScroll = true;
            this.pnlGantt.BackColor = System.Drawing.Color.White;
            this.pnlGantt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGantt.Location = new System.Drawing.Point(45, 644);
            this.pnlGantt.Name = "pnlGantt";
            this.pnlGantt.Size = new System.Drawing.Size(1174, 125);
            this.pnlGantt.TabIndex = 9;
            this.pnlGantt.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlGantt_Paint);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInput.Location = new System.Drawing.Point(40, 28);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(271, 30);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "DANH SÁCH TIẾN TRÌNH";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOutput.Location = new System.Drawing.Point(45, 306);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(202, 30);
            this.lblOutput.TabIndex = 5;
            this.lblOutput.Text = "KẾT QUẢ ĐIỀU ĐỘ";
            // 
            // lblGantt
            // 
            this.lblGantt.AutoSize = true;
            this.lblGantt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGantt.Location = new System.Drawing.Point(40, 593);
            this.lblGantt.Name = "lblGantt";
            this.lblGantt.Size = new System.Drawing.Size(161, 30);
            this.lblGantt.TabIndex = 8;
            this.lblGantt.Text = "SƠ ĐỒ GANTT";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 811);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.dgvInput);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnChay);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.dgvOutput);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.lblGantt);
            this.Controls.Add(this.pnlGantt);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mô phỏng thuật toán SJF không trưng dụng (Non-preemptive SJF)";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvInput;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnChay;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgvOutput;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Panel pnlGantt;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblGantt;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        

        #endregion

        private System.Windows.Forms.Label label1;
    }
}