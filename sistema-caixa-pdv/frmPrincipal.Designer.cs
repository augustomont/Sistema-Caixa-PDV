namespace sistema_caixa_pdv
{
    partial class frmPrincipal
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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroCargos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProdutosProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProdutosEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovimentacao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovimentacaoFluxoCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovimentacaoLancarVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovimentacaoEntradaSaida = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovimentacaoDespesas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorioProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorioVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorioMovimentos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorioEntradasSaidas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorioDespesas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.img03 = new System.Windows.Forms.PictureBox();
            this.img04 = new System.Windows.Forms.PictureBox();
            this.img02 = new System.Windows.Forms.PictureBox();
            this.img01 = new System.Windows.Forms.PictureBox();
            this.menuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img01)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.BackColor = System.Drawing.SystemColors.Info;
            this.menuPrincipal.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastro,
            this.menuProdutos,
            this.menuMovimentacao,
            this.menuRelatorio,
            this.menuSair});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(800, 33);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // menuCadastro
            // 
            this.menuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroFuncionario,
            this.menuCadastroClientes,
            this.menuCadastroUsuarios,
            this.menuCadastroCargos,
            this.menuCadastroFornecedores});
            this.menuCadastro.Name = "menuCadastro";
            this.menuCadastro.Size = new System.Drawing.Size(99, 29);
            this.menuCadastro.Text = "Cadastro";
            // 
            // menuCadastroFuncionario
            // 
            this.menuCadastroFuncionario.Name = "menuCadastroFuncionario";
            this.menuCadastroFuncionario.Size = new System.Drawing.Size(270, 34);
            this.menuCadastroFuncionario.Text = "Funcionários";
            this.menuCadastroFuncionario.Click += new System.EventHandler(this.menuCadastroFuncionario_Click);
            // 
            // menuCadastroClientes
            // 
            this.menuCadastroClientes.Name = "menuCadastroClientes";
            this.menuCadastroClientes.Size = new System.Drawing.Size(270, 34);
            this.menuCadastroClientes.Text = "Clientes";
            this.menuCadastroClientes.Click += new System.EventHandler(this.menuCadastroClientes_Click);
            // 
            // menuCadastroUsuarios
            // 
            this.menuCadastroUsuarios.Name = "menuCadastroUsuarios";
            this.menuCadastroUsuarios.Size = new System.Drawing.Size(270, 34);
            this.menuCadastroUsuarios.Text = "Usuários";
            // 
            // menuCadastroCargos
            // 
            this.menuCadastroCargos.Name = "menuCadastroCargos";
            this.menuCadastroCargos.Size = new System.Drawing.Size(270, 34);
            this.menuCadastroCargos.Text = "Cargos";
            this.menuCadastroCargos.Click += new System.EventHandler(this.menuCadastroCargos_Click);
            // 
            // menuCadastroFornecedores
            // 
            this.menuCadastroFornecedores.Name = "menuCadastroFornecedores";
            this.menuCadastroFornecedores.Size = new System.Drawing.Size(270, 34);
            this.menuCadastroFornecedores.Text = "Fornecedores";
            // 
            // menuProdutos
            // 
            this.menuProdutos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProdutosProdutos,
            this.menuProdutosEstoque});
            this.menuProdutos.Name = "menuProdutos";
            this.menuProdutos.Size = new System.Drawing.Size(101, 29);
            this.menuProdutos.Text = "Produtos";
            // 
            // menuProdutosProdutos
            // 
            this.menuProdutosProdutos.Name = "menuProdutosProdutos";
            this.menuProdutosProdutos.Size = new System.Drawing.Size(187, 34);
            this.menuProdutosProdutos.Text = "Produtos";
            // 
            // menuProdutosEstoque
            // 
            this.menuProdutosEstoque.Name = "menuProdutosEstoque";
            this.menuProdutosEstoque.Size = new System.Drawing.Size(187, 34);
            this.menuProdutosEstoque.Text = "Estoque";
            // 
            // menuMovimentacao
            // 
            this.menuMovimentacao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMovimentacaoFluxoCaixa,
            this.menuMovimentacaoLancarVenda,
            this.menuMovimentacaoEntradaSaida,
            this.menuMovimentacaoDespesas});
            this.menuMovimentacao.Name = "menuMovimentacao";
            this.menuMovimentacao.Size = new System.Drawing.Size(154, 29);
            this.menuMovimentacao.Text = "Movimentações";
            // 
            // menuMovimentacaoFluxoCaixa
            // 
            this.menuMovimentacaoFluxoCaixa.Name = "menuMovimentacaoFluxoCaixa";
            this.menuMovimentacaoFluxoCaixa.Size = new System.Drawing.Size(250, 34);
            this.menuMovimentacaoFluxoCaixa.Text = "Fluxo Caixa";
            // 
            // menuMovimentacaoLancarVenda
            // 
            this.menuMovimentacaoLancarVenda.Name = "menuMovimentacaoLancarVenda";
            this.menuMovimentacaoLancarVenda.Size = new System.Drawing.Size(250, 34);
            this.menuMovimentacaoLancarVenda.Text = "Lançar Venda";
            // 
            // menuMovimentacaoEntradaSaida
            // 
            this.menuMovimentacaoEntradaSaida.Name = "menuMovimentacaoEntradaSaida";
            this.menuMovimentacaoEntradaSaida.Size = new System.Drawing.Size(250, 34);
            this.menuMovimentacaoEntradaSaida.Text = "Entradas / Saidas";
            // 
            // menuMovimentacaoDespesas
            // 
            this.menuMovimentacaoDespesas.Name = "menuMovimentacaoDespesas";
            this.menuMovimentacaoDespesas.Size = new System.Drawing.Size(250, 34);
            this.menuMovimentacaoDespesas.Text = "Despesas";
            // 
            // menuRelatorio
            // 
            this.menuRelatorio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRelatorioProdutos,
            this.menuRelatorioVendas,
            this.menuRelatorioMovimentos,
            this.menuRelatorioEntradasSaidas,
            this.menuRelatorioDespesas});
            this.menuRelatorio.Name = "menuRelatorio";
            this.menuRelatorio.Size = new System.Drawing.Size(98, 29);
            this.menuRelatorio.Text = "Relatório";
            // 
            // menuRelatorioProdutos
            // 
            this.menuRelatorioProdutos.Name = "menuRelatorioProdutos";
            this.menuRelatorioProdutos.Size = new System.Drawing.Size(250, 34);
            this.menuRelatorioProdutos.Text = "Produtos";
            // 
            // menuRelatorioVendas
            // 
            this.menuRelatorioVendas.Name = "menuRelatorioVendas";
            this.menuRelatorioVendas.Size = new System.Drawing.Size(250, 34);
            this.menuRelatorioVendas.Text = "Vendas";
            // 
            // menuRelatorioMovimentos
            // 
            this.menuRelatorioMovimentos.Name = "menuRelatorioMovimentos";
            this.menuRelatorioMovimentos.Size = new System.Drawing.Size(250, 34);
            this.menuRelatorioMovimentos.Text = "Movimentos";
            // 
            // menuRelatorioEntradasSaidas
            // 
            this.menuRelatorioEntradasSaidas.Name = "menuRelatorioEntradasSaidas";
            this.menuRelatorioEntradasSaidas.Size = new System.Drawing.Size(250, 34);
            this.menuRelatorioEntradasSaidas.Text = "Entradas / Saidas";
            // 
            // menuRelatorioDespesas
            // 
            this.menuRelatorioDespesas.Name = "menuRelatorioDespesas";
            this.menuRelatorioDespesas.Size = new System.Drawing.Size(250, 34);
            this.menuRelatorioDespesas.Text = "Despesas";
            // 
            // menuSair
            // 
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(53, 29);
            this.menuSair.Text = "Sar";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // img03
            // 
            this.img03.Image = global::sistema_caixa_pdv.Properties.Resources.movimentacao;
            this.img03.Location = new System.Drawing.Point(99, 270);
            this.img03.Name = "img03";
            this.img03.Size = new System.Drawing.Size(178, 139);
            this.img03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img03.TabIndex = 4;
            this.img03.TabStop = false;
            // 
            // img04
            // 
            this.img04.Image = global::sistema_caixa_pdv.Properties.Resources.despesas;
            this.img04.Location = new System.Drawing.Point(332, 270);
            this.img04.Name = "img04";
            this.img04.Size = new System.Drawing.Size(177, 139);
            this.img04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img04.TabIndex = 3;
            this.img04.TabStop = false;
            // 
            // img02
            // 
            this.img02.Image = global::sistema_caixa_pdv.Properties.Resources.carrinho;
            this.img02.Location = new System.Drawing.Point(332, 79);
            this.img02.Name = "img02";
            this.img02.Size = new System.Drawing.Size(177, 153);
            this.img02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img02.TabIndex = 2;
            this.img02.TabStop = false;
            // 
            // img01
            // 
            this.img01.Image = global::sistema_caixa_pdv.Properties.Resources.sacola;
            this.img01.Location = new System.Drawing.Point(99, 79);
            this.img01.Name = "img01";
            this.img01.Size = new System.Drawing.Size(178, 153);
            this.img01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img01.TabIndex = 1;
            this.img01.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.img03);
            this.Controls.Add(this.img04);
            this.Controls.Add(this.img02);
            this.Controls.Add(this.img01);
            this.Controls.Add(this.menuPrincipal);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuCadastro;
        private System.Windows.Forms.ToolStripMenuItem menuProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuMovimentacao;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorio;
        private System.Windows.Forms.PictureBox img01;
        private System.Windows.Forms.PictureBox img02;
        private System.Windows.Forms.PictureBox img04;
        private System.Windows.Forms.PictureBox img03;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroClientes;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroCargos;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroFornecedores;
        private System.Windows.Forms.ToolStripMenuItem menuProdutosProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuProdutosEstoque;
        private System.Windows.Forms.ToolStripMenuItem menuMovimentacaoFluxoCaixa;
        private System.Windows.Forms.ToolStripMenuItem menuMovimentacaoLancarVenda;
        private System.Windows.Forms.ToolStripMenuItem menuMovimentacaoEntradaSaida;
        private System.Windows.Forms.ToolStripMenuItem menuMovimentacaoDespesas;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorioProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorioVendas;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorioMovimentos;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorioEntradasSaidas;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorioDespesas;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
    }
}

