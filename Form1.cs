using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjTblContatos
{
    public partial class Form1 : Form
    {
        ClasseConexao con;
        DataTable dt;
        int pos = 0;
        int qtde = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void mostrarDados(int pos)
        {
            txtId.Text = dt.Rows[pos]["id"].ToString();
            txtNome.Text = dt.Rows[pos]["nome"].ToString();
            txtFone.Text = dt.Rows[pos]["fone"].ToString();
            txtStatus.Text = dt.Rows[pos]["status"].ToString();
            txtData.Text = dt.Rows[pos]["data_inc"].ToString();
            txtValor.Text = dt.Rows[pos]["valor"].ToString();

            if (txtStatus.Text == "I")
            {
                chkBox.Checked = true;
            }
            else
            {
                chkBox.Checked = false;
            }
        }

        private void consultarDados(String sql)
        {
            con = new ClasseConexao();
            dt = new DataTable();
            dt = con.executarSQL(sql);
            qtde = dt.Rows.Count;
            mostrarDados(0);
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            consultarDados("select * from tbl_contatos");
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos >= qtde - 1)
                pos = qtde - 1;
            mostrarDados(pos);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos < 0)
                pos = 0;
            mostrarDados(pos);
        }

        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            String t0 = txtId.Text;
            con = new ClasseConexao();
            con.executarSQL("DELETE FROM tbl_contatos WHERE id = '" + t0 + "'");
            consultarDados("select * from tbl_contatos");
            MessageBox.Show("Deletado com sucesso!");
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            String t1 = txtNome.Text, t2 = txtFone.Text, t3 = txtStatus.Text, t4 = txtData.Text, t5 = txtValor.Text;
            t5 = t5.Replace(",", ".");
            con = new ClasseConexao();
            String x = "insert into tbl_contatos values('" + t1 + "', '" + t2 + "', '" + t3 + "', '" + t4 + "', " + t5 + ") ";
            MessageBox.Show(x);
            con.executarSQL(x); 
            consultarDados("select * from tbl_contatos");
            MessageBox.Show("Incluído com sucesso!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            String t0= txtId.Text ,t1 = txtNome.Text, t2 = txtFone.Text, t3 = txtStatus.Text, t4 = txtData.Text, t5 = txtValor.Text;
            t5 = t5.Replace(",", ".");
            con = new ClasseConexao();
            String x = "UPDATE tbl_contatos SET Nome = '" + t1 +"', fone = '" + t2 + "', status = '" + t3 + "', data_inc = '" +t4 + "', valor = " + t5 + " WHERE id = '" + t0 + "' ";
            MessageBox.Show(x);
            con.executarSQL(x);
            consultarDados("select * from tbl_contatos");
            MessageBox.Show("Atualizado com sucesso!");
        }
    }
}
