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
    public partial class Formalizacion : Form
    {

        Comandos cmds = new Comandos();
        public Formalizacion()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            cmds.Buscar_formalizacion(TxtRadicado, TxtCedula, TxtNombre, TxtEstatura, TxtPeso, TxtCuenta, TxtScoring, TxtValor_aprobado,
                                      Txtplazo_aprobado,  cmbDestino,  TxtRauto,  TxtValor_Rtq,  TxtConvenio,  TxtCod_oficina,  TxtNom_oficina,  TxtId_gestor,  TxtNom_gestor,
                                      Txtobligacion1,  TxtNom_entidad1,  TxtNit1,  TxtValor1,  Txtobligacion2,  TxtNom_entidad2,  TxtNit2,  TxtValor2,
                                      Txtobligacion3,  TxtNom_entidad3,  TxtNit3,  TxtValor3,  Txtobligacion4,  TxtNom_entidad4,  TxtNit4,  TxtValor4,
                                      Txtobligacion5,  TxtNom_entidad5,  TxtNit5,  TxtValor5,  Txtobligacion6,  TxtNom_entidad6,  TxtNit6,  TxtValor6,
                                      Txtobligacion7,  TxtNom_entidad7,  TxtNit7,  TxtValor7,  Txtobligacion8,  TxtNom_entidad8,  TxtNit8,  TxtValor8, TxtTotal, TxtSaldo_cliente);

            if (TxtValor_aprobado.Text != "")
            {
                TxtValor_aprobado.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor_aprobado.Text));
            }
            if (TxtValor_Rtq.Text != "")
            {
                TxtValor_Rtq.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor_Rtq.Text));
            }
            if (TxtValor1.Text != "")
            {
                TxtValor1.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor1.Text));
            }
            if (TxtValor2.Text != "")
            {
                TxtValor2.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor2.Text));
            }
            if (TxtValor3.Text != "")
            {
                TxtValor3.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor3.Text));
            }
            if (TxtValor4.Text != "")
            {
                TxtValor4.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor4.Text));
            }
            if (TxtValor5.Text != "")
            {
                TxtValor5.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor5.Text));
            }
            if (TxtValor6.Text != "")
            {
                TxtValor6.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor6.Text));
            }
            if (TxtValor7.Text != "")
            {
                TxtValor7.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor7.Text));
            }
            if (TxtValor8.Text != "")
            {
                TxtValor8.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor8.Text));
            }
            if (TxtTotal.Text != "")
            {
                TxtTotal.Text = string.Format("{0:#,##0.##}", double.Parse(TxtTotal.Text));
            }
            if (TxtSaldo_cliente.Text != "")
            {
                TxtSaldo_cliente.Text = string.Format("{0:#,##0.##}", double.Parse(TxtSaldo_cliente.Text));
            }
        }

        private bool validar()
        {
            bool ok = true;

            if (CmbResultado.Text == "")
            {
                ok = false;
                epError.SetError(CmbResultado, "Debes seleccionar estado final de la operacion");
            }            
            return ok;
        }
        private void BorrarMensajeError()
        {
            epError.SetError(CmbResultado, "");            
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            BorrarMensajeError();
            if (validar())
            {
                cmds.Actualiza_Desembolso(TxtRadicado, CmbResultado, TxtComentarios);
                BtnLimpiar.PerformClick();
                BtnVer_Asignacion.PerformClick();
            }

            

        }

        private void BtnVer_Asignacion_Click(object sender, EventArgs e)
        {
            cmds.Ver_Asignacion_Desembolso_xFuncionario(dgvTotal_Asignacion);
        }

        private void dgvTotal_Asignacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtRadicado.Text = dgvTotal_Asignacion.CurrentRow.Cells[0].Value.ToString();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtRadicado.Text = "";
            TxtCedula.Text = "";
            TxtNombre.Text = "";
            TxtEstatura.Text = "";
            TxtPeso.Text = "";
            TxtCuenta.Text = "";
            TxtScoring.Text = "";
            TxtValor_aprobado.Text = "";
            Txtplazo_aprobado.Text = "";
            cmbDestino.Text = "";
            TxtRauto.Text = "";
            TxtValor_Rtq.Text = "";
            TxtConvenio.Text = "";
            TxtCod_oficina.Text = "";
            TxtNom_oficina.Text = "";
            TxtId_gestor.Text = "";
            TxtNom_gestor.Text = "";
            Txtobligacion1.Text = "";
            TxtNom_entidad1.Text = "";
            TxtNit1.Text = "";
            TxtValor1.Text = "";
            Txtobligacion2.Text = "";
            TxtNom_entidad2.Text = "";
            TxtNit2.Text = "";
            TxtValor2.Text = "";
            Txtobligacion3.Text = "";
            TxtNom_entidad3.Text = "";
            TxtNit3.Text = "";
            TxtValor3.Text = "";
            Txtobligacion4.Text = "";
            TxtNom_entidad4.Text = "";
            TxtNit4.Text = "";
            TxtValor4.Text = "";
            Txtobligacion5.Text = "";
            TxtNom_entidad5.Text = "";
            TxtNit5.Text = "";
            TxtValor5.Text = "";
            Txtobligacion6.Text = "";
            TxtNom_entidad6.Text = "";
            TxtNit6.Text = "";
            TxtValor6.Text = "";
            Txtobligacion7.Text = "";
            TxtNom_entidad7.Text = "";
            TxtNit7.Text = "";
            TxtValor7.Text = "";
            Txtobligacion8.Text = "";
            TxtNom_entidad8.Text = "";
            TxtNit8.Text = "";
            TxtValor8.Text = "";
            TxtTotal.Text = "";
            TxtSaldo_cliente.Text = "";
            CmbResultado.Text = "";
            TxtComentarios.Text = "";
        }

        private void CmbResultado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cod_funcionario;
            cod_funcionario = usuario.Identificacion.Substring(usuario.Identificacion.Length - 3); // extrae los ultimos 5 digitos del textbox 
            TxtComentarios.Text = "412 Ok Formalizado " + TxtScoring.Text+" "+ cod_funcionario;
        }
    }
}
