namespace SMC.PresentationLayer
{
    partial class FormaMenu
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCambiarClave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstados = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpcionesOrdenes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrdenes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPersonalizar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAcercaSistemaClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBarraHerramientas = new System.Windows.Forms.ToolStrip();
            this.tsbCambiarClave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClientes = new System.Windows.Forms.ToolStripButton();
            this.tsbProductos = new System.Windows.Forms.ToolStripButton();
            this.tsbOpcionesOrdenes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOrdenes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpciones = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbIndice = new System.Windows.Forms.ToolStripButton();
            this.mnuMenuPrincipal.SuspendLayout();
            this.tsBarraHerramientas.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMenuPrincipal
            // 
            this.mnuMenuPrincipal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mnuMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSistema,
            this.mnuMantenimiento,
            this.mnuProcesos,
            this.mnuHerramientas,
            this.mnuAyuda});
            this.mnuMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuMenuPrincipal.Name = "mnuMenuPrincipal";
            this.mnuMenuPrincipal.Size = new System.Drawing.Size(516, 24);
            this.mnuMenuPrincipal.TabIndex = 1;
            this.mnuMenuPrincipal.Text = "menuStrip1";
            // 
            // mnuSistema
            // 
            this.mnuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCambiarClave,
            this.toolStripMenuItem1,
            this.mnuSalir});
            this.mnuSistema.Name = "mnuSistema";
            this.mnuSistema.Size = new System.Drawing.Size(60, 20);
            this.mnuSistema.Text = "&Sistema";
            // 
            // mnuCambiarClave
            // 
            this.mnuCambiarClave.Image = global::SMC.PresentationLayer.Properties.Resources.CambiarClave;
            this.mnuCambiarClave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCambiarClave.Name = "mnuCambiarClave";
            this.mnuCambiarClave.Size = new System.Drawing.Size(165, 38);
            this.mnuCambiarClave.Text = "&Cambiar clave";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Image = global::SMC.PresentationLayer.Properties.Resources.Salir;
            this.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSalir.Size = new System.Drawing.Size(165, 38);
            this.mnuSalir.Text = "Sa&lir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuMantenimiento
            // 
            this.mnuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClientes,
            this.mnuProductos,
            this.mnuEstados,
            this.toolStripMenuItem3,
            this.mnuOpcionesOrdenes});
            this.mnuMantenimiento.Name = "mnuMantenimiento";
            this.mnuMantenimiento.Size = new System.Drawing.Size(101, 20);
            this.mnuMantenimiento.Text = "&Mantenimiento";
            // 
            // mnuClientes
            // 
            this.mnuClientes.Image = global::SMC.PresentationLayer.Properties.Resources.Clientes;
            this.mnuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuClientes.Name = "mnuClientes";
            this.mnuClientes.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuClientes.Size = new System.Drawing.Size(201, 38);
            this.mnuClientes.Text = "&Clientes";
            this.mnuClientes.Click += new System.EventHandler(this.mnuClientes_Click);
            // 
            // mnuProductos
            // 
            this.mnuProductos.Image = global::SMC.PresentationLayer.Properties.Resources.Productos;
            this.mnuProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuProductos.Name = "mnuProductos";
            this.mnuProductos.Size = new System.Drawing.Size(201, 38);
            this.mnuProductos.Text = "&Productos";
            // 
            // mnuEstados
            // 
            this.mnuEstados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuEstados.Name = "mnuEstados";
            this.mnuEstados.Size = new System.Drawing.Size(201, 38);
            this.mnuEstados.Text = "&Estados";
            this.mnuEstados.Click += new System.EventHandler(this.mnuEstados_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuOpcionesOrdenes
            // 
            this.mnuOpcionesOrdenes.Image = global::SMC.PresentationLayer.Properties.Resources.OpcionesOrdenes;
            this.mnuOpcionesOrdenes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuOpcionesOrdenes.Name = "mnuOpcionesOrdenes";
            this.mnuOpcionesOrdenes.Size = new System.Drawing.Size(201, 38);
            this.mnuOpcionesOrdenes.Text = "&Opciones de órdenes";
            // 
            // mnuProcesos
            // 
            this.mnuProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOrdenes});
            this.mnuProcesos.Name = "mnuProcesos";
            this.mnuProcesos.Size = new System.Drawing.Size(66, 20);
            this.mnuProcesos.Text = "&Procesos";
            // 
            // mnuOrdenes
            // 
            this.mnuOrdenes.Image = global::SMC.PresentationLayer.Properties.Resources.Ordenes;
            this.mnuOrdenes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuOrdenes.Name = "mnuOrdenes";
            this.mnuOrdenes.Size = new System.Drawing.Size(134, 38);
            this.mnuOrdenes.Text = "&Ordenes";
            // 
            // mnuHerramientas
            // 
            this.mnuHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPersonalizar,
            this.mnuOpciones});
            this.mnuHerramientas.Name = "mnuHerramientas";
            this.mnuHerramientas.Size = new System.Drawing.Size(90, 20);
            this.mnuHerramientas.Text = "&Herramientas";
            // 
            // mnuPersonalizar
            // 
            this.mnuPersonalizar.Name = "mnuPersonalizar";
            this.mnuPersonalizar.Size = new System.Drawing.Size(153, 38);
            this.mnuPersonalizar.Text = "&Personalizar";
            // 
            // mnuOpciones
            // 
            this.mnuOpciones.Image = global::SMC.PresentationLayer.Properties.Resources.Opciones;
            this.mnuOpciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuOpciones.Name = "mnuOpciones";
            this.mnuOpciones.Size = new System.Drawing.Size(153, 38);
            this.mnuOpciones.Text = "&Opciones";
            // 
            // mnuAyuda
            // 
            this.mnuAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIndice,
            this.mnuBuscar,
            this.toolStripMenuItem2,
            this.mnuAcercaSistemaClientes});
            this.mnuAyuda.Name = "mnuAyuda";
            this.mnuAyuda.Size = new System.Drawing.Size(53, 20);
            this.mnuAyuda.Text = "&Ayuda";
            // 
            // mnuIndice
            // 
            this.mnuIndice.Image = global::SMC.PresentationLayer.Properties.Resources.AyudaIndice;
            this.mnuIndice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuIndice.Name = "mnuIndice";
            this.mnuIndice.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuIndice.Size = new System.Drawing.Size(247, 38);
            this.mnuIndice.Text = "&Indice";
            // 
            // mnuBuscar
            // 
            this.mnuBuscar.Name = "mnuBuscar";
            this.mnuBuscar.Size = new System.Drawing.Size(247, 38);
            this.mnuBuscar.Text = "&Buscar";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(244, 6);
            // 
            // mnuAcercaSistemaClientes
            // 
            this.mnuAcercaSistemaClientes.Name = "mnuAcercaSistemaClientes";
            this.mnuAcercaSistemaClientes.Size = new System.Drawing.Size(247, 38);
            this.mnuAcercaSistemaClientes.Text = "Acerca del &sistema de clientes";
            // 
            // tsBarraHerramientas
            // 
            this.tsBarraHerramientas.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tsBarraHerramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCambiarClave,
            this.toolStripSeparator1,
            this.tsbClientes,
            this.tsbProductos,
            this.tsbOpcionesOrdenes,
            this.toolStripSeparator2,
            this.tsbOrdenes,
            this.toolStripSeparator3,
            this.tsbOpciones,
            this.toolStripSeparator4,
            this.tsbIndice});
            this.tsBarraHerramientas.Location = new System.Drawing.Point(0, 24);
            this.tsBarraHerramientas.Name = "tsBarraHerramientas";
            this.tsBarraHerramientas.Size = new System.Drawing.Size(516, 39);
            this.tsBarraHerramientas.TabIndex = 2;
            this.tsBarraHerramientas.Text = "toolStrip1";
            // 
            // tsbCambiarClave
            // 
            this.tsbCambiarClave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCambiarClave.Image = global::SMC.PresentationLayer.Properties.Resources.CambiarClave;
            this.tsbCambiarClave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCambiarClave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCambiarClave.Name = "tsbCambiarClave";
            this.tsbCambiarClave.Size = new System.Drawing.Size(36, 36);
            this.tsbCambiarClave.Text = "Cambiar clave";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbClientes
            // 
            this.tsbClientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClientes.Image = global::SMC.PresentationLayer.Properties.Resources.Clientes;
            this.tsbClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClientes.Name = "tsbClientes";
            this.tsbClientes.Size = new System.Drawing.Size(36, 36);
            this.tsbClientes.Text = "Clientes";
            this.tsbClientes.Click += new System.EventHandler(this.tsbClientes_Click);
            // 
            // tsbProductos
            // 
            this.tsbProductos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProductos.Image = global::SMC.PresentationLayer.Properties.Resources.Productos;
            this.tsbProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbProductos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProductos.Name = "tsbProductos";
            this.tsbProductos.Size = new System.Drawing.Size(28, 36);
            this.tsbProductos.Text = "Productos";
            // 
            // tsbOpcionesOrdenes
            // 
            this.tsbOpcionesOrdenes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpcionesOrdenes.Image = global::SMC.PresentationLayer.Properties.Resources.OpcionesOrdenes;
            this.tsbOpcionesOrdenes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOpcionesOrdenes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpcionesOrdenes.Name = "tsbOpcionesOrdenes";
            this.tsbOpcionesOrdenes.Size = new System.Drawing.Size(36, 36);
            this.tsbOpcionesOrdenes.Text = "Opciones de órdenes";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbOrdenes
            // 
            this.tsbOrdenes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOrdenes.Image = global::SMC.PresentationLayer.Properties.Resources.Ordenes;
            this.tsbOrdenes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOrdenes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOrdenes.Name = "tsbOrdenes";
            this.tsbOrdenes.Size = new System.Drawing.Size(36, 36);
            this.tsbOrdenes.Text = "Ordenes";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbOpciones
            // 
            this.tsbOpciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpciones.Image = global::SMC.PresentationLayer.Properties.Resources.Opciones;
            this.tsbOpciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOpciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpciones.Name = "tsbOpciones";
            this.tsbOpciones.Size = new System.Drawing.Size(36, 36);
            this.tsbOpciones.Text = "Opciones";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbIndice
            // 
            this.tsbIndice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbIndice.Image = global::SMC.PresentationLayer.Properties.Resources.AyudaIndice;
            this.tsbIndice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbIndice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIndice.Name = "tsbIndice";
            this.tsbIndice.Size = new System.Drawing.Size(36, 36);
            this.tsbIndice.Text = "Indice";
            // 
            // FormaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(516, 315);
            this.Controls.Add(this.tsBarraHerramientas);
            this.Controls.Add(this.mnuMenuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMenuPrincipal;
            this.Name = "FormaMenu";
            this.Text = "Sistema de mantenimiento de clientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormaMenu_FormClosing);
            this.Load += new System.EventHandler(this.FormaMenu_Load);
            this.mnuMenuPrincipal.ResumeLayout(false);
            this.mnuMenuPrincipal.PerformLayout();
            this.tsBarraHerramientas.ResumeLayout(false);
            this.tsBarraHerramientas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuSistema;
        private System.Windows.Forms.ToolStripMenuItem mnuCambiarClave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem mnuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem mnuClientes;
        private System.Windows.Forms.ToolStripMenuItem mnuProductos;
        private System.Windows.Forms.ToolStripMenuItem mnuEstados;
        private System.Windows.Forms.ToolStripMenuItem mnuOpcionesOrdenes;
        private System.Windows.Forms.ToolStripMenuItem mnuProcesos;
        private System.Windows.Forms.ToolStripMenuItem mnuOrdenes;
        private System.Windows.Forms.ToolStripMenuItem mnuHerramientas;
        private System.Windows.Forms.ToolStripMenuItem mnuPersonalizar;
        private System.Windows.Forms.ToolStripMenuItem mnuOpciones;
        private System.Windows.Forms.ToolStripMenuItem mnuAyuda;
        private System.Windows.Forms.ToolStripMenuItem mnuIndice;
        private System.Windows.Forms.ToolStripMenuItem mnuBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuAcercaSistemaClientes;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStrip tsBarraHerramientas;
        private System.Windows.Forms.ToolStripButton tsbCambiarClave;
        private System.Windows.Forms.ToolStripButton tsbClientes;
        private System.Windows.Forms.ToolStripButton tsbProductos;
        private System.Windows.Forms.ToolStripButton tsbOpcionesOrdenes;
        private System.Windows.Forms.ToolStripButton tsbOrdenes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbOpciones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbIndice;
    }
}
