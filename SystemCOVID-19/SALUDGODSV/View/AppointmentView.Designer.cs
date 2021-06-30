
namespace SALUDGODSV.View
{
    partial class AppointmentView
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
            this.SuspendLayout();
            // 
            // AppointmentView
            // 
            this.ClientSize = new System.Drawing.Size(345, 261);
            this.Name = "AppointmentView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAppointmentView;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblShowName;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.Label lblShowBirthday;
        private System.Windows.Forms.Label lblDUI;
        private System.Windows.Forms.Label lblShowDUI;
        private System.Windows.Forms.Label lblDosis;
        private System.Windows.Forms.Label lblShowDosis;
        private System.Windows.Forms.Button btnVacunar;
        private System.Windows.Forms.Button btnShowInformation;
    }
}