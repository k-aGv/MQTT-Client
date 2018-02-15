namespace broker
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_rec = new System.Windows.Forms.Button();
            this.tb_response = new System.Windows.Forms.TextBox();
            this.lb_isConnected = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.tb_topic1 = new System.Windows.Forms.TextBox();
            this.gb_topics = new System.Windows.Forms.GroupBox();
            this.lb_please = new System.Windows.Forms.Label();
            this.tb_topic2 = new System.Windows.Forms.TextBox();
            this.gb_reciever = new System.Windows.Forms.GroupBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.gb_logs = new System.Windows.Forms.GroupBox();
            this.cb_grid = new System.Windows.Forms.CheckBox();
            this.tb_logs = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gb_topics.SuspendLayout();
            this.gb_reciever.SuspendLayout();
            this.gb_logs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_rec
            // 
            this.btn_rec.Location = new System.Drawing.Point(6, 24);
            this.btn_rec.Name = "btn_rec";
            this.btn_rec.Size = new System.Drawing.Size(107, 23);
            this.btn_rec.TabIndex = 0;
            this.btn_rec.Text = "Start Recording";
            this.btn_rec.UseVisualStyleBackColor = true;
            this.btn_rec.Click += new System.EventHandler(this.btn_rec_Click);
            // 
            // tb_response
            // 
            this.tb_response.Location = new System.Drawing.Point(6, 53);
            this.tb_response.Multiline = true;
            this.tb_response.Name = "tb_response";
            this.tb_response.Size = new System.Drawing.Size(282, 176);
            this.tb_response.TabIndex = 1;
            // 
            // lb_isConnected
            // 
            this.lb_isConnected.AutoSize = true;
            this.lb_isConnected.Location = new System.Drawing.Point(194, 29);
            this.lb_isConnected.Name = "lb_isConnected";
            this.lb_isConnected.Size = new System.Drawing.Size(10, 13);
            this.lb_isConnected.TabIndex = 2;
            this.lb_isConnected.Text = "-";
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Location = new System.Drawing.Point(134, 29);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(40, 13);
            this.lb_status.TabIndex = 3;
            this.lb_status.Text = "Status:";
            // 
            // tb_topic1
            // 
            this.tb_topic1.Location = new System.Drawing.Point(6, 19);
            this.tb_topic1.Name = "tb_topic1";
            this.tb_topic1.Size = new System.Drawing.Size(300, 20);
            this.tb_topic1.TabIndex = 4;
            this.tb_topic1.TextChanged += new System.EventHandler(this.tb_topic1_TextChanged);
            // 
            // gb_topics
            // 
            this.gb_topics.Controls.Add(this.lb_please);
            this.gb_topics.Controls.Add(this.tb_topic2);
            this.gb_topics.Controls.Add(this.tb_topic1);
            this.gb_topics.Controls.Add(this.gb_reciever);
            this.gb_topics.Location = new System.Drawing.Point(12, 13);
            this.gb_topics.Name = "gb_topics";
            this.gb_topics.Size = new System.Drawing.Size(318, 356);
            this.gb_topics.TabIndex = 5;
            this.gb_topics.TabStop = false;
            this.gb_topics.Text = "Topics";
            // 
            // lb_please
            // 
            this.lb_please.AutoSize = true;
            this.lb_please.Location = new System.Drawing.Point(6, 70);
            this.lb_please.Name = "lb_please";
            this.lb_please.Size = new System.Drawing.Size(35, 13);
            this.lb_please.TabIndex = 6;
            this.lb_please.Text = "NULL";
            // 
            // tb_topic2
            // 
            this.tb_topic2.Location = new System.Drawing.Point(6, 45);
            this.tb_topic2.Name = "tb_topic2";
            this.tb_topic2.Size = new System.Drawing.Size(300, 20);
            this.tb_topic2.TabIndex = 4;
            this.tb_topic2.TextChanged += new System.EventHandler(this.tb_topic2_TextChanged);
            // 
            // gb_reciever
            // 
            this.gb_reciever.Controls.Add(this.btn_clear);
            this.gb_reciever.Controls.Add(this.lb_isConnected);
            this.gb_reciever.Controls.Add(this.tb_response);
            this.gb_reciever.Controls.Add(this.lb_status);
            this.gb_reciever.Controls.Add(this.btn_rec);
            this.gb_reciever.Location = new System.Drawing.Point(6, 89);
            this.gb_reciever.Name = "gb_reciever";
            this.gb_reciever.Size = new System.Drawing.Size(300, 261);
            this.gb_reciever.TabIndex = 5;
            this.gb_reciever.TabStop = false;
            this.gb_reciever.Text = "Messages";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(7, 236);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(281, 23);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "Disconnect and clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // gb_logs
            // 
            this.gb_logs.Controls.Add(this.cb_grid);
            this.gb_logs.Controls.Add(this.tb_logs);
            this.gb_logs.Location = new System.Drawing.Point(336, 13);
            this.gb_logs.Name = "gb_logs";
            this.gb_logs.Size = new System.Drawing.Size(410, 356);
            this.gb_logs.TabIndex = 6;
            this.gb_logs.TabStop = false;
            this.gb_logs.Text = "Logs";
            // 
            // cb_grid
            // 
            this.cb_grid.AutoSize = true;
            this.cb_grid.Location = new System.Drawing.Point(7, 334);
            this.cb_grid.Name = "cb_grid";
            this.cb_grid.Size = new System.Drawing.Size(73, 17);
            this.cb_grid.TabIndex = 7;
            this.cb_grid.Text = "Show grid";
            this.cb_grid.UseVisualStyleBackColor = true;
            this.cb_grid.CheckedChanged += new System.EventHandler(this.cb_grid_CheckedChanged);
            // 
            // tb_logs
            // 
            this.tb_logs.Location = new System.Drawing.Point(7, 18);
            this.tb_logs.Multiline = true;
            this.tb_logs.Name = "tb_logs";
            this.tb_logs.Size = new System.Drawing.Size(397, 310);
            this.tb_logs.TabIndex = 0;
            // 
            // chart
            // 
            this.chart.BorderlineWidth = 5;
            this.chart.BorderSkin.BorderColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(752, 13);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.MarkerStep = 10;
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(454, 356);
            this.chart.TabIndex = 7;
            this.chart.Text = "chart1";
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 381);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.gb_logs);
            this.Controls.Add(this.gb_topics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb_topics.ResumeLayout(false);
            this.gb_topics.PerformLayout();
            this.gb_reciever.ResumeLayout(false);
            this.gb_reciever.PerformLayout();
            this.gb_logs.ResumeLayout(false);
            this.gb_logs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_rec;
        private System.Windows.Forms.TextBox tb_response;
        private System.Windows.Forms.Label lb_isConnected;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.TextBox tb_topic1;
        private System.Windows.Forms.GroupBox gb_topics;
        private System.Windows.Forms.TextBox tb_topic2;
        private System.Windows.Forms.GroupBox gb_reciever;
        private System.Windows.Forms.GroupBox gb_logs;
        private System.Windows.Forms.TextBox tb_logs;
        private System.Windows.Forms.Label lb_please;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.CheckBox cb_grid;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}

