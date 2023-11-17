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
        //variaveis globais de referencia
        Conexao conexao = new Conexao();
        string sql;
        MySqlCommand cmd;
        string foto;
        string id;
        string cpfAntigo;
        bool fotoAlterada = false;


        public frmFuncionario()
        {
            InitializeComponent();
        }
        private void frmFuncionario_Load(object sender, EventArgs e)
        {
            LimparFoto();
            grid.Rows.Clear();//limpar o grid antes de preencheer
            fotoAlterada = false;
            ListarCargos();
            Listar();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            LimparFoto();
            HabilitarCampos();
            grid.Enabled = false;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(VerificarCamposObrigatorios())
            {
                conexao.AbrirConexao();
                sql = "INSERT INTO funcionarios(nome, cpf, telefone, endereco, cargo, data, foto)" +
                    "VALUES (@nome, @cpf, @telefone, @endereco, @cargo, curDate(), @foto)";
            
                cmd = new MySqlCommand(sql, conexao.conexao);

                cmd.Parameters.Clear();

                AdicionarValoresSql();//adiciona nome, cpf, telefone, endereco, cargo
                cmd.Parameters.AddWithValue("@foto", Img());//img é um metodo para tratar imagem para o banco de dados. Imagem precisa estar em formato de Array de Bytes

                if (VerificarCpfExiste())
                {
                    return;
                }
                cmd.ExecuteNonQuery();
            
                conexao.FecharConexao();

                MessageBox.Show("Cadastro Salvo!", "Cadastro Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetar();
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            string nomeExcluido = (txtNome.Text).ToString();//Guarda o nome que será excluido, antes de apagar do BD
            DialogResult res = MessageBox.Show($"Tem certeza que deseja editar {nomeExcluido}?\n" +
               "\nNão é possivel reverter essa ação!", "Cadastro Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                if (VerificarCamposObrigatorios())
                {
                    conexao.AbrirConexao();

                    VerificarImagemAlteradaESalvar();//Salva alteriacoes feitas

                    if (VerificarCpfExiste())
                    {
                        return;
                    }

                    cmd.ExecuteNonQuery();
                    conexao.FecharConexao();
                    Listar();

                    MessageBox.Show("Registro Editado com sucesso!", "Cadastro Funcioñários", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Resetar();
                }
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Tem certeza que deseja excluir?\n" +
                "\nNão é possivel reverter essa ação!", "Cadastro Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                string nomeExcluido = (txtNome.Text).ToString();//Guarda o nome que será excluido, antes de apagar do BD
                conexao.AbrirConexao();
                cmd = new MySqlCommand("DELETE FROM funcionarios WHERE id = @id", conexao.conexao);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conexao.FecharConexao();
                Resetar();
                MessageBox.Show($"**{nomeExcluido}** excluido do cadastro de funcionários!");
            }
            else
            {
                return;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Resetar();
        }
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)//verifica se a linha exite. Isso corrige o erro de clicar em espaço vazio da grid.
            {
                HabilitarEdicao();
                PreencherCampos();
                PreencherFoto(e);//recebe argumento para verificar se o campo esta vazio
            }
            else
            {
                return;
            }

        }
        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                PreencherCampos();
                HabilitarCampos();
                HabilitarEdicao();
                
                grid.Enabled = false;
            }
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

                fotoAlterada = true;//importante informacao para verificar na hora de editar registro
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
        private void PreencherFoto(DataGridViewCellEventArgs e)
        {
            if (grid.CurrentRow.Cells[7].Value != DBNull.Value) //Verific se tem foto salva
            { 
                byte[] imagem = (byte[])grid.Rows[e.RowIndex].Cells[7].Value; //Criar array bytes[] imagem para receber a foto da tabela em bytes
                MemoryStream ms = new MemoryStream(imagem); //recebe o array byte[] ja com o valor convertido da foto
                imgFoto.Image = Image.FromStream(ms); //passando o memoryStream no objeto que ele recebe um System.Drawing e seu parameter FromStream que vai receber
            }
            else
            {
                imgFoto.Image = Properties.Resources.pessoa; //aqui insere a foto padrãodo sistema
            }
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
            btnFoto.Enabled = true;

            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;

            txtNome.Focus();
        }
        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCPF.Enabled = false;
            txtEndereco.Enabled = false;
            txtTelefone.Enabled = false;
            cbCargo.Enabled = false;
            btnFoto.Enabled = false;

            HabilitarNovo();
        }
        private void HabilitarNovo()
        {
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

        }
        private void HabilitarEdicao()
        {
            btnNovo.Enabled = false;
            btnSalvar.Enabled=false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;

        }
        private void Listar()
        {
            conexao.AbrirConexao();

            sql = "SELECT * FROM funcionarios ORDER BY nome asc;";
            cmd = new MySqlCommand(sql, conexao.conexao);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);//Adapter serve para adaptar os dados do BD pra caber no grid. cmd serve para buscar esses dados
            DataTable dt = new DataTable(); //cria uma tabela de dados
            da.Fill(dt); //preenche a tabela com os dados adaptados no MySqlDataAdapter
            grid.DataSource = dt;//preenche o grid com todos os dados da tabela, no formato certo para o grid

            FormatarGrid();

            conexao.FecharConexao();
        }
        private void ListarCargos()
        {
            conexao.AbrirConexao();
            sql = "SELECT cargo FROM cargos;";//Seleciona apenas a coluna com os dados dos cargos
            cmd = new MySqlCommand(sql, conexao.conexao);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbCargo.DataSource = dt;
            cbCargo.DisplayMember = "cargo";//Nome da coluna do banco de dados que será mostrada
            conexao.FecharConexao();
        }
        private void PreencherCampos()
        {
            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtCPF.Text = grid.CurrentRow.Cells[2].Value.ToString();
            cpfAntigo = grid.CurrentRow.Cells[2].Value.ToString();//importante para posterior verificacao de CPF existente!!!!
            txtTelefone.Text = grid.CurrentRow.Cells[3].Value.ToString();
            txtEndereco.Text = grid.CurrentRow.Cells[4].Value.ToString();
            cbCargo.Text = grid.CurrentRow.Cells[5].Value.ToString();
            
        }
        private void FormatarGrid()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Colaborador";
            grid.Columns[2].HeaderText = "CPF";
            grid.Columns[3].HeaderText = "Telefone";
            grid.Columns[4].HeaderText = "Endereço";
            grid.Columns[5].HeaderText = "Função";
            grid.Columns[6].HeaderText = "Data de Inserção";
        }
        private bool VerificarCamposObrigatorios()
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()))// trim para verificar se tem espaços vazios
            {
                MessageBox.Show("Preencha o nome!", "Cadastro Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = string.Empty;
                txtNome.Focus();
                return false;
            }
            else if (txtCPF.Text == "   ,   .   -" || txtCPF.Text.Trim().Length < 14)
            {
                MessageBox.Show("Preencha o CPF!", "Cadastro Funcionaarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPF.Text = string.Empty;
                txtCPF.Focus();
                return false;
            }
            else if (txtTelefone.Text == "(  )      -" || txtTelefone.Text.Trim().Length < 10)
            {
                MessageBox.Show("Preencha o telefone!", "Cadastro Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefone.Text = string.Empty;
                txtTelefone.Focus();
                return false;
            }
            return true;
        }
        private void VerificarImagemAlteradaESalvar()
        {
            if (fotoAlterada == true)
            {
                sql = "UPDATE funcionarios SET nome = @nome, cpf = @cpf, telefone = @telefone, endereco = @endereco, cargo = @cargo, foto = @foto " +
                    "WHERE id = @id";
                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@id", id);
                AdicionarValoresSql();
                cmd.Parameters.AddWithValue("foto", Img());
            }
            else if (fotoAlterada == false)
            {
                sql = "UPDATE funcionarios SET nome = @nome, cpf = @cpf, telefone = @telefone, endereco = @endereco, cargo = @cargo " +
                    "WHERE id = @id";
                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@id", id);
                AdicionarValoresSql();
            }
        }
        private bool VerificarCpfExiste()
        {
            if (txtCPF.Text != cpfAntigo)//Verifica se CPF é igual ao que aparece no formulario
            {
                MySqlCommand cmdVerificar = new MySqlCommand("Select * FROM funcionarios WHERE cpf = @CPF", conexao.conexao);//faz a consulta ao banco
                MySqlDataAdapter da = new MySqlDataAdapter(cmdVerificar);// é criado para executar a consulta
                cmdVerificar.Parameters.AddWithValue("@cpf", txtCPF.Text);
                DataTable dt = new DataTable();//cria uma nova tabela com essa consulta
                da.Fill(dt);//preenche a nova tabela com os valores encontrados na consulta
                if (dt.Rows.Count > 0)//verifica-se se a tabela de dados contém alguma linha. Se houver pelo menos uma linha, significa que um registro com o mesmo CPF já existe no banco de dados.
                {
                    MessageBox.Show("CPF ja registrado!", "Cadastro Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCPF.Focus();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void AdicionarValoresSql()
        {
            //id esta como auto_increment
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@cpf", txtCPF.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@cargo", cbCargo.Text);
            //img() foto são atribuidaas separadamente
        }
        private void Resetar()
        {
            LimparCampos();
            LimparFoto();
            DesabilitarCampos();
            HabilitarNovo();
            Listar();
            fotoAlterada = false;
            grid.Enabled = true;
        }

    }
}
