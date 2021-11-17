using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Usuarios_planta.Capa_presentacion
{
    public partial class Reporte_Seguros : Form
    {
        Comandos cmds = new Comandos();
        public Reporte_Seguros()
        {
            InitializeComponent();
        }

        private void Reporte_Seguros_Load(object sender, EventArgs e)
        {
            cmds.Antecedentes_Reportes_Seguros(dgvDatos_Seguros);
        }
    }
}
