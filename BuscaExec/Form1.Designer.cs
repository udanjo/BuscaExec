namespace BuscaExec
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnAtualiza = new System.Windows.Forms.Button();
            this.dgvModulo = new System.Windows.Forms.DataGridView();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblVersao = new System.Windows.Forms.Label();
            this.cboVersao = new System.Windows.Forms.ComboBox();
            this.grpExec = new System.Windows.Forms.GroupBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblExecutaveis = new System.Windows.Forms.Label();
            this.lstExec = new System.Windows.Forms.ListBox();
            this.lblRelease = new System.Windows.Forms.Label();
            this.txtRelease = new System.Windows.Forms.TextBox();
            this.btnMapeamento = new System.Windows.Forms.Button();
            this.lblMapeamento = new System.Windows.Forms.Label();
            this.cboMapeamento = new System.Windows.Forms.ComboBox();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.txtPesquisaModulo = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.mnuPrincipal = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuLocalOrigem = new System.Windows.Forms.MenuItem();
            this.mnuLocalDestino = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuSair = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulo)).BeginInit();
            this.grpExec.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAtualiza
            // 
            this.btnAtualiza.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAtualiza.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualiza.Image")));
            this.btnAtualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtualiza.Location = new System.Drawing.Point(8, 60);
            this.btnAtualiza.Name = "btnAtualiza";
            this.btnAtualiza.Size = new System.Drawing.Size(148, 36);
            this.btnAtualiza.TabIndex = 0;
            this.btnAtualiza.Text = "[F4] Atualizar";
            this.btnAtualiza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtualiza.UseVisualStyleBackColor = true;
            this.btnAtualiza.Click += new System.EventHandler(this.btnAtualiza_Click);
            // 
            // dgvModulo
            // 
            this.dgvModulo.AllowUserToAddRows = false;
            this.dgvModulo.AllowUserToDeleteRows = false;
            this.dgvModulo.AllowUserToOrderColumns = true;
            this.dgvModulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvModulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descricao,
            this.codigo});
            this.dgvModulo.Location = new System.Drawing.Point(0, 48);
            this.dgvModulo.Margin = new System.Windows.Forms.Padding(0);
            this.dgvModulo.MultiSelect = false;
            this.dgvModulo.Name = "dgvModulo";
            this.dgvModulo.ReadOnly = true;
            this.dgvModulo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvModulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModulo.Size = new System.Drawing.Size(200, 208);
            this.dgvModulo.TabIndex = 2;
            this.dgvModulo.Click += new System.EventHandler(this.dgvModulo_Click);
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 150;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Visible = false;
            // 
            // lblVersao
            // 
            this.lblVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVersao.Location = new System.Drawing.Point(8, 16);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(148, 13);
            this.lblVersao.TabIndex = 4;
            this.lblVersao.Text = "[CTRL+V] - Versão";
            this.lblVersao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboVersao
            // 
            this.cboVersao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVersao.FormattingEnabled = true;
            this.cboVersao.Location = new System.Drawing.Point(8, 32);
            this.cboVersao.Name = "cboVersao";
            this.cboVersao.Size = new System.Drawing.Size(148, 21);
            this.cboVersao.TabIndex = 5;
            // 
            // grpExec
            // 
            this.grpExec.Controls.Add(this.btnLimpar);
            this.grpExec.Controls.Add(this.lblExecutaveis);
            this.grpExec.Controls.Add(this.lstExec);
            this.grpExec.Controls.Add(this.lblRelease);
            this.grpExec.Controls.Add(this.txtRelease);
            this.grpExec.Controls.Add(this.btnMapeamento);
            this.grpExec.Controls.Add(this.lblMapeamento);
            this.grpExec.Controls.Add(this.cboMapeamento);
            this.grpExec.Controls.Add(this.btnExecutar);
            this.grpExec.Controls.Add(this.lblVersao);
            this.grpExec.Controls.Add(this.cboVersao);
            this.grpExec.Controls.Add(this.btnAtualiza);
            this.grpExec.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpExec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpExec.ForeColor = System.Drawing.Color.Brown;
            this.grpExec.Location = new System.Drawing.Point(205, 0);
            this.grpExec.Name = "grpExec";
            this.grpExec.Size = new System.Drawing.Size(336, 268);
            this.grpExec.TabIndex = 8;
            this.grpExec.TabStop = false;
            this.grpExec.Text = "Executável";
            // 
            // btnLimpar
            // 
            this.btnLimpar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLimpar.Location = new System.Drawing.Point(8, 140);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(148, 36);
            this.btnLimpar.TabIndex = 15;
            this.btnLimpar.Text = "[F10] Limpar Exec";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lblExecutaveis
            // 
            this.lblExecutaveis.AutoSize = true;
            this.lblExecutaveis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExecutaveis.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblExecutaveis.Location = new System.Drawing.Point(200, 60);
            this.lblExecutaveis.Name = "lblExecutaveis";
            this.lblExecutaveis.Size = new System.Drawing.Size(96, 13);
            this.lblExecutaveis.TabIndex = 14;
            this.lblExecutaveis.Text = "Lista (Executáveis)";
            // 
            // lstExec
            // 
            this.lstExec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstExec.FormattingEnabled = true;
            this.lstExec.Location = new System.Drawing.Point(200, 76);
            this.lstExec.Name = "lstExec";
            this.lstExec.Size = new System.Drawing.Size(128, 173);
            this.lstExec.TabIndex = 11;
            // 
            // lblRelease
            // 
            this.lblRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelease.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRelease.Location = new System.Drawing.Point(196, 12);
            this.lblRelease.Name = "lblRelease";
            this.lblRelease.Size = new System.Drawing.Size(128, 13);
            this.lblRelease.TabIndex = 13;
            this.lblRelease.Text = "[CTRL+R] - Release";
            this.lblRelease.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRelease
            // 
            this.txtRelease.Location = new System.Drawing.Point(196, 28);
            this.txtRelease.MaxLength = 3;
            this.txtRelease.Name = "txtRelease";
            this.txtRelease.Size = new System.Drawing.Size(128, 20);
            this.txtRelease.TabIndex = 12;
            this.txtRelease.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRelease.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRelease_KeyPress);
            // 
            // btnMapeamento
            // 
            this.btnMapeamento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMapeamento.Image = ((System.Drawing.Image)(resources.GetObject("btnMapeamento.Image")));
            this.btnMapeamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMapeamento.Location = new System.Drawing.Point(8, 224);
            this.btnMapeamento.Name = "btnMapeamento";
            this.btnMapeamento.Size = new System.Drawing.Size(148, 36);
            this.btnMapeamento.TabIndex = 10;
            this.btnMapeamento.Text = "[F6] Mapeamento";
            this.btnMapeamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMapeamento.UseVisualStyleBackColor = true;
            this.btnMapeamento.Click += new System.EventHandler(this.btnMapeamento_Click);
            // 
            // lblMapeamento
            // 
            this.lblMapeamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapeamento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMapeamento.Location = new System.Drawing.Point(8, 184);
            this.lblMapeamento.Name = "lblMapeamento";
            this.lblMapeamento.Size = new System.Drawing.Size(148, 13);
            this.lblMapeamento.TabIndex = 9;
            this.lblMapeamento.Text = "[CTRL+M] - Mapeamento";
            this.lblMapeamento.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboMapeamento
            // 
            this.cboMapeamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMapeamento.FormattingEnabled = true;
            this.cboMapeamento.Location = new System.Drawing.Point(8, 200);
            this.cboMapeamento.Name = "cboMapeamento";
            this.cboMapeamento.Size = new System.Drawing.Size(148, 21);
            this.cboMapeamento.TabIndex = 6;
            // 
            // btnExecutar
            // 
            this.btnExecutar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExecutar.Image = ((System.Drawing.Image)(resources.GetObject("btnExecutar.Image")));
            this.btnExecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecutar.Location = new System.Drawing.Point(8, 100);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(148, 36);
            this.btnExecutar.TabIndex = 8;
            this.btnExecutar.Text = "[F5] Executar";
            this.btnExecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // txtPesquisaModulo
            // 
            this.txtPesquisaModulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisaModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaModulo.Location = new System.Drawing.Point(4, 20);
            this.txtPesquisaModulo.MaxLength = 150;
            this.txtPesquisaModulo.Name = "txtPesquisaModulo";
            this.txtPesquisaModulo.Size = new System.Drawing.Size(192, 23);
            this.txtPesquisaModulo.TabIndex = 15;
            this.txtPesquisaModulo.TextChanged += new System.EventHandler(this.txtPesquisaModulo_TextChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(1, 4);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(93, 13);
            this.lblFiltro.TabIndex = 15;
            this.lblFiltro.Text = "[CTRL+F] Filtro";
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuLocalOrigem,
            this.mnuLocalDestino,
            this.menuItem2,
            this.mnuSair});
            this.menuItem1.Text = "Arquivo";
            // 
            // mnuLocalOrigem
            // 
            this.mnuLocalOrigem.Index = 0;
            this.mnuLocalOrigem.Text = "Local Origem";
            this.mnuLocalOrigem.Click += new System.EventHandler(this.mnuLocalOrigem_Click);
            // 
            // mnuLocalDestino
            // 
            this.mnuLocalDestino.Index = 1;
            this.mnuLocalDestino.Text = "Local Destino";
            this.mnuLocalDestino.Click += new System.EventHandler(this.mnuLocalDestino_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // mnuSair
            // 
            this.mnuSair.Index = 3;
            this.mnuSair.Text = "&Sair";
            this.mnuSair.Click += new System.EventHandler(this.mnuSair_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 268);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.txtPesquisaModulo);
            this.Controls.Add(this.grpExec);
            this.Controls.Add(this.dgvModulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Menu = this.mnuPrincipal;
            this.Name = "Main";
            this.Text = "Atualização de Modulo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulo)).EndInit();
            this.grpExec.ResumeLayout(false);
            this.grpExec.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtualiza;
        private System.Windows.Forms.DataGridView dgvModulo;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.ComboBox cboVersao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.GroupBox grpExec;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.Button btnMapeamento;
        private System.Windows.Forms.Label lblMapeamento;
        private System.Windows.Forms.ComboBox cboMapeamento;
        private System.Windows.Forms.Label lblRelease;
        private System.Windows.Forms.TextBox txtRelease;
        private System.Windows.Forms.Label lblExecutaveis;
        private System.Windows.Forms.ListBox lstExec;
        private System.Windows.Forms.TextBox txtPesquisaModulo;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.MainMenu mnuPrincipal;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuLocalOrigem;
        private System.Windows.Forms.MenuItem mnuLocalDestino;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuSair;
        private System.Windows.Forms.Button btnLimpar;
    }
}

