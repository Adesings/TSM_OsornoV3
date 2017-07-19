namespace RegistroCamiones
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.label1 = new System.Windows.Forms.Label();
            this.btnagregar = new System.Windows.Forms.Button();
            this.btnactualizar = new System.Windows.Forms.Button();
            this.btnnuevaorden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Transportes Santa Maria Base Osorno";
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.Color.Teal;
            this.btnagregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnagregar.FlatAppearance.BorderSize = 2;
            this.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnagregar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnagregar.Image = ((System.Drawing.Image)(resources.GetObject("btnagregar.Image")));
            this.btnagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnagregar.Location = new System.Drawing.Point(124, 195);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(261, 33);
            this.btnagregar.TabIndex = 3;
            this.btnagregar.Text = "Agregar Equipo a la Flota";
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // btnactualizar
            // 
            this.btnactualizar.BackColor = System.Drawing.Color.Teal;
            this.btnactualizar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnactualizar.FlatAppearance.BorderSize = 2;
            this.btnactualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnactualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnactualizar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnactualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnactualizar.Image")));
            this.btnactualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnactualizar.Location = new System.Drawing.Point(124, 245);
            this.btnactualizar.Name = "btnactualizar";
            this.btnactualizar.Size = new System.Drawing.Size(261, 33);
            this.btnactualizar.TabIndex = 2;
            this.btnactualizar.Text = "Actualizar Equipo a la Flota";
            this.btnactualizar.UseVisualStyleBackColor = false;
            this.btnactualizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnnuevaorden
            // 
            this.btnnuevaorden.BackColor = System.Drawing.Color.Teal;
            this.btnnuevaorden.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnnuevaorden.FlatAppearance.BorderSize = 2;
            this.btnnuevaorden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnuevaorden.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnuevaorden.ForeColor = System.Drawing.SystemColors.Window;
            this.btnnuevaorden.Image = ((System.Drawing.Image)(resources.GetObject("btnnuevaorden.Image")));
            this.btnnuevaorden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnuevaorden.Location = new System.Drawing.Point(124, 138);
            this.btnnuevaorden.Name = "btnnuevaorden";
            this.btnnuevaorden.Size = new System.Drawing.Size(261, 33);
            this.btnnuevaorden.TabIndex = 1;
            this.btnnuevaorden.Text = "Registrar una Nueva Orden";
            this.btnnuevaorden.UseVisualStyleBackColor = false;
            this.btnnuevaorden.Click += new System.EventHandler(this.btnnuevaorden_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 514);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.btnactualizar);
            this.Controls.Add(this.btnnuevaorden);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenido";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnnuevaorden;
        private System.Windows.Forms.Button btnactualizar;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Label label1;
    }
}

