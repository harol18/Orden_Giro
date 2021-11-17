using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Usuarios_planta.Capa_presentacion
{
    public partial class Asignacion_desembolso : Form
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");
        Comandos cmds = new Comandos();
        public Asignacion_desembolso()
        {
            InitializeComponent();
            Cargar_Funcionarios();
        }

            public void Cargar_Funcionarios()
        {
            con.Open();
            string query = "SELECT Nombre from tf_usuarios where Area= 'Desembolso' order by Nombre desc";
            MySqlCommand comando = new MySqlCommand(query, con);
            MySqlDataAdapter da1 = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            DataRow fila = dt.NewRow();
            fila["Nombre"] = "";
            dt.Rows.InsertAt(fila, 0);
            CmbFuncionario_Desembolso.ValueMember = "Nombre";
            CmbFuncionario_Desembolso.DisplayMember = "Nombre";
            CmbFuncionario_Desembolso.DataSource = dt;
        }

        DateTime fecha = DateTime.Now;
        private void Asignacion_desembolso_Load(object sender, EventArgs e)
        {
            lblfecha.Text = fecha.ToString("yyyy-MM-dd");
            timer1.Enabled = true;
        }

        private void Btn_Ver_Desembolso_Click(object sender, EventArgs e)
        {
            cmds.Pendientes_Desembolso(dgvDatos);            
        }

        private void Btn_Asignar_Click(object sender, EventArgs e)
        {
            if (CmbFuncionario_Desembolso.Text!="")
            {
                cmds.Asignar_Desembolso(TxtRadicado, CmbFuncionario_Desembolso, lblfecha, lblHora);
                cmds.Asignar_Actualizar_Base(TxtRadicado);
                MessageBox.Show("Ok Operacion Asignada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                TxtRadicado.Text = "";
                CmbFuncionario_Desembolso.Text = "";
                cmds.Pendientes_Desembolso(dgvDatos);
            }
            else
            {
                MessageBox.Show("Debera Seleccionar funcionario para asignar operacion");
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void BtnVer_Asignacion_Click(object sender, EventArgs e)
        {
            if (cmbestado_asignacion.Text!= "")
            {
                cmds.Ver_Asignacion_Desembolso_Funcionario(dgvAsignacion,dtpfecha_asignacion, cmbestado_asignacion);
            }
            else 
            {
                MessageBox.Show("debe seleccionar estado");
            }
            
            
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtRadicado.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
