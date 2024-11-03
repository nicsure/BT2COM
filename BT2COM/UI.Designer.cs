namespace BT2COM
{
    partial class UI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainGrid = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            BTDevices = new ComboBox();
            ComPorts = new ComboBox();
            StartButton = new Button();
            StopButton = new Button();
            ScanButton = new Button();
            Status = new Label();
            MainGrid.SuspendLayout();
            SuspendLayout();
            // 
            // MainGrid
            // 
            MainGrid.ColumnCount = 6;
            MainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            MainGrid.ColumnStyles.Add(new ColumnStyle());
            MainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            MainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            MainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            MainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            MainGrid.Controls.Add(label1, 1, 1);
            MainGrid.Controls.Add(label2, 1, 2);
            MainGrid.Controls.Add(BTDevices, 2, 2);
            MainGrid.Controls.Add(ComPorts, 2, 1);
            MainGrid.Controls.Add(StartButton, 3, 3);
            MainGrid.Controls.Add(StopButton, 4, 3);
            MainGrid.Controls.Add(ScanButton, 2, 3);
            MainGrid.Controls.Add(Status, 1, 3);
            MainGrid.Dock = DockStyle.Fill;
            MainGrid.Location = new Point(0, 0);
            MainGrid.Name = "MainGrid";
            MainGrid.RowCount = 5;
            MainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            MainGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            MainGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            MainGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            MainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            MainGrid.Size = new Size(578, 257);
            MainGrid.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(23, 20);
            label1.Name = "label1";
            label1.Size = new Size(196, 72);
            label1.TabIndex = 0;
            label1.Text = "Virtual COM Port A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(23, 92);
            label2.Name = "label2";
            label2.Size = new Size(196, 72);
            label2.TabIndex = 0;
            label2.Text = "BT Device";
            // 
            // BTDevices
            // 
            BTDevices.BackColor = Color.FromArgb(64, 64, 64);
            MainGrid.SetColumnSpan(BTDevices, 3);
            BTDevices.Dock = DockStyle.Fill;
            BTDevices.DropDownStyle = ComboBoxStyle.DropDownList;
            BTDevices.FlatStyle = FlatStyle.Flat;
            BTDevices.Font = new Font("Segoe UI", 11F);
            BTDevices.ForeColor = Color.White;
            BTDevices.FormattingEnabled = true;
            BTDevices.Location = new Point(225, 95);
            BTDevices.Name = "BTDevices";
            BTDevices.Size = new Size(330, 38);
            BTDevices.TabIndex = 2;
            // 
            // ComPorts
            // 
            ComPorts.BackColor = Color.FromArgb(64, 64, 64);
            MainGrid.SetColumnSpan(ComPorts, 3);
            ComPorts.Dock = DockStyle.Fill;
            ComPorts.DropDownStyle = ComboBoxStyle.DropDownList;
            ComPorts.FlatStyle = FlatStyle.Flat;
            ComPorts.Font = new Font("Segoe UI", 11F);
            ComPorts.ForeColor = Color.White;
            ComPorts.FormattingEnabled = true;
            ComPorts.Location = new Point(225, 23);
            ComPorts.Name = "ComPorts";
            ComPorts.Size = new Size(330, 38);
            ComPorts.TabIndex = 2;
            // 
            // StartButton
            // 
            StartButton.Anchor = AnchorStyles.Left;
            StartButton.AutoSize = true;
            StartButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StartButton.BackColor = Color.FromArgb(64, 64, 64);
            StartButton.FlatStyle = FlatStyle.Flat;
            StartButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            StartButton.Location = new Point(337, 179);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(76, 42);
            StartButton.TabIndex = 1;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // StopButton
            // 
            StopButton.Anchor = AnchorStyles.Left;
            StopButton.AutoSize = true;
            StopButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StopButton.BackColor = Color.FromArgb(64, 64, 64);
            StopButton.FlatStyle = FlatStyle.Flat;
            StopButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            StopButton.Location = new Point(449, 179);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(72, 42);
            StopButton.TabIndex = 1;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = false;
            StopButton.Click += StopButton_Click;
            // 
            // ScanButton
            // 
            ScanButton.Anchor = AnchorStyles.Left;
            ScanButton.AutoSize = true;
            ScanButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ScanButton.BackColor = Color.FromArgb(64, 64, 64);
            ScanButton.FlatStyle = FlatStyle.Flat;
            ScanButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            ScanButton.Location = new Point(225, 179);
            ScanButton.Name = "ScanButton";
            ScanButton.Size = new Size(73, 42);
            ScanButton.TabIndex = 1;
            ScanButton.Text = "Scan";
            ScanButton.UseVisualStyleBackColor = false;
            ScanButton.Click += ScanButton_Click;
            // 
            // Status
            // 
            Status.Anchor = AnchorStyles.None;
            Status.AutoSize = true;
            Status.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Status.ForeColor = Color.Bisque;
            Status.Location = new Point(112, 187);
            Status.Name = "Status";
            Status.Size = new Size(17, 25);
            Status.TabIndex = 3;
            Status.Text = " ";
            // 
            // UI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(578, 257);
            Controls.Add(MainGrid);
            ForeColor = Color.White;
            Name = "UI";
            Text = "BT to COM";
            Shown += UI_Shown;
            MainGrid.ResumeLayout(false);
            MainGrid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel MainGrid;
        private Label label1;
        private Label label2;
        private Button ScanButton;
        private ComboBox BTDevices;
        private ComboBox ComPorts;
        private Button StartButton;
        private Button StopButton;
        private Label Status;
    }
}
