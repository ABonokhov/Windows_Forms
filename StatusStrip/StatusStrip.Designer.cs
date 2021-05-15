
namespace StatusStrip
{
    partial class ParentForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.spWin1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.spData2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spWin1,
            this.spData2});
            this.statusStrip2.Location = new System.Drawing.Point(0, 239);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(284, 22);
            this.statusStrip2.TabIndex = 0;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // spWin1
            // 
            this.spWin1.Name = "spWin1";
            this.spWin1.Size = new System.Drawing.Size(39, 17);
            this.spWin1.Text = "Status";
            this.spWin1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // spData2
            // 
            this.spData2.Name = "spData2";
            this.spData2.Size = new System.Drawing.Size(31, 17);
            this.spData2.Text = "Data";
            // 
            // ParentForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.statusStrip2);
            this.Name = "ParentForm";
            this.Load += new System.EventHandler(this.ParentForm_Load);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel spWin;
        private System.Windows.Forms.ToolStripStatusLabel spData;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel spWin1;
        private System.Windows.Forms.ToolStripStatusLabel spData2;
    }
}

