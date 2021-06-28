
namespace SALUDGODSV.View
{
    partial class IngresarEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresarEmpleado));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTextShowLogin = new System.Windows.Forms.Label();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblShowID = new System.Windows.Forms.Label();
            this.lblShowSecurityQuestion = new System.Windows.Forms.Label();
            this.lblShowAnswer = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblShowQuestion = new System.Windows.Forms.Label();
            this.txtInsertID = new System.Windows.Forms.TextBox();
            this.txtInsertAnswer = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(77)))), ((int)(((byte)(188)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.picLogo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTextShowLogin, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Image = global::SALUDGODSV.Properties.Resources.gobiernoDelSalvador;
            this.picLogo.Location = new System.Drawing.Point(3, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(60, 44);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // lblTextShowLogin
            // 
            this.lblTextShowLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextShowLogin.AutoSize = true;
            this.lblTextShowLogin.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTextShowLogin.ForeColor = System.Drawing.Color.White;
            this.lblTextShowLogin.Location = new System.Drawing.Point(69, 0);
            this.lblTextShowLogin.Name = "lblTextShowLogin";
            this.lblTextShowLogin.Size = new System.Drawing.Size(262, 50);
            this.lblTextShowLogin.TabIndex = 2;
            this.lblTextShowLogin.Text = "Ingreso empleado";
            this.lblTextShowLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.51497F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.48503F));
            this.tableLayoutPanel2.Controls.Add(this.btnRegister, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblShowID, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblShowSecurityQuestion, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblShowAnswer, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnLogin, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblShowQuestion, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtInsertID, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtInsertAnswer, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 68);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(334, 204);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblShowID
            // 
            this.lblShowID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowID.AutoSize = true;
            this.lblShowID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblShowID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShowID.Location = new System.Drawing.Point(3, 0);
            this.lblShowID.Name = "lblShowID";
            this.lblShowID.Size = new System.Drawing.Size(136, 51);
            this.lblShowID.TabIndex = 0;
            this.lblShowID.Text = "ID de empleado:";
            this.lblShowID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShowSecurityQuestion
            // 
            this.lblShowSecurityQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowSecurityQuestion.AutoSize = true;
            this.lblShowSecurityQuestion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblShowSecurityQuestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShowSecurityQuestion.Location = new System.Drawing.Point(3, 51);
            this.lblShowSecurityQuestion.Name = "lblShowSecurityQuestion";
            this.lblShowSecurityQuestion.Size = new System.Drawing.Size(136, 51);
            this.lblShowSecurityQuestion.TabIndex = 1;
            this.lblShowSecurityQuestion.Text = "Pregunta de seguridad:";
            this.lblShowSecurityQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShowAnswer
            // 
            this.lblShowAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowAnswer.AutoSize = true;
            this.lblShowAnswer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblShowAnswer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShowAnswer.Location = new System.Drawing.Point(3, 102);
            this.lblShowAnswer.Name = "lblShowAnswer";
            this.lblShowAnswer.Size = new System.Drawing.Size(136, 51);
            this.lblShowAnswer.TabIndex = 2;
            this.lblShowAnswer.Text = "Respuesta:";
            this.lblShowAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = true;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(77)))), ((int)(((byte)(188)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(3, 156);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(81, 25);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblShowQuestion
            // 
            this.lblShowQuestion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblShowQuestion.AutoSize = true;
            this.lblShowQuestion.Location = new System.Drawing.Point(145, 69);
            this.lblShowQuestion.Name = "lblShowQuestion";
            this.lblShowQuestion.Size = new System.Drawing.Size(29, 15);
            this.lblShowQuestion.TabIndex = 5;
            this.lblShowQuestion.Text = "N/A";
            // 
            // txtInsertID
            // 
            this.txtInsertID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtInsertID.Location = new System.Drawing.Point(145, 14);
            this.txtInsertID.Name = "txtInsertID";
            this.txtInsertID.Size = new System.Drawing.Size(157, 23);
            this.txtInsertID.TabIndex = 4;
            this.txtInsertID.TextChanged += new System.EventHandler(this.txtInsertID_TextChanged);
            // 
            // txtInsertAnswer
            // 
            this.txtInsertAnswer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtInsertAnswer.Location = new System.Drawing.Point(145, 116);
            this.txtInsertAnswer.Name = "txtInsertAnswer";
            this.txtInsertAnswer.Size = new System.Drawing.Size(157, 23);
            this.txtInsertAnswer.TabIndex = 6;
            // 
            // btnRegister
            // 
            this.btnRegister.AutoSize = true;
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(77)))), ((int)(((byte)(188)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(145, 156);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(166, 25);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Registrar nuevos empleados";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // IngresarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(122)))));
            this.ClientSize = new System.Drawing.Size(356, 282);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IngresarEmpleado";
            this.Text = "IngresarEmpleado";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTextShowLogin;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblShowID;
        private System.Windows.Forms.Label lblShowSecurityQuestion;
        private System.Windows.Forms.Label lblShowAnswer;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtInsertID;
        private System.Windows.Forms.Label lblShowQuestion;
        private System.Windows.Forms.TextBox txtInsertAnswer;
        private System.Windows.Forms.Button btnRegister;
    }
}