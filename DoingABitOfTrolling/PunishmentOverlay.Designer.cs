namespace DoingABitOfTrolling
{
    partial class PunishmentOverlay
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
            PunishmentText = new Label();
            SuspendLayout();
            // 
            // PunishmentText
            // 
            PunishmentText.AutoSize = true;
            PunishmentText.BackColor = Color.Transparent;
            PunishmentText.Font = new Font("Segoe UI Black", 23F, FontStyle.Regular, GraphicsUnit.Point);
            PunishmentText.ForeColor = Color.Black;
            PunishmentText.Location = new Point(12, 9);
            PunishmentText.Name = "PunishmentText";
            PunishmentText.Size = new Size(361, 42);
            PunishmentText.TabIndex = 0;
            PunishmentText.Text = "Punishment: Exsample";
            // 
            // PunishmentOverlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(600, 62);
            Controls.Add(PunishmentText);
            Cursor = Cursors.No;
            Enabled = false;
            FormBorderStyle = FormBorderStyle.None;
            Name = "PunishmentOverlay";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Overlay";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PunishmentText;
    }
}