using CadastroPessoas.API.Controllers;
using CadastroPessoas.API.Models;
using CadastroPessoas.API.Service;

namespace CadastroPessoas.Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvHome = new DataGridView();
            programBindingSource = new BindingSource(components);
            pessoasCadastroBindingSource = new BindingSource(components);
            btnAdicionar = new Button();
            btnDeletar = new Button();
            btnEditar = new Button();
            btnConsultar = new Button();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)programBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pessoasCadastroBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvHome
            // 
            dgvHome.AutoGenerateColumns = false;
            dgvHome.BackgroundColor = SystemColors.GradientInactiveCaption;
            dgvHome.ColumnHeadersHeight = 20;
            dgvHome.DataSource = programBindingSource;
            dgvHome.Location = new Point(58, 75);
            dgvHome.Name = "dgvHome";
            dgvHome.Size = new Size(643, 322);
            dgvHome.TabIndex = 2;
            dgvHome.CellContentClick += dgvHome_CellContentClick;
            // 
            // programBindingSource
            // 
            programBindingSource.DataSource = typeof(Program);
            // 
            // pessoasCadastroBindingSource
            // 
            pessoasCadastroBindingSource.DataSource = typeof(PessoasCadastro);
            // 
            // btnAdicionar
            // 
            btnAdicionar.Font = new Font("Consolas", 8.25F);
            btnAdicionar.Location = new Point(58, 437);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(90, 30);
            btnAdicionar.TabIndex = 3;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnDeletar
            // 
            btnDeletar.Font = new Font("Consolas", 8.25F);
            btnDeletar.Location = new Point(220, 437);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new Size(90, 30);
            btnDeletar.TabIndex = 4;
            btnDeletar.Text = "Deletar";
            btnDeletar.UseVisualStyleBackColor = true;
            btnDeletar.Click += btnDeletar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Consolas", 8.25F);
            btnEditar.Location = new Point(448, 437);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(90, 30);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.Font = new Font("Consolas", 8.25F);
            btnConsultar.Location = new Point(611, 437);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(90, 30);
            btnConsultar.TabIndex = 6;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.LightSteelBlue;
            lblTitulo.Font = new Font("Consolas", 15F);
            lblTitulo.Location = new Point(260, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(233, 20);
            lblTitulo.TabIndex = 12;
            lblTitulo.Text = "CADASTRO DE PESSOAS";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(757, 479);
            Controls.Add(lblTitulo);
            Controls.Add(btnConsultar);
            Controls.Add(btnEditar);
            Controls.Add(btnDeletar);
            Controls.Add(btnAdicionar);
            Controls.Add(dgvHome);
            Name = "Form1";
            Text = "FormCadastroPessoas";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)programBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pessoasCadastroBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox1;
        private TextBox textBox2;
        private System.Windows.Forms.DataGridView dgvHome;
        private Button btnEditar;
        private Button btnDeletar;
        private Button btnAdicionar;
        private Button btnConsultar;
        private Label lblTitulo;
        private BindingSource pessoasCadastroBindingSource;
        private BindingSource programBindingSource;
    }
}
