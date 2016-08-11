namespace UI.Desktop
{
    partial class FormularioBaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioBaja));
            this.tlBaja = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtBorrar = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.tlBaja.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlBaja
            // 
            this.tlBaja.ColumnCount = 2;
            this.tlBaja.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlBaja.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlBaja.Controls.Add(this.label1, 0, 0);
            this.tlBaja.Controls.Add(this.btnAceptar, 0, 3);
            this.tlBaja.Controls.Add(this.btnCancelar, 1, 3);
            this.tlBaja.Controls.Add(this.txtBorrar, 1, 1);
            this.tlBaja.Controls.Add(this.labelUsuario, 0, 1);
            this.tlBaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlBaja.Location = new System.Drawing.Point(0, 0);
            this.tlBaja.Name = "tlBaja";
            this.tlBaja.RowCount = 4;
            this.tlBaja.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlBaja.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlBaja.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlBaja.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlBaja.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlBaja.Size = new System.Drawing.Size(576, 260);
            this.tlBaja.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tlBaja.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese BORRAR para confirmar la baja:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(106, 216);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(394, 216);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtBorrar
            // 
            this.txtBorrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlBaja.SetColumnSpan(this.txtBorrar, 2);
            this.txtBorrar.Location = new System.Drawing.Point(182, 152);
            this.txtBorrar.Name = "txtBorrar";
            this.txtBorrar.Size = new System.Drawing.Size(212, 20);
            this.txtBorrar.TabIndex = 1;
            this.txtBorrar.TextChanged += new System.EventHandler(this.txtBorrar_TextChanged);
            // 
            // labelUsuario
            // 
            this.labelUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelUsuario.AutoSize = true;
            this.tlBaja.SetColumnSpan(this.labelUsuario, 2);
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(262, 87);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(51, 20);
            this.labelUsuario.TabIndex = 4;
            this.labelUsuario.Text = "label2";
            // 
            // FormularioBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 260);
            this.Controls.Add(this.tlBaja);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormularioBaja";
            this.Text = "Confirmar Baja";
            this.tlBaja.ResumeLayout(false);
            this.tlBaja.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlBaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBorrar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label labelUsuario;
    }
}