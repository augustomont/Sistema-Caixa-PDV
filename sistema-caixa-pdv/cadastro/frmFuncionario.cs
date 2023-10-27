using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;// para utilizar o fileStream
using Org.BouncyCastle.Asn1.Cms;

namespace sistema_caixa_pdv.cadastro
{
    public partial class frmFuncionario : Form
    {
        Conexao conexao = new Conexao();
        string sql;
        MySqlCommand cmd;
        string foto;
        public frmFuncionario()
        {
            InitializeComponent();
        }
        private void frmFuncionario_Load(object sender, EventArgs e)
        {
            LimparFoto();
            Listar();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            LimparFoto();
            DesabilitarCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()))// trim para verificar se tem espaços vazios
            {
                MessageBox.Show("Preencha o nome!", "Cadastro Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = string.Empty;
                txtNome.Focus();
                return;
            }
            else if (txtCPF.Text == "   ,   .   -" || txtCPF.Text.Trim().Length < 14)
            {
                MessageBox.Show("Preencha o CPF!", "Cadastro Funcionaarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPF.Text = string.Empty;
                txtCPF.Focus();
                return;
            }
            else if (txtTelefone.Text == "(  )      -" || txtTelefone.Text.Trim().Length < 10)
            {
                MessageBox.Show("Preencha o telefone!", "Cadastro Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefone.Text = string.Empty;
                txtTelefone.Focus();
                return;
            }

            conexao.AbrirConexao();
            sql = "INSERT INTO funcionarios(nome, cpf, telefone, endereco, cargo, data, foto)" +
                "VALUES (@nome, @cpf, @telefone, @endereco, @cargo, curDate(), @foto)";
            
            cmd = new MySqlCommand(sql, conexao.conexao);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@cpf", txtCPF.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@cargo", cbCargo.Text);
            cmd.Parameters.AddWithValue("@foto", Img());//img é um metodo criado por mim para tratar imagem para o banco de dados

            cmd.ExecuteNonQuery();
            
            conexao.FecharConexao();

            LimparFoto();
            LimparCampos();
            DesabilitarCampos();

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "Arquivos(*.jpg)|*.jpg | Arquivos(*.PNG)| *.png;| All (*.*) | *.*"; //mostra uma de cada vez
            dialog.Filter = "Imagens(*.jpg; *.png) | *.jpg; *.png"; //mostra jpg e png

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foto = dialog.FileName.ToString();//pegando o caminho da imagem que foi selecionada e dado OK
                imgFoto.ImageLocation = foto; //jogando o caminho da imagem para o componente imgFoto para exibir no form

            }
        }

        private byte[] Img() //este metodo é padrao, serve sempre que deseja enviar uma imagem para banco de dados
        {
            byte[] imagem_bytes = null; //serve para eniar o comprimento da imagem
            if (string.IsNullOrEmpty(foto))//a string foto nunca deverá estar vazia, pq no metodo LimparFoto() foi passsado o caminho de uma imagem padrao (pessoa)
            {
                return null;
            }

            //usar o FileStream para enviar imagem para o BD e 3 parametros "local(foto), tipo de imagem(FileMode), tipo de acesso(FileAcess)"
            using (FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read))//isso é padrão
            using (BinaryReader br = new BinaryReader(fs))//serve para trabalhar com o FileStream
                imagem_bytes = br.ReadBytes((int)fs.Length);//pega o comprimento de FileStream jogando dentro de uma tipo IMAGEM BYTE
            {
                return imagem_bytes;
            }
        }
        private void LimparFoto()
        {
            imgFoto.Image = Properties.Resources.pessoa;// aqui coloca a imagem pessoa.png na picture do form
            foto = "img/pessoa.png"; //atribuindo um caminho de foto (esssa imagem te que estar na pasta debug)
        }
        private void LimparCampos()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtEndereco.Clear();
            txtTelefone.Clear();
            cbCargo.ResetText();//metodo Clear() não limpa os campos de uma comboBox
        }
        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtCPF.Enabled = true;
            txtEndereco.Enabled = true;
            txtTelefone.Enabled = true;
            cbCargo.Enabled = true;
            btnSalvar.Enabled = true;
            btnFoto.Enabled = true;

            btnNovo.Enabled = false;
        }
        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCPF.Enabled = false;
            txtEndereco.Enabled = false;
            txtTelefone.Enabled = false;
            cbCargo.Enabled = false;
            btnSalvar.Enabled = false;
            btnFoto.Enabled = false;
            
            btnNovo.Enabled = true;
        }
        private void Listar()
        {
            conexao.AbrirConexao();

            grid.Rows.Clear();//limpar o grid antes de preencheer
            sql = "SELECT * FROM funcionarios ORDER BY nome asc;";
            cmd = new MySqlCommand(sql, conexao.conexao);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);//Adapter serve para adaptar os dados do BD pra caber no grid. cmd serve para buscar esses dados
            DataTable dt = new DataTable(); //cria uma tabela de dados
            da.Fill(dt); //preenche a tabela com os dados adaptados no MySqlDataAdapter
            grid.DataSource = dt;//preenche o grid com todos os dados da tabela, no formato certo para o grid

            conexao.FecharConexao();
        }
    }
}
