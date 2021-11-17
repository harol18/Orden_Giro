
namespace Usuarios_planta.Capa_presentacion
{
    partial class Asignacion_desembolso
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Btn_Ver_Desembolso = new FontAwesome.Sharp.IconButton();
            this.CmbFuncionario_Desembolso = new System.Windows.Forms.ComboBox();
            this.TxtRadicado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Asignar = new FontAwesome.Sharp.IconButton();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.lblfecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvAsignacion = new System.Windows.Forms.DataGridView();
            this.BtnVer_Asignacion = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbestado_asignacion = new System.Windows.Forms.ComboBox();
            this.dtpfecha_asignacion = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Cn", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(467, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(321, 38);
            this.label3.TabIndex = 54;
            this.label3.Text = "Asignacion Desembolso";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label6.Location = new System.Drawing.Point(38, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 280;
            this.label6.Text = "Radicado";
            // 
            // Btn_Ver_Desembolso
            // 
            this.Btn_Ver_Desembolso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.Btn_Ver_Desembolso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Ver_Desembolso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ver_Desembolso.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.Btn_Ver_Desembolso.Font = new System.Drawing.Font("Roboto Cn", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Ver_Desembolso.ForeColor = System.Drawing.Color.Gainsboro;
            this.Btn_Ver_Desembolso.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.Btn_Ver_Desembolso.IconColor = System.Drawing.Color.Gainsboro;
            this.Btn_Ver_Desembolso.IconSize = 19;
            this.Btn_Ver_Desembolso.Location = new System.Drawing.Point(551, 166);
            this.Btn_Ver_Desembolso.Name = "Btn_Ver_Desembolso";
            this.Btn_Ver_Desembolso.Rotation = 0D;
            this.Btn_Ver_Desembolso.Size = new System.Drawing.Size(149, 27);
            this.Btn_Ver_Desembolso.TabIndex = 281;
            this.Btn_Ver_Desembolso.Text = "Base Desembolso";
            this.Btn_Ver_Desembolso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Ver_Desembolso.UseVisualStyleBackColor = false;
            this.Btn_Ver_Desembolso.Click += new System.EventHandler(this.Btn_Ver_Desembolso_Click);
            // 
            // CmbFuncionario_Desembolso
            // 
            this.CmbFuncionario_Desembolso.BackColor = System.Drawing.SystemColors.Window;
            this.CmbFuncionario_Desembolso.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFuncionario_Desembolso.ForeColor = System.Drawing.Color.Black;
            this.CmbFuncionario_Desembolso.FormattingEnabled = true;
            this.CmbFuncionario_Desembolso.Location = new System.Drawing.Point(165, 166);
            this.CmbFuncionario_Desembolso.Name = "CmbFuncionario_Desembolso";
            this.CmbFuncionario_Desembolso.Size = new System.Drawing.Size(258, 27);
            this.CmbFuncionario_Desembolso.TabIndex = 284;
            // 
            // TxtRadicado
            // 
            this.TxtRadicado.BackColor = System.Drawing.SystemColors.Window;
            this.TxtRadicado.Font = new System.Drawing.Font("Roboto Cn", 11.25F);
            this.TxtRadicado.Location = new System.Drawing.Point(42, 166);
            this.TxtRadicado.Multiline = true;
            this.TxtRadicado.Name = "TxtRadicado";
            this.TxtRadicado.Size = new System.Drawing.Size(117, 27);
            this.TxtRadicado.TabIndex = 279;
            this.TxtRadicado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(161, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 285;
            this.label1.Text = "Funcionario";
            // 
            // Btn_Asignar
            // 
            this.Btn_Asignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.Btn_Asignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Asignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Asignar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.Btn_Asignar.Font = new System.Drawing.Font("Roboto Cn", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Asignar.ForeColor = System.Drawing.Color.Gainsboro;
            this.Btn_Asignar.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.Btn_Asignar.IconColor = System.Drawing.Color.Gainsboro;
            this.Btn_Asignar.IconSize = 19;
            this.Btn_Asignar.Location = new System.Drawing.Point(441, 166);
            this.Btn_Asignar.Name = "Btn_Asignar";
            this.Btn_Asignar.Rotation = 0D;
            this.Btn_Asignar.Size = new System.Drawing.Size(90, 27);
            this.Btn_Asignar.TabIndex = 286;
            this.Btn_Asignar.Text = "Asignar";
            this.Btn_Asignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Asignar.UseVisualStyleBackColor = false;
            this.Btn_Asignar.Click += new System.EventHandler(this.Btn_Asignar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Roboto Cn", 11.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Roboto Cn", 11.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDatos.Location = new System.Drawing.Point(42, 210);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.Size = new System.Drawing.Size(658, 560);
            this.dgvDatos.TabIndex = 287;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Font = new System.Drawing.Font("Roboto Cn", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lblfecha.Location = new System.Drawing.Point(976, 22);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(0, 14);
            this.lblfecha.TabIndex = 288;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.BackColor = System.Drawing.Color.Transparent;
            this.lblHora.Font = new System.Drawing.Font("Roboto Cn", 9F, System.Drawing.FontStyle.Bold);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lblHora.Location = new System.Drawing.Point(1075, 22);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(0, 14);
            this.lblHora.TabIndex = 289;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Cn", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(157)))));
            this.label2.Location = new System.Drawing.Point(237, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 29);
            this.label2.TabIndex = 290;
            this.label2.Text = "Pendientes Asignacion";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto Cn", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(157)))));
            this.label4.Location = new System.Drawing.Point(808, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(305, 29);
            this.label4.TabIndex = 291;
            this.label4.Text = "Estado Operaciones Asignadas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvAsignacion
            // 
            this.dgvAsignacion.AllowUserToAddRows = false;
            this.dgvAsignacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsignacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Roboto Cn", 11.25F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsignacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvAsignacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Roboto Cn", 11.25F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsignacion.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvAsignacion.Location = new System.Drawing.Point(730, 210);
            this.dgvAsignacion.Name = "dgvAsignacion";
            this.dgvAsignacion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvAsignacion.RowHeadersVisible = false;
            this.dgvAsignacion.Size = new System.Drawing.Size(420, 560);
            this.dgvAsignacion.TabIndex = 292;
            // 
            // BtnVer_Asignacion
            // 
            this.BtnVer_Asignacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.BtnVer_Asignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnVer_Asignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVer_Asignacion.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnVer_Asignacion.Font = new System.Drawing.Font("Roboto Cn", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVer_Asignacion.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnVer_Asignacion.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.BtnVer_Asignacion.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnVer_Asignacion.IconSize = 19;
            this.BtnVer_Asignacion.Location = new System.Drawing.Point(1081, 165);
            this.BtnVer_Asignacion.Name = "BtnVer_Asignacion";
            this.BtnVer_Asignacion.Rotation = 0D;
            this.BtnVer_Asignacion.Size = new System.Drawing.Size(64, 27);
            this.BtnVer_Asignacion.TabIndex = 293;
            this.BtnVer_Asignacion.Text = "Ver";
            this.BtnVer_Asignacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnVer_Asignacion.UseVisualStyleBackColor = false;
            this.BtnVer_Asignacion.Click += new System.EventHandler(this.BtnVer_Asignacion_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label5.Location = new System.Drawing.Point(726, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 19);
            this.label5.TabIndex = 294;
            this.label5.Text = "Seleccionar estado";
            // 
            // cmbestado_asignacion
            // 
            this.cmbestado_asignacion.BackColor = System.Drawing.SystemColors.Window;
            this.cmbestado_asignacion.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbestado_asignacion.ForeColor = System.Drawing.Color.Black;
            this.cmbestado_asignacion.FormattingEnabled = true;
            this.cmbestado_asignacion.Items.AddRange(new object[] {
            "Pendiente Desembolso",
            "Ok formalizados"});
            this.cmbestado_asignacion.Location = new System.Drawing.Point(730, 166);
            this.cmbestado_asignacion.Name = "cmbestado_asignacion";
            this.cmbestado_asignacion.Size = new System.Drawing.Size(216, 27);
            this.cmbestado_asignacion.TabIndex = 295;
            // 
            // dtpfecha_asignacion
            // 
            this.dtpfecha_asignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpfecha_asignacion.CustomFormat = "yyyy-MM-dd";
            this.dtpfecha_asignacion.Font = new System.Drawing.Font("Roboto Cn", 11.25F);
            this.dtpfecha_asignacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfecha_asignacion.Location = new System.Drawing.Point(952, 166);
            this.dtpfecha_asignacion.Name = "dtpfecha_asignacion";
            this.dtpfecha_asignacion.Size = new System.Drawing.Size(123, 26);
            this.dtpfecha_asignacion.TabIndex = 296;
            // 
            // Asignacion_desembolso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1240, 806);
            this.Controls.Add(this.dtpfecha_asignacion);
            this.Controls.Add(this.cmbestado_asignacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnVer_Asignacion);
            this.Controls.Add(this.dgvAsignacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.Btn_Asignar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbFuncionario_Desembolso);
            this.Controls.Add(this.Btn_Ver_Desembolso);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtRadicado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Asignacion_desembolso";
            this.Text = "Asignacion_desembolso";
            this.Load += new System.EventHandler(this.Asignacion_desembolso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton Btn_Ver_Desembolso;
        private System.Windows.Forms.ComboBox CmbFuncionario_Desembolso;
        private System.Windows.Forms.TextBox TxtRadicado;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton Btn_Asignar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvAsignacion;
        private FontAwesome.Sharp.IconButton BtnVer_Asignacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbestado_asignacion;
        private System.Windows.Forms.DateTimePicker dtpfecha_asignacion;
    }
}