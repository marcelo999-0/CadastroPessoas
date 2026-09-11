namespace CadastroPessoas.Forms.Interface
{
    partial class Form2
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
            txtNome = new TextBox();
            txtEmail = new TextBox();
            lblNome2 = new Label();
            lblDataNasc = new Label();
            lblEmail = new Label();
            lblCPF = new Label();
            txtCPF = new MaskedTextBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            lblNumeroCasa = new Label();
            sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            DataNascimento = new MaskedTextBox();
            dgvEnderecos = new DataGridView();
            dgvTelefones = new DataGridView();
            gbEndereco = new GroupBox();
            chkPrincipalEndereco = new CheckBox();
            btnRemoverEndereco = new Button();
            listEndereco = new ListBox();
            btnAdicionarEndereco = new Button();
            cbUf = new ComboBox();
            txtComplemento = new TextBox();
            txtNumeroCasa = new MaskedTextBox();
            txtCep = new MaskedTextBox();
            txtLogradouro = new TextBox();
            txtCidade = new TextBox();
            txtBairro = new TextBox();
            lblCep = new Label();
            lblUf = new Label();
            lblComplemento = new Label();
            lblCidade = new Label();
            lblBairro = new Label();
            Logradouro = new Label();
            gbTelefones = new GroupBox();
            btnRemoverTelefone = new Button();
            btnAdicionarTelefone = new Button();
            listTelefone = new ListBox();
            cbTipo = new ComboBox();
            txtDDD = new MaskedTextBox();
            txtNumeroTelefone = new MaskedTextBox();
            lblDDD = new Label();
            lblTipo = new Label();
            lblNumeroTelefone = new Label();
            lblNome = new Label();
            chkPrincipalTelefone = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvEnderecos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTelefones).BeginInit();
            gbEndereco.SuspendLayout();
            gbTelefones.SuspendLayout();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 26);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(291, 23);
            txtNome.TabIndex = 1;
            txtNome.TextChanged += textBox1_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.Window;
            txtEmail.Location = new Point(15, 91);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(288, 23);
            txtEmail.TabIndex = 3;
            // 
            // lblNome2
            // 
            lblNome2.Location = new Point(0, 0);
            lblNome2.Name = "lblNome2";
            lblNome2.Size = new Size(100, 23);
            lblNome2.TabIndex = 8;
            // 
            // lblDataNasc
            // 
            lblDataNasc.AutoSize = true;
            lblDataNasc.Font = new Font("Trebuchet MS", 10F);
            lblDataNasc.ForeColor = Color.MidnightBlue;
            lblDataNasc.Location = new Point(358, 5);
            lblDataNasc.Name = "lblDataNasc";
            lblDataNasc.Size = new Size(135, 18);
            lblDataNasc.TabIndex = 4;
            lblDataNasc.Text = "Data de Nascimento";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Trebuchet MS", 10F);
            lblEmail.ForeColor = Color.MidnightBlue;
            lblEmail.Location = new Point(15, 70);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 18);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblCPF
            // 
            lblCPF.AutoSize = true;
            lblCPF.Font = new Font("Trebuchet MS", 10F);
            lblCPF.ForeColor = Color.MidnightBlue;
            lblCPF.Location = new Point(358, 70);
            lblCPF.Name = "lblCPF";
            lblCPF.Size = new Size(31, 18);
            lblCPF.TabIndex = 6;
            lblCPF.Text = "CPF";
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(358, 91);
            txtCPF.Mask = "000,000,000-00";
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(100, 23);
            txtCPF.TabIndex = 7;
            txtCPF.ValidatingType = typeof(DateTime);
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(15, 516);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(90, 30);
            btnSalvar.TabIndex = 26;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(150, 516);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 30);
            btnCancelar.TabIndex = 27;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // lblNumeroCasa
            // 
            lblNumeroCasa.AutoSize = true;
            lblNumeroCasa.Font = new Font("Trebuchet MS", 10F);
            lblNumeroCasa.ForeColor = Color.MidnightBlue;
            lblNumeroCasa.Location = new Point(172, 18);
            lblNumeroCasa.Name = "lblNumeroCasa";
            lblNumeroCasa.Size = new Size(17, 18);
            lblNumeroCasa.TabIndex = 0;
            lblNumeroCasa.Text = "N";
            lblNumeroCasa.Click += lblNumeroCasa_Click;
            // 
            // sqliteCommand1
            // 
            sqliteCommand1.CommandTimeout = 30;
            sqliteCommand1.Connection = null;
            sqliteCommand1.Transaction = null;
            sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // DataNascimento
            // 
            DataNascimento.Location = new Point(358, 26);
            DataNascimento.Mask = "00/00/0000";
            DataNascimento.Name = "DataNascimento";
            DataNascimento.Size = new Size(100, 23);
            DataNascimento.TabIndex = 5;
            // 
            // dgvEnderecos
            // 
            dgvEnderecos.BackgroundColor = Color.LightSteelBlue;
            dgvEnderecos.BorderStyle = BorderStyle.None;
            dgvEnderecos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnderecos.Location = new Point(15, 136);
            dgvEnderecos.Name = "dgvEnderecos";
            dgvEnderecos.Size = new Size(702, 182);
            dgvEnderecos.TabIndex = 28;
            dgvEnderecos.CellContentClick += dgvEnderecos_CellContentClick;
            // 
            // dgvTelefones
            // 
            dgvTelefones.BackgroundColor = Color.LightSteelBlue;
            dgvTelefones.BorderStyle = BorderStyle.None;
            dgvTelefones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTelefones.Location = new Point(15, 324);
            dgvTelefones.Name = "dgvTelefones";
            dgvTelefones.Size = new Size(702, 186);
            dgvTelefones.TabIndex = 29;
            dgvTelefones.CellContentClick += dgvTelefones_CellContentClick;
            // 
            // gbEndereco
            // 
            gbEndereco.BackColor = Color.LightSteelBlue;
            gbEndereco.Controls.Add(chkPrincipalEndereco);
            gbEndereco.Controls.Add(btnRemoverEndereco);
            gbEndereco.Controls.Add(listEndereco);
            gbEndereco.Controls.Add(btnAdicionarEndereco);
            gbEndereco.Controls.Add(cbUf);
            gbEndereco.Controls.Add(txtComplemento);
            gbEndereco.Controls.Add(txtNumeroCasa);
            gbEndereco.Controls.Add(txtCep);
            gbEndereco.Controls.Add(txtLogradouro);
            gbEndereco.Controls.Add(txtCidade);
            gbEndereco.Controls.Add(txtBairro);
            gbEndereco.Controls.Add(lblCep);
            gbEndereco.Controls.Add(lblUf);
            gbEndereco.Controls.Add(lblComplemento);
            gbEndereco.Controls.Add(lblCidade);
            gbEndereco.Controls.Add(lblBairro);
            gbEndereco.Controls.Add(Logradouro);
            gbEndereco.Controls.Add(lblNumeroCasa);
            gbEndereco.Location = new Point(15, 136);
            gbEndereco.Name = "gbEndereco";
            gbEndereco.Size = new Size(702, 182);
            gbEndereco.TabIndex = 30;
            gbEndereco.TabStop = false;
            gbEndereco.Text = "Endereços";
            // 
            // chkPrincipalEndereco
            // 
            chkPrincipalEndereco.AutoSize = true;
            chkPrincipalEndereco.Location = new Point(346, 135);
            chkPrincipalEndereco.Name = "chkPrincipalEndereco";
            chkPrincipalEndereco.Size = new Size(72, 19);
            chkPrincipalEndereco.TabIndex = 33;
            chkPrincipalEndereco.Text = "Principal";
            chkPrincipalEndereco.UseVisualStyleBackColor = true;
            // 
            // btnRemoverEndereco
            // 
            btnRemoverEndereco.Location = new Point(325, 79);
            btnRemoverEndereco.Name = "btnRemoverEndereco";
            btnRemoverEndereco.Size = new Size(96, 28);
            btnRemoverEndereco.TabIndex = 32;
            btnRemoverEndereco.Text = "Remover";
            btnRemoverEndereco.UseVisualStyleBackColor = true;
            btnRemoverEndereco.Click += btnRemoverEndereco_Click;
            // 
            // listEndereco
            // 
            listEndereco.FormattingEnabled = true;
            listEndereco.Location = new Point(498, 18);
            listEndereco.Name = "listEndereco";
            listEndereco.Size = new Size(198, 154);
            listEndereco.TabIndex = 9;
            listEndereco.SelectedIndexChanged += listEndereco_SelectedIndexChanged;
            // 
            // btnAdicionarEndereco
            // 
            btnAdicionarEndereco.Location = new Point(325, 34);
            btnAdicionarEndereco.Name = "btnAdicionarEndereco";
            btnAdicionarEndereco.Size = new Size(96, 28);
            btnAdicionarEndereco.TabIndex = 32;
            btnAdicionarEndereco.Text = "Adicionar";
            btnAdicionarEndereco.UseVisualStyleBackColor = true;
            btnAdicionarEndereco.Click += btnAdicionarEndereco_Click;
            // 
            // cbUf
            // 
            cbUf.FormattingEnabled = true;
            cbUf.Location = new Point(174, 86);
            cbUf.Name = "cbUf";
            cbUf.Size = new Size(121, 23);
            cbUf.TabIndex = 8;
            // 
            // txtComplemento
            // 
            txtComplemento.BackColor = SystemColors.Window;
            txtComplemento.Location = new Point(178, 131);
            txtComplemento.Name = "txtComplemento";
            txtComplemento.Size = new Size(162, 23);
            txtComplemento.TabIndex = 3;
            // 
            // txtNumeroCasa
            // 
            txtNumeroCasa.Location = new Point(172, 39);
            txtNumeroCasa.Mask = "000";
            txtNumeroCasa.Name = "txtNumeroCasa";
            txtNumeroCasa.Size = new Size(24, 23);
            txtNumeroCasa.TabIndex = 7;
            txtNumeroCasa.ValidatingType = typeof(DateTime);
            // 
            // txtCep
            // 
            txtCep.Location = new Point(202, 40);
            txtCep.Mask = "00000-000";
            txtCep.Name = "txtCep";
            txtCep.Size = new Size(81, 23);
            txtCep.TabIndex = 7;
            txtCep.ValidatingType = typeof(DateTime);
            // 
            // txtLogradouro
            // 
            txtLogradouro.BackColor = SystemColors.Window;
            txtLogradouro.Location = new Point(6, 39);
            txtLogradouro.Name = "txtLogradouro";
            txtLogradouro.Size = new Size(162, 23);
            txtLogradouro.TabIndex = 3;
            // 
            // txtCidade
            // 
            txtCidade.BackColor = SystemColors.Window;
            txtCidade.Location = new Point(6, 131);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(162, 23);
            txtCidade.TabIndex = 3;
            // 
            // txtBairro
            // 
            txtBairro.BackColor = SystemColors.Window;
            txtBairro.Location = new Point(6, 84);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(162, 23);
            txtBairro.TabIndex = 3;
            // 
            // lblCep
            // 
            lblCep.AutoSize = true;
            lblCep.Font = new Font("Trebuchet MS", 10F);
            lblCep.ForeColor = Color.MidnightBlue;
            lblCep.Location = new Point(202, 18);
            lblCep.Name = "lblCep";
            lblCep.Size = new Size(32, 18);
            lblCep.TabIndex = 0;
            lblCep.Text = "Cep";
            // 
            // lblUf
            // 
            lblUf.AutoSize = true;
            lblUf.Font = new Font("Trebuchet MS", 10F);
            lblUf.ForeColor = Color.MidnightBlue;
            lblUf.Location = new Point(178, 65);
            lblUf.Name = "lblUf";
            lblUf.Size = new Size(24, 18);
            lblUf.TabIndex = 0;
            lblUf.Text = "UF";
            // 
            // lblComplemento
            // 
            lblComplemento.AutoSize = true;
            lblComplemento.Font = new Font("Trebuchet MS", 10F);
            lblComplemento.ForeColor = Color.MidnightBlue;
            lblComplemento.Location = new Point(178, 110);
            lblComplemento.Name = "lblComplemento";
            lblComplemento.Size = new Size(95, 18);
            lblComplemento.TabIndex = 0;
            lblComplemento.Text = "Complemento";
            // 
            // lblCidade
            // 
            lblCidade.AutoSize = true;
            lblCidade.Font = new Font("Trebuchet MS", 10F);
            lblCidade.ForeColor = Color.MidnightBlue;
            lblCidade.Location = new Point(6, 110);
            lblCidade.Name = "lblCidade";
            lblCidade.Size = new Size(51, 18);
            lblCidade.TabIndex = 0;
            lblCidade.Text = "Cidade";
            // 
            // lblBairro
            // 
            lblBairro.AutoSize = true;
            lblBairro.Font = new Font("Trebuchet MS", 10F);
            lblBairro.ForeColor = Color.MidnightBlue;
            lblBairro.Location = new Point(6, 63);
            lblBairro.Name = "lblBairro";
            lblBairro.Size = new Size(45, 18);
            lblBairro.TabIndex = 0;
            lblBairro.Text = "Bairro";
            // 
            // Logradouro
            // 
            Logradouro.AutoSize = true;
            Logradouro.Font = new Font("Trebuchet MS", 10F);
            Logradouro.ForeColor = Color.MidnightBlue;
            Logradouro.Location = new Point(6, 18);
            Logradouro.Name = "Logradouro";
            Logradouro.Size = new Size(79, 18);
            Logradouro.TabIndex = 0;
            Logradouro.Text = "Logradouro";
            Logradouro.Click += lblNumeroCasa_Click;
            // 
            // gbTelefones
            // 
            gbTelefones.Controls.Add(chkPrincipalTelefone);
            gbTelefones.Controls.Add(btnRemoverTelefone);
            gbTelefones.Controls.Add(btnAdicionarTelefone);
            gbTelefones.Controls.Add(listTelefone);
            gbTelefones.Controls.Add(cbTipo);
            gbTelefones.Controls.Add(txtDDD);
            gbTelefones.Controls.Add(txtNumeroTelefone);
            gbTelefones.Controls.Add(lblDDD);
            gbTelefones.Controls.Add(lblTipo);
            gbTelefones.Controls.Add(lblNumeroTelefone);
            gbTelefones.Location = new Point(15, 324);
            gbTelefones.Name = "gbTelefones";
            gbTelefones.Size = new Size(702, 186);
            gbTelefones.TabIndex = 31;
            gbTelefones.TabStop = false;
            gbTelefones.Text = "Telefones";
            // 
            // btnRemoverTelefone
            // 
            btnRemoverTelefone.Location = new Point(178, 87);
            btnRemoverTelefone.Name = "btnRemoverTelefone";
            btnRemoverTelefone.Size = new Size(96, 28);
            btnRemoverTelefone.TabIndex = 32;
            btnRemoverTelefone.Text = "Remover";
            btnRemoverTelefone.UseVisualStyleBackColor = true;
            btnRemoverTelefone.Click += btnRemoverTelefone_Click;
            // 
            // btnAdicionarTelefone
            // 
            btnAdicionarTelefone.Location = new Point(178, 40);
            btnAdicionarTelefone.Name = "btnAdicionarTelefone";
            btnAdicionarTelefone.Size = new Size(96, 28);
            btnAdicionarTelefone.TabIndex = 32;
            btnAdicionarTelefone.Text = "Adicionar";
            btnAdicionarTelefone.UseVisualStyleBackColor = true;
            btnAdicionarTelefone.Click += btnAdicionarTelefone_Click;
            // 
            // listTelefone
            // 
            listTelefone.FormattingEnabled = true;
            listTelefone.Location = new Point(498, 12);
            listTelefone.Name = "listTelefone";
            listTelefone.Size = new Size(198, 169);
            listTelefone.TabIndex = 9;
            listTelefone.SelectedIndexChanged += listTelefone_SelectedIndexChanged;
            // 
            // cbTipo
            // 
            cbTipo.FormattingEnabled = true;
            cbTipo.Items.AddRange(new object[] { "Residencial", "Empresarial", "Celular" });
            cbTipo.Location = new Point(6, 94);
            cbTipo.Name = "cbTipo";
            cbTipo.Size = new Size(121, 23);
            cbTipo.TabIndex = 8;
            cbTipo.Text = "4";
            // 
            // txtDDD
            // 
            txtDDD.Location = new Point(6, 45);
            txtDDD.Mask = "000";
            txtDDD.Name = "txtDDD";
            txtDDD.Size = new Size(28, 23);
            txtDDD.TabIndex = 7;
            txtDDD.ValidatingType = typeof(DateTime);
            // 
            // txtNumeroTelefone
            // 
            txtNumeroTelefone.Location = new Point(46, 45);
            txtNumeroTelefone.Mask = "00000-0000";
            txtNumeroTelefone.Name = "txtNumeroTelefone";
            txtNumeroTelefone.Size = new Size(81, 23);
            txtNumeroTelefone.TabIndex = 7;
            txtNumeroTelefone.ValidatingType = typeof(DateTime);
            // 
            // lblDDD
            // 
            lblDDD.AutoSize = true;
            lblDDD.Font = new Font("Trebuchet MS", 10F);
            lblDDD.ForeColor = Color.MidnightBlue;
            lblDDD.Location = new Point(6, 24);
            lblDDD.Name = "lblDDD";
            lblDDD.Size = new Size(35, 18);
            lblDDD.TabIndex = 0;
            lblDDD.Text = "DDD";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Trebuchet MS", 10F);
            lblTipo.ForeColor = Color.MidnightBlue;
            lblTipo.Location = new Point(6, 73);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(35, 18);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo";
            lblTipo.Click += lblNumeroCasa_Click;
            // 
            // lblNumeroTelefone
            // 
            lblNumeroTelefone.AutoSize = true;
            lblNumeroTelefone.Font = new Font("Trebuchet MS", 10F);
            lblNumeroTelefone.ForeColor = Color.MidnightBlue;
            lblNumeroTelefone.Location = new Point(46, 24);
            lblNumeroTelefone.Name = "lblNumeroTelefone";
            lblNumeroTelefone.Size = new Size(57, 18);
            lblNumeroTelefone.TabIndex = 0;
            lblNumeroTelefone.Text = "Número";
            lblNumeroTelefone.Click += lblNumeroCasa_Click;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Trebuchet MS", 10F);
            lblNome.ForeColor = Color.MidnightBlue;
            lblNome.Location = new Point(12, 5);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(44, 18);
            lblNome.TabIndex = 2;
            lblNome.Text = "Nome";
            // 
            // chkPrincipalTelefone
            // 
            chkPrincipalTelefone.AutoSize = true;
            chkPrincipalTelefone.Location = new Point(343, 96);
            chkPrincipalTelefone.Name = "chkPrincipalTelefone";
            chkPrincipalTelefone.Size = new Size(72, 19);
            chkPrincipalTelefone.TabIndex = 33;
            chkPrincipalTelefone.Text = "Principal";
            chkPrincipalTelefone.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(729, 558);
            Controls.Add(gbTelefones);
            Controls.Add(txtCPF);
            Controls.Add(gbEndereco);
            Controls.Add(dgvTelefones);
            Controls.Add(dgvEnderecos);
            Controls.Add(DataNascimento);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(lblCPF);
            Controls.Add(lblNome);
            Controls.Add(lblEmail);
            Controls.Add(lblDataNasc);
            Controls.Add(lblNome2);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEnderecos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTelefones).EndInit();
            gbEndereco.ResumeLayout(false);
            gbEndereco.PerformLayout();
            gbTelefones.ResumeLayout(false);
            gbTelefones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox14;
        private Label lblNome2;
        private Label lblDataNasc;
        private Label lblEmail;
        private Label lblCPF;
        private Label txtRua;
        private MaskedTextBox txtCPF;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label lblNumeroCasa;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private MaskedTextBox DataNascimento;
        private DataGridView dgvEnderecos;
        private DataGridView dgvTelefones;
        private GroupBox gbEndereco;
        private GroupBox gbTelefones;
        private Button btnRemoverTelefone;
        private Button btnAdicionarTelefone;
        private TextBox txtBairro;
        private TextBox txtLogradouro;
        private TextBox txtCidade;
        private TextBox textBox3;
        private TextBox textBox1;
        private TextBox txtComplemento;
        private TextBox textBox6;
        private TextBox textBox5;
        private Label lblCep;
        private Label lblUf;
        private Label lblComplemento;
        private Label lblCidade;
        private Label lblBairro;
        private ComboBox cbUf;
        private MaskedTextBox txtCep;
        private ComboBox cbTipo;
        private MaskedTextBox txtDDD;
        private MaskedTextBox txtNumeroTelefone;
        private ListBox listEndereco;
        private ListBox listTelefone;
        private MaskedTextBox txtNumeroCasa;
        private Label Logradouro;
        private Label lblDDD;
        private Label lblTipo;
        private Label lblNumeroTelefone;
        private Label lblNome;
        private Button btnRemoverEndereco;
        private Button btnAdicionarEndereco;
        private CheckBox chkPrincipalEndereco;
        private CheckBox chkPrincipalTelefone;
    }
}