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
using System.Globalization;
using System.Drawing.Printing;
using System.IO;
using Usuarios_planta.Capa_presentacion;


namespace Usuarios_planta.Formularios
{
    public partial class FormOrden : Form
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");

        Comandos cmds = new Comandos();
        MySqlDataReader dr;

        public FormOrden()
        {
            InitializeComponent();
            Cargar_Coordinador();
            Cargar_Campañas();
            Ciudad_Residencia();
        }

        DateTime fecha = DateTime.Now;

        private void FormOrden_Load(object sender, EventArgs e)
        {            
            lbfuncionario.Text = usuario.Nombre;
            dtpFecha_Nacimiento.Text = "2021-01-01";
            dtpfecha_aprobado_vb.Text = "01/01/2021";
            lblfecha.Text = fecha.ToString("yyyy-MM-dd");
            TxtRauto.Enabled = false;
            TxtValor_Rtq.Enabled = false;
            Txtcod_giro.Enabled = false;
            lbexonerar.Visible = false;
            lblfecha_actual.Text = fecha.ToString("yyyy-MM-dd H:mm");
            BtnSimulador.Visible = false;
            TxtNom_entidad1.Visible = false;
            Txtobligacion1.Visible = false;
            TxtNit1.Visible = false;
            TxtValor1.Visible = false;
            TxtNom_entidad2.Visible = false;
            Txtobligacion2.Visible = false;
            TxtNit2.Visible = false;
            TxtValor2.Visible = false;
            TxtNom_entidad3.Visible = false;
            Txtobligacion3.Visible = false;
            TxtNit3.Visible = false;
            TxtValor3.Visible = false;
            TxtNom_entidad4.Visible = false;
            Txtobligacion4.Visible = false;
            TxtNit4.Visible = false;
            TxtValor4.Visible = false;
            TxtNom_entidad5.Visible = false;
            Txtobligacion5.Visible = false;
            TxtNit5.Visible = false;
            TxtValor5.Visible = false;
            TxtNom_entidad6.Visible = false;
            Txtobligacion6.Visible = false;
            TxtNit6.Visible = false;
            TxtValor6.Visible = false;
            TxtNom_entidad7.Visible = false;
            Txtobligacion7.Visible = false;
            TxtNit7.Visible = false;
            TxtValor7.Visible = false;
            TxtNom_entidad8.Visible = false;
            Txtobligacion8.Visible = false;
            TxtNit8.Visible = false;
            TxtValor8.Visible = false;

            MySqlCommand cmd = new MySqlCommand("SELECT nombre_entidad FROM tf_entidades", con);
            con.Open();
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                Collection.Add(dr.GetString(0));
            }
            TxtNom_entidad1.AutoCompleteCustomSource = Collection;
            TxtNom_entidad2.AutoCompleteCustomSource = Collection;
            TxtNom_entidad3.AutoCompleteCustomSource = Collection;
            TxtNom_entidad4.AutoCompleteCustomSource = Collection;
            TxtNom_entidad5.AutoCompleteCustomSource = Collection;
            TxtNom_entidad6.AutoCompleteCustomSource = Collection;
            TxtNom_entidad7.AutoCompleteCustomSource = Collection;
            TxtNom_entidad8.AutoCompleteCustomSource = Collection;
            dr.Close();
            con.Close();
        }

        public void Ciudad_Residencia()
        {
            con.Open();
            string query = "SELECT distinct ciudad from ciudades_principales order by ciudad asc";
            MySqlCommand comando = new MySqlCommand(query, con);
            MySqlDataAdapter da1 = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            DataRow fila = dt.NewRow();
            fila["ciudad"] = "";
            dt.Rows.InsertAt(fila, 0);
            cmbCiudad_Residencia_Cliente.ValueMember = "ciudad";
            cmbCiudad_Residencia_Cliente.DisplayMember = "ciudad";
            cmbCiudad_Residencia_Cliente.DataSource = dt;
        }
        public void Cargar_Campañas()
        {
            con.Open();
            string query = "SELECT Nombre_Campaña from campañas_libranza order by Nombre_Campaña desc";
            MySqlCommand comando = new MySqlCommand(query, con);
            MySqlDataAdapter da1 = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            DataRow fila = dt.NewRow();
            fila["Nombre_Campaña"] = "Seleccione la campaña";
            dt.Rows.InsertAt(fila, 0);
            cmbcampaña.ValueMember = "Nombre_Campaña";
            cmbcampaña.DisplayMember = "Nombre_Campaña";
            cmbcampaña.DataSource = dt;
        }

        public void Cargar_Coordinador()
        {
            con.Open();
            string query = "SELECT nombre_coordinador from tf_coordinador order by nombre_coordinador asc";
            MySqlCommand comando = new MySqlCommand(query, con);
            MySqlDataAdapter da1 = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            DataRow fila = dt.NewRow();
            fila["nombre_coordinador"] = "Seleccione el coordinador";
            dt.Rows.InsertAt(fila, 0);
            cmbCoordinador.ValueMember = "nombre_coordinador";
            cmbCoordinador.DisplayMember = "nombre_coordinador";
            cmbCoordinador.DataSource = dt;
        }

        private double cpk1, cpk2, cpk3, cpk4, cpk5, cpk6, cpk7, cpk8, cpk9, cpk10, cpktotal = 0, cpksaldo = 0;


        private void TxtValor_aprobado_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(TxtValor_aprobado.Text, out cpk10))
                Restar1();
            else
                TxtValor_aprobado.Text = cpk10.ToString();
        }

        private void TxtTotal_TextChanged(object sender, EventArgs e)
        {

            if (double.TryParse(TxtTotal.Text, out cpk9))
                Restar1();
            else
                TxtSaldo_cliente.Text = cpk9.ToString();

            if (Convert.ToDouble(TxtSaldo_cliente.Text) <= 2000000)
            {
                MessageBox.Show("Saldo del cliente menor a 2 millones por favor proceder a realizar simulador", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BtnSimulador.Visible = true;
            }
            else
            {
                BtnSimulador.Visible = false;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        Bitmap bmp;

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (TxtNom_oficina.Text == "SAN ANDRES" || TxtNom_oficina.Text == "LETICIA")
            {
                lbexonerar.Visible = true;                
            }
            else if (TxtNom_oficina.Text == "GENTE BBVA" && cmbDestino.Text == "Compra de Cartera")
            {
                lbexonerar.Visible = true;                
            }
            else if (TxtNom_oficina.Text == "GENTE BBVA" && cmbDestino.Text == "Cpk Libranza")
            {
                lbexonerar.Visible = true;                
            }
            else if (TxtNom_oficina.Text == "GENTE BBVA" && cmbDestino.Text == "CPK + RTQ")
            {
                lbexonerar.Visible = true;               
            }

            if (TxtValor_Rtq.Text != "")
            {
                double resta = Convert.ToDouble(TxtSaldo_cliente.Text) - Convert.ToDouble(TxtValor_Rtq.Text);
                if (resta <= 2000000)
                {
                    BtnSimulador.Visible = true;
                }
            }

            if (cmbcambio_condiciones.Text == "Cliente Acepta" || cmbcambio_condiciones.Text == "No Aplica" || cmbcambio_condiciones.Text == "No Registra")
            {
                if (cmbDactiloscopia.Text == "Aprobada")
                {
                    if (TxtNom_gestor.Text == "")
                    {
                        MessageBox.Show("Previo a imprimir proceder a crear asesor en la base de datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (TxtRauto.Text != "" && TxtValor_Rtq.Text == "")
                        {
                            MessageBox.Show("Importante diligenciar el valor del retanqueo Automatico para validar el simulador", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            BtnGuardar.Visible = false;
                            BtnImprimir.Visible = false;
                            BtnLimpiar.Visible = false;
                            BtnAñadir_Carteras.Visible = false;
                            BtnLimpiar_Carteras.Visible = false;

                            Graphics g = this.CreateGraphics();
                            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
                            Graphics mg = Graphics.FromImage(bmp);
                            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
                            printPreviewDialog1.ShowDialog();                            
                            BtnGuardar.Visible = true;
                            BtnImprimir.Visible = true;
                            BtnLimpiar.Visible = true;
                            BtnAñadir_Carteras.Visible = true;
                            BtnLimpiar_Carteras.Visible = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dactiloscopia no se encuentra en estado Aprobada, por favor validar previo al desembolso!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDactiloscopia.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por favor revisar cambio de condiciones", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtNom_entidad1_TextChanged_1(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_entidades WHERE nombre_entidad = @nombre_entidad ", con);
            comando.Parameters.AddWithValue("@nombre_entidad", TxtNom_entidad1.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                TxtNit1.Text = registro["nit_entidad"].ToString();
            }
            con.Close();
        }

        private void Consultar_Cambio_Condiciones(TextBox TxtRadicado)
        {
            MySqlCommand comando = new MySqlCommand("SELECT Estado_Operacion FROM cambio_condiciones WHERE Radicado = @Radicado ", con);
            comando.Parameters.AddWithValue("@Radicado", TxtRadicado.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                cmbcambio_condiciones.Text = registro["cambio_condiciones"].ToString();               
            }
            else
            {
                cmbcambio_condiciones.Text = "No Registra";                
            }
            con.Close();
        }

        private void Consultar_Etapas_Cumplidas(TextBox TxtRadicado)
        {
            MySqlCommand comando = new MySqlCommand("SELECT Estado_Operacion FROM etapas_cumplidas WHERE Radicado = @Radicado ", con);
            comando.Parameters.AddWithValue("@Radicado", TxtRadicado.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                cmbG_telefonica.Text = registro["Estado_Operacion"].ToString();
            }
            else
            {
                cmbG_telefonica.Text = "No Aplica";                
            }
            con.Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

            cmds.Buscar_Validacion_Desembolso(TxtRadicado, TxtCedula, TxtNombre, dtpFecha_Nacimiento, TxtEdad_Cliente, TxtEstatura, TxtPeso, TxtCuenta, TxtScoring, TxtValor_aprobado,
                             Txtplazo_aprobado, cmbDestino, TxtRauto, TxtValor_Rtq, TxtConvenio, TxtCod_oficina, TxtNom_oficina, TxtCiudad,
                             Txtcod_giro, Txtoficina_girar, TxtId_gestor, TxtNom_gestor, cmbCoordinador, cmbDactiloscopia, cmbG_telefonica, cmbcampaña, dtpfecha_aprobado_vb,
                             Txtobligacion1, TxtNom_entidad1, TxtNit1, TxtValor1, Txtobligacion2, TxtNom_entidad2, TxtNit2, TxtValor2,
                             Txtobligacion3, TxtNom_entidad3, TxtNit3, TxtValor3, Txtobligacion4, TxtNom_entidad4, TxtNit4, TxtValor4,
                             Txtobligacion5, TxtNom_entidad5, TxtNit5, TxtValor5, Txtobligacion6, TxtNom_entidad6, TxtNit6, TxtValor6,
                             Txtobligacion7, TxtNom_entidad7, TxtNit7, TxtValor7, Txtobligacion8, TxtNom_entidad8, TxtNit8, TxtValor8,
                             cmbFormato_Seguros, cmbReporte_Enfermedad, cmbSeguros_Monto, cmbSobrepeso, cmbEstado_Reporte,
                             TxtTotal, TxtSaldo_cliente, cmbestado, TxtPendientes);
            //Consultar_Etapas_Cumplidas(TxtRadicado);
            //Consultar_Cambio_Condiciones(TxtRadicado);


            if (cmbestado.Text == "Ok Formalizado" || cmbestado.Text == "Pte Formalizacion")
            {
                TxtRadicado.Enabled = false;
                TxtCedula.Enabled = false;
                TxtNombre.Enabled = false;
                TxtEstatura.Enabled = false;
                TxtPeso.Enabled = false;
                TxtCuenta.Enabled = false;
                TxtScoring.Enabled = false;
                TxtValor_aprobado.Enabled = false;                
                Txtplazo_aprobado.Enabled = false;
                cmbDestino.Enabled = false;
                cmbcambio_condiciones.Enabled = false;
                TxtRauto.Enabled = false;
                TxtValor_Rtq.Enabled = false;
                TxtConvenio.Enabled = false;
                TxtCod_oficina.Enabled = false;
                TxtNom_oficina.Enabled = false;
                TxtCiudad.Enabled = false;
                Txtcod_giro.Enabled = false;
                Txtoficina_girar.Enabled = false;
                TxtId_gestor.Enabled = false;
                TxtNom_gestor.Enabled = false;
                cmbCoordinador.Enabled = false;
                cmbDactiloscopia.Enabled = false;
                cmbG_telefonica.Enabled = false;
                cmbcampaña.Enabled = false;
                dtpfecha_aprobado_vb.Enabled = false;
                Txtobligacion1.Enabled = false;
                TxtNom_entidad1.Enabled = false;
                TxtNit1.Enabled = false;
                TxtValor1.Enabled = false;
                Txtobligacion2.Enabled = false;
                TxtNom_entidad2.Enabled = false;
                TxtNit2.Enabled = false;
                TxtValor2.Enabled = false;
                Txtobligacion3.Enabled = false;
                TxtNom_entidad3.Enabled = false;
                TxtNit3.Enabled = false;
                TxtValor3.Enabled = false;
                Txtobligacion4.Enabled = false;
                TxtNom_entidad4.Enabled = false;
                TxtNit4.Enabled = false;
                TxtValor4.Enabled = false;
                Txtobligacion5.Enabled = false;
                TxtNom_entidad5.Enabled = false;
                TxtNit5.Enabled = false;
                TxtValor5.Enabled = false;
                Txtobligacion6.Enabled = false;
                TxtNom_entidad6.Enabled = false;
                TxtNit6.Enabled = false;
                TxtValor6.Enabled = false;
                Txtobligacion7.Enabled = false;
                TxtNom_entidad7.Enabled = false;
                TxtNit7.Enabled = false;
                TxtValor7.Enabled = false;
                Txtobligacion8.Enabled = false;
                TxtNom_entidad8.Enabled = false;
                TxtNit8.Enabled = false;
                TxtValor8.Enabled = false;
                TxtTotal.Enabled = false;
                TxtSaldo_cliente.Enabled = false;
                cmbestado.Enabled = false;
                TxtPendientes.Enabled = false;
            }
            else
            {

            }

            if (TxtNom_entidad1.Text != "")
            {
                TxtNom_entidad1.Visible = true;
                Txtobligacion1.Visible = true;
                TxtNit1.Visible = true;
                TxtValor1.Visible = true;
            }
            if (TxtNom_entidad2.Text != "")
            {
                TxtNom_entidad2.Visible = true;
                Txtobligacion2.Visible = true;
                TxtNit2.Visible = true;
                TxtValor2.Visible = true;
            }
            if (TxtNom_entidad3.Text != "")
            {
                TxtNom_entidad3.Visible = true;
                Txtobligacion3.Visible = true;
                TxtNit3.Visible = true;
                TxtValor3.Visible = true;
            }
            if (TxtNom_entidad4.Text != "")
            {
                TxtNom_entidad4.Visible = true;
                Txtobligacion4.Visible = true;
                TxtNit4.Visible = true;
                TxtValor4.Visible = true;
            }
            if (TxtNom_entidad5.Text != "")
            {
                TxtNom_entidad5.Visible = true;
                Txtobligacion5.Visible = true;
                TxtNit5.Visible = true;
                TxtValor5.Visible = true;
            }
            if (TxtNom_entidad6.Text != "")
            {
                TxtNom_entidad6.Visible = true;
                Txtobligacion6.Visible = true;
                TxtNit6.Visible = true;
                TxtValor6.Visible = true;
            }
            if (TxtNom_entidad7.Text != "")
            {
                TxtNom_entidad7.Visible = true;
                Txtobligacion7.Visible = true;
                TxtNit7.Visible = true;
                TxtValor7.Visible = true;
            }
            if (TxtNom_entidad8.Text != "")
            {
                TxtNom_entidad8.Visible = true;
                Txtobligacion8.Visible = true;
                TxtNit8.Visible = true;
                TxtValor8.Visible = true;
            }
            if (TxtEstatura.Text!="" && TxtPeso.Text != "" )
            {
                TxtValor_aprobado.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor_aprobado.Text));
                Reporte_Peso();
            }
            if (TxtValor_aprobado.Text != "" && TxtEdad_Cliente.Text!="")
            {
                TxtValor_aprobado.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor_aprobado.Text));
                Reporte_Monto();
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
            if (TxtCedula.Text == "")
            {
                cmds.Busqueda_VoBo(TxtRadicado, TxtCedula, TxtNombre, TxtScoring, TxtConvenio, cmbDestino, TxtValor_aprobado, Txtplazo_aprobado, dtpfecha_aprobado_vb,
                                   TxtNom_entidad1, TxtNom_entidad2, TxtNom_entidad3, TxtNom_entidad4, TxtNom_entidad5, TxtNom_entidad6, TxtNom_entidad7, TxtNom_entidad8);
                if (TxtValor_aprobado.Text != "")
                {
                    TxtValor_aprobado.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor_aprobado.Text));                    
                }                
                if (TxtCedula.Text == "")
                {
                    cmds.Busqueda_Colp(TxtRadicado, TxtCedula, TxtNombre, TxtScoring, cmbDestino, TxtValor_aprobado, Txtplazo_aprobado);
                    if (TxtCedula.Text == "")
                    {
                        MessageBox.Show("Caso No Existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                }
            }
        }

        private bool validar()
        {
            bool ok = true;

            if (TxtCedula.Text == "")
            {
                ok = false;
                epError.SetError(TxtCedula, "Digitar cedula del cliente");
            }
            if (TxtNombre.Text == "")
            {
                ok = false;
                epError.SetError(TxtNombre, "Digitar nombre del cliente");
            }
            if (TxtScoring.Text == "")
            {
                ok = false;
                epError.SetError(TxtScoring, "Digitar n° Scoring");
            }
            if (cmbestado.Text == "")
            {
                ok = false;
                epError.SetError(cmbestado, "Digitar Valor");
            }
            if (TxtValor_aprobado.Text == "")
            {
                ok = false;
                epError.SetError(TxtValor_aprobado, "Digitar Valor");
            }           
            if (Txtplazo_aprobado.Text == "")
            {
                ok = false;
                epError.SetError(Txtplazo_aprobado, "Digitar plazo solicitado");
            }
            if (cmbcampaña.Text == "")
            {
                ok = false;
                epError.SetError(cmbcampaña, "Debe seleccionar el tipo de campaña para el caso en gestion");
            }
            if (cmbDestino.Text == "")
            {
                ok = false;
                epError.SetError(cmbcampaña, "Debe seleccionar el destino de la operacion");
            }
            if (TxtEstatura.Text == "")
            {
                ok = false;
                epError.SetError(TxtEstatura, "Debe diligenciar estatura del cliente");
            }
            if (TxtPeso.Text == "")
            {
                ok = false;
                epError.SetError(TxtPeso, "Debe diligenciar peso del cliente");
            }
            if (TxtCod_oficina.Text == "")
            {
                ok = false;
                epError.SetError(TxtCod_oficina, "Debe diligenciar oficina a segmentar");
            }
            if (TxtId_gestor.Text == "")
            {
                ok = false;
                epError.SetError(TxtId_gestor, "Debe diligenciar cedula del asesor comercial");
            }
            if (dtpfecha_aprobado_vb.Text == "01/01/2021")
            {
                ok = false;
                epError.SetError(dtpfecha_aprobado_vb, "Debe diligenciar fecha de aprobacion de VoBo Pagador");
            }
            if (dtpFecha_Nacimiento.Text == "2021-01-01")
            {
                ok = false;
                epError.SetError(dtpFecha_Nacimiento, "Debe diligenciar fecha de nacimiento del cliente");
            }
            if (dtpFecha_Nacimiento.Text == "2021-01-01")
            {
                ok = false;
                epError.SetError(dtpFecha_Nacimiento, "Debe diligenciar fecha de nacimiento del cliente");
            }
            if (cmbFormato_Seguros.Text == "")
            {
                ok = false;
                epError.SetError(cmbFormato_Seguros, "Debe seleccionar si reporta o no enfermedad en el formato de seguros");
            }
            if (cmbReporte_Enfermedad.Text == "")
            {
                ok = false;
                epError.SetError(cmbReporte_Enfermedad, "Debe seleccionar si enfermedad reportada aplica o no para reporte");
            }
            return ok;
        }

        private void BorrarMensajeError()
        {
            epError.SetError(TxtCedula, "");
            epError.SetError(TxtNombre, "");
            epError.SetError(TxtScoring, "");
            epError.SetError(cmbestado, "");            
            epError.SetError(Txtplazo_aprobado, "");
            epError.SetError(Txtplazo_aprobado, "");
            epError.SetError(TxtValor_aprobado, "");
            epError.SetError(cmbcampaña, "");
            epError.SetError(cmbDestino, "");
            epError.SetError(TxtEstatura, "");
            epError.SetError(TxtPeso, "");
            epError.SetError(TxtCod_oficina, "");
            epError.SetError(TxtId_gestor, "");
            epError.SetError(dtpfecha_aprobado_vb, "");
            epError.SetError(dtpFecha_Nacimiento, "");
            epError.SetError(cmbFormato_Seguros, "");
            epError.SetError(cmbReporte_Enfermedad, "");
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbcampaña.Text == "Campaña CAP" && cmbDestino.Text == "Retanqueo")
            {
                MessageBox.Show("Importante verificar que los retanqueos se encuentren atados y el scoring se encuentre con la marcacion correspondiente.", "Información Importante !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbcampaña.Text == "Campaña CAP" && cmbDestino.Text == "CPK + RTQ")
            {
                MessageBox.Show("Importante verificar que los retanqueos se encuentren atados y el scoring se encuentre con la marcacion correspondiente.", "Información Importante !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (TxtNom_oficina.Text == "SAN ANDRES" || TxtNom_oficina.Text == "LETICIA")
            {
                lbexonerar.Visible = true;
                MessageBox.Show("Tener en cuenta que dicha oficina se debe exonerar previo al desembolso");
            }
            else if (TxtNom_oficina.Text == "GENTE BBVA" && cmbDestino.Text == "Compra de Cartera")
            {
                lbexonerar.Visible = true;
                MessageBox.Show("Tener en cuenta que dicha oficina se debe exonerar previo al desembolso");
            }
            else if (TxtNom_oficina.Text == "GENTE BBVA" && cmbDestino.Text == "Cpk Libranza")
            {
                lbexonerar.Visible = true;
                MessageBox.Show("Tener en cuenta que dicha oficina se debe exonerar previo al desembolso");
            }
            else if (TxtNom_oficina.Text == "GENTE BBVA" && cmbDestino.Text == "CPK + RTQ")
            {
                lbexonerar.Visible = true;
                MessageBox.Show("Tener en cuenta que dicha oficina se debe exonerar previo al desembolso");
            }
            if (dtpfecha_aprobado_vb.Text == "2021-01-01")
            {
                MessageBox.Show("Por favor diligenciar fecha de aprobacion de vb");
            }
            else if (dtpfecha_aprobado_vb.Text != "2021-01-01")
            {
                DateTime fecha1 = Convert.ToDateTime(lblfecha.Text);
                DateTime fecha2 = dtpfecha_aprobado_vb.Value.Date;
                TimeSpan tspan = fecha1 - fecha2;
                int dias = tspan.Days;                
                if (dias > 19)
                {
                    MessageBox.Show("Fecha de Aprobacion de vb ya supero los 20 dias, por favor reportar al area encargada para ratificar aprobacion");
                }
            }
            if (cmbestado.Text == "Desembolso" && cmbEstado_Reporte.Text == "Pte Preformalizacion")
            {
                MessageBox.Show("Caso no puede avanzar como aprobado si el estado de seguros no esta Ok Preformalizado");
            }

            BorrarMensajeError();
            if (validar())
            {
                cmds.Guardar_Validacion_desembolso(TxtRadicado, TxtCedula, TxtNombre, dtpFecha_Nacimiento, TxtEdad_Cliente, TxtEstatura, TxtPeso, TxtCuenta, dtpfecha_aprobado_vb, TxtScoring, TxtValor_aprobado,
                                  Txtplazo_aprobado, cmbDestino, TxtRauto, TxtValor_Rtq, TxtConvenio, TxtCod_oficina, TxtNom_oficina, TxtCiudad,
                                  Txtcod_giro, Txtoficina_girar, TxtId_gestor, TxtNom_gestor, cmbCoordinador, cmbDactiloscopia, cmbG_telefonica, cmbcampaña,
                                  Txtobligacion1, TxtNom_entidad1, TxtNit1, TxtValor1, Txtobligacion2, TxtNom_entidad2, TxtNit2, TxtValor2,
                                  Txtobligacion3, TxtNom_entidad3, TxtNit3, TxtValor3, Txtobligacion4, TxtNom_entidad4, TxtNit4, TxtValor4,
                                  Txtobligacion5, TxtNom_entidad5, TxtNit5, TxtValor5, Txtobligacion6, TxtNom_entidad6, TxtNit6, TxtValor6,
                                  Txtobligacion7, TxtNom_entidad7, TxtNit7, TxtValor7, Txtobligacion8, TxtNom_entidad8, TxtNit8, TxtValor8,
                                  cmbFormato_Seguros, cmbReporte_Enfermedad, cmbSeguros_Monto, cmbSobrepeso, cmbEstado_Reporte,
                                  TxtTotal, TxtSaldo_cliente, cmbestado, TxtPendientes);
            }

        }
        string estado_oficina;
        string estado_cartera;

        public string Identificacion { get; private set; }

        private void TxtNom_entidad1_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_entidades WHERE nombre_entidad = @nombre_entidad ", con);
            comando.Parameters.AddWithValue("@nombre_entidad", TxtNom_entidad1.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                estado_cartera = registro["estado_entidad"].ToString();

                if (estado_cartera == "Cerrada")
                {
                    MessageBox.Show("Entidad se encuentra suspendida para Comprar!!! por favor revisar segun corresponda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtNit1.Text = null;
                }
                else
                {
                    TxtNit1.Text = registro["nit_entidad"].ToString();
                }
            }
            else
            {
                TxtNit1.Text = null;
            }
            con.Close();
        }

        private void TxtNom_entidad2_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_entidades WHERE nombre_entidad = @nombre_entidad ", con);
            comando.Parameters.AddWithValue("@nombre_entidad", TxtNom_entidad2.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                estado_cartera = registro["estado_entidad"].ToString();

                if (estado_cartera == "Cerrada")
                {
                    MessageBox.Show("Entidad se encuentra suspendida para Comprar!!! por favor revisar segun corresponda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtNit2.Text = null;
                }
                else
                {
                    TxtNit2.Text = registro["nit_entidad"].ToString();
                }
            }
            else
            {
                TxtNit2.Text = null;
            }
            con.Close();
        }

        private void TxtNom_entidad3_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_entidades WHERE nombre_entidad = @nombre_entidad ", con);
            comando.Parameters.AddWithValue("@nombre_entidad", TxtNom_entidad3.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                estado_cartera = registro["estado_entidad"].ToString();

                if (estado_cartera == "Cerrada")
                {
                    MessageBox.Show("Entidad se encuentra suspendida para Comprar!!! por favor revisar segun corresponda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtNit3.Text = null;
                }
                else
                {
                    TxtNit3.Text = registro["nit_entidad"].ToString();
                }
            }
            else
            {
                TxtNit3.Text = null;
            }
            con.Close();
        }

        private void TxtNom_entidad4_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_entidades WHERE nombre_entidad = @nombre_entidad ", con);
            comando.Parameters.AddWithValue("@nombre_entidad", TxtNom_entidad4.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                estado_cartera = registro["estado_entidad"].ToString();

                if (estado_cartera == "Cerrada")
                {
                    MessageBox.Show("Entidad se encuentra suspendida para Comprar!!! por favor revisar segun corresponda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtNit4.Text = null;
                }
                else
                {
                    TxtNit4.Text = registro["nit_entidad"].ToString();
                }
            }
            else
            {
                TxtNit4.Text = null;
            }
            con.Close();
        }

        private void TxtNom_entidad5_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_entidades WHERE nombre_entidad = @nombre_entidad ", con);
            comando.Parameters.AddWithValue("@nombre_entidad", TxtNom_entidad5.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                estado_cartera = registro["estado_entidad"].ToString();

                if (estado_cartera == "Cerrada")
                {
                    MessageBox.Show("Entidad se encuentra suspendida para Comprar!!! por favor revisar segun corresponda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtNit5.Text = null;
                }
                else
                {
                    TxtNit5.Text = registro["nit_entidad"].ToString();
                }
            }
            else
            {
                TxtNit5.Text = null;
            }
            con.Close();
        }

        private void TxtNom_entidad6_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_entidades WHERE nombre_entidad = @nombre_entidad ", con);
            comando.Parameters.AddWithValue("@nombre_entidad", TxtNom_entidad6.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                estado_cartera = registro["estado_entidad"].ToString();

                if (estado_cartera == "Cerrada")
                {
                    MessageBox.Show("Entidad se encuentra suspendida para Comprar!!! por favor revisar segun corresponda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtNit6.Text = null;
                }
                else
                {
                    TxtNit6.Text = registro["nit_entidad"].ToString();
                }
            }
            else
            {
                TxtNit6.Text = null;
            }
            con.Close();
        }

        private void TxtNom_entidad7_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_entidades WHERE nombre_entidad = @nombre_entidad ", con);
            comando.Parameters.AddWithValue("@nombre_entidad", TxtNom_entidad7.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                estado_cartera = registro["estado_entidad"].ToString();

                if (estado_cartera == "Cerrada")
                {
                    MessageBox.Show("Entidad se encuentra suspendida para Comprar!!! por favor revisar segun corresponda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtNit7.Text = null;
                }
                else
                {
                    TxtNit7.Text = registro["nit_entidad"].ToString();
                }
            }
            else
            {
                TxtNit7.Text = null;
            }
            con.Close();
        }

        private void TxtNom_entidad8_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_entidades WHERE nombre_entidad = @nombre_entidad ", con);
            comando.Parameters.AddWithValue("@nombre_entidad", TxtNom_entidad8.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                estado_cartera = registro["estado_entidad"].ToString();

                if (estado_cartera == "Cerrada")
                {
                    MessageBox.Show("Entidad se encuentra suspendida para Comprar!!! por favor revisar segun corresponda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtNit8.Text = null;
                }
                else
                {
                    TxtNit8.Text = registro["nit_entidad"].ToString();
                }
            }
            else
            {
                TxtNit8.Text = null;
            }
            con.Close();
        }

        private void TxtValor1_Validated(object sender, EventArgs e)
        {
            string V_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el valor de la obligacion", "Confirmar valor de la obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 

            if (V_Obligacion == TxtValor1.Text)
            {
                if (Convert.ToDouble(TxtValor1.Text) > 0)
                {
                    //TxtValor1.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor1.Text));
                    //TxtTotal.Text = string.Format("{0:#,##0.##}", double.Parse(TxtTotal.Text));
                    //TxtSaldo_cliente.Text = string.Format("{0:#,##0.##}", double.Parse(TxtSaldo_cliente.Text));
                    TxtValor1.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtValor1.Text));
                    TxtTotal.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtTotal.Text));
                    TxtSaldo_cliente.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtSaldo_cliente.Text));

                }
                else if (TxtValor1.Text == "")
                {
                    TxtValor1.Text = Convert.ToString(0);
                }
            }
            else
            {
                MessageBox.Show("Valor de la obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtValor1.Text = "";
                TxtValor1.Focus();
            }
        }

        private void TxtValor2_Validated(object sender, EventArgs e)
        {
            string V_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el valor de la obligacion", "Confirmar valor de la obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 

            if (V_Obligacion == TxtValor2.Text)
            {
                if (Convert.ToDouble(TxtValor2.Text) > 0)
                {
                    //TxtValor2.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor2.Text));
                    //TxtTotal.Text = string.Format("{0:#,##0.##}", double.Parse(TxtTotal.Text));
                    //TxtSaldo_cliente.Text = string.Format("{0:#,##0.##}", double.Parse(TxtSaldo_cliente.Text));
                    TxtValor2.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtValor2.Text));
                    TxtTotal.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtTotal.Text));
                    TxtSaldo_cliente.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtSaldo_cliente.Text));

                }
                else if (TxtValor2.Text == "")
                {
                    TxtValor2.Text = Convert.ToString(0);
                }
            }
            else
            {
                MessageBox.Show("Valor de la obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtValor2.Text = "";
                TxtValor2.Focus();
            }
        }

        private void TxtValor3_Validated(object sender, EventArgs e)
        {
            string V_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el valor de la obligacion", "Confirmar valor de la obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (V_Obligacion == TxtValor3.Text)
            {
                if (Convert.ToDouble(TxtValor3.Text) > 0)
                {
                    //TxtValor3.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor3.Text));
                    //TxtTotal.Text = string.Format("{0:#,##0.##}", double.Parse(TxtTotal.Text));
                    //TxtSaldo_cliente.Text = string.Format("{0:#,##0.##}", double.Parse(TxtSaldo_cliente.Text));
                    TxtValor3.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtValor3.Text));
                    TxtTotal.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtTotal.Text));
                    TxtSaldo_cliente.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtSaldo_cliente.Text));
                }
                else if (TxtValor3.Text == "")
                {
                    TxtValor3.Text = Convert.ToString(0);
                }
            }
            else
            {
                MessageBox.Show("Valor de la obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtValor3.Text = "";
                TxtValor3.Focus();
            }
        }

        private void TxtValor4_Validated(object sender, EventArgs e)
        {
            string V_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el valor de la obligacion", "Confirmar valor de la obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic      
            if (V_Obligacion == TxtValor4.Text)
            {
                if (Convert.ToDouble(TxtValor4.Text) > 0)
                {
                    //TxtValor4.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor4.Text));
                    //TxtTotal.Text = string.Format("{0:#,##0.##}", double.Parse(TxtTotal.Text));
                    //TxtSaldo_cliente.Text = string.Format("{0:#,##0.##}", double.Parse(TxtSaldo_cliente.Text));
                    TxtValor4.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtValor4.Text));
                    TxtTotal.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtTotal.Text));
                    TxtSaldo_cliente.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtSaldo_cliente.Text));
                }
                else if (TxtValor4.Text == "")
                {
                    TxtValor4.Text = Convert.ToString(0);
                }
            }
            else
            {
                MessageBox.Show("Valor de la obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtValor4.Text = "";
                TxtValor4.Focus();
            }
        }

        private void TxtValor5_Validated(object sender, EventArgs e)
        {
            string V_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el valor de la obligacion", "Confirmar valor de la obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic      
            if (V_Obligacion == TxtValor5.Text)
            {
                if (Convert.ToDouble(TxtValor5.Text) > 0)
                {
                    //TxtValor5.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor5.Text));
                    //TxtTotal.Text = string.Format("{0:#,##0.##}", double.Parse(TxtTotal.Text));
                    //TxtSaldo_cliente.Text = string.Format("{0:#,##0.##}", double.Parse(TxtSaldo_cliente.Text));
                    TxtValor5.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtValor5.Text));
                    TxtTotal.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtTotal.Text));
                    TxtSaldo_cliente.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtSaldo_cliente.Text));
                }
                else if (TxtValor5.Text == "")
                {
                    TxtValor5.Text = Convert.ToString(0);
                }
            }
            else
            {
                MessageBox.Show("Valor de la obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtValor5.Text = "";
                TxtValor5.Focus();
            }
        }
        private void Reporte_Peso()
        {
            string extrae_estatura;
            int sobrepeso;
            string resultado;
            extrae_estatura = TxtEstatura.Text.Substring(TxtEstatura.Text.Length - 2);
            sobrepeso = Convert.ToInt32(TxtPeso.Text) - Convert.ToInt32(extrae_estatura);
            resultado = Convert.ToString(sobrepeso);
            if (sobrepeso >= 21)
            {
                MessageBox.Show("Cliente presenta sobrepeso, total diferencia " + resultado + " Kilos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSobrepeso.Text = "Reportar";
                cmbEstado_Reporte.Text = "Pte Preformalizacion";
            }
            else
            {
                cmbSobrepeso.Text = "No Aplica";
            }
        }

        private void Reporte_Monto()
        {
            int Edad = Convert.ToInt32(TxtEdad_Cliente.Text);
            if (Convert.ToDouble(TxtValor_aprobado.Text) > 0)
            {
                //TxtValor_aprobado.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor_aprobado.Text));
                TxtValor_aprobado.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtValor_aprobado.Text));
                if (Convert.ToDouble(TxtValor_aprobado.Text) >= 500000000)
                {
                    MessageBox.Show("Reportar operación a SEGUROS BBVA, Monto igual o mayor a $500 Millones de pesos");
                    cmbSeguros_Monto.Text = "Reportar";
                    cmbEstado_Reporte.Text = "Pte Preformalizacion";

                }
                else if (Convert.ToDouble(TxtValor_aprobado.Text) >= 300000000 && Convert.ToDouble(TxtValor_aprobado.Text) < 500000000 && Edad >= 70)
                {
                    MessageBox.Show("Reportar operación a SEGUROS BBVA, Monto igual o mayor a $300 Millones de pesos y cliente con mas de 70 años");
                    cmbSeguros_Monto.Text = "Reportar";
                    cmbEstado_Reporte.Text = "Pte Preformalizacion";
                }
                else if (Convert.ToDouble(TxtValor_aprobado.Text) >= 50000000 && Edad >= 72)
                {
                    MessageBox.Show("Reportar operación a SEGUROS BBVA, Monto igual o mayor a $50 Millones de pesos y cliente con mas de 72 años");
                    cmbSeguros_Monto.Text = "Reportar";
                    cmbEstado_Reporte.Text = "Pte Preformalizacion";
                }
                else
                {
                    cmbSeguros_Monto.Text = "No Aplica";
                }
            }
            else if (TxtValor_aprobado.Text == "")
            {
                TxtValor_aprobado.Text = Convert.ToString(0);
            }
        }


        private void TxtValor_aprobado_Validated(object sender, EventArgs e)
        {
            //TxtValor_aprobado.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor_aprobado.Text));
            TxtValor_aprobado.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtValor_aprobado.Text));
            //TxtSaldo_cliente.Text = string.Format("{0:#,##0.##}", double.Parse(TxtSaldo_cliente.Text));
            TxtSaldo_cliente.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtSaldo_cliente.Text));
            Reporte_Monto();
        }

        private void TxtValor8_Validated(object sender, EventArgs e)
        {
            string V_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el valor de la obligacion", "Confirmar valor de la obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic      
            if (V_Obligacion == TxtValor8.Text)
            {
                if (Convert.ToDouble(TxtValor8.Text) > 0)
                {
                    //TxtValor8.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor8.Text));
                    //TxtTotal.Text = string.Format("{0:#,##0.##}", double.Parse(TxtTotal.Text));
                    //TxtSaldo_cliente.Text = string.Format("{0:#,##0.##}", double.Parse(TxtSaldo_cliente.Text));
                    TxtValor8.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtValor8.Text));
                    TxtTotal.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtTotal.Text));
                    TxtSaldo_cliente.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtSaldo_cliente.Text));
                }
                else if (TxtValor8.Text == "")
                {
                    TxtValor8.Text = Convert.ToString(0);
                }
            }
            else
            {
                MessageBox.Show("Valor de la obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtValor8.Text = "";
                TxtValor8.Focus();
            }
        }

        private void TxtCod_oficina_Validated(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_oficinas WHERE codigo_oficina = @codigo ", con);
            comando.Parameters.AddWithValue("@codigo", TxtCod_oficina.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                estado_oficina = registro["estado_oficina"].ToString();

                if (estado_oficina == "Cerrada")
                {
                    MessageBox.Show("Oficina a segmentar se encuentra cerrada, por favor revisar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    TxtNom_oficina.Text = registro["sucursal"].ToString();
                    TxtCiudad.Text = registro["ciudad"].ToString();
                    Txtcod_giro.Text = registro["cod_principal"].ToString();
                    Txtoficina_girar.Text = registro["sucursal_principal"].ToString();
                }
            }
            else
            {
                TxtNom_oficina.Text = "";
                TxtCiudad.Text = "";
            }
            con.Close();

            if (TxtNom_oficina.Text.Contains("EMPRESAS"))
            {
                MessageBox.Show("Por favor confirmar con el asesor oficina a girar el cheque", "Importante !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txtcod_giro.Enabled = true;
            }
            else if (TxtNom_oficina.Text.Contains("BANCA PERSONAL"))
            {
                Txtcod_giro.Enabled = false;
            }

            if (TxtNom_oficina.Text== "SAN ANDRES" || TxtNom_oficina.Text == "LETICIA")
            {
                lbexonerar.Visible = true;
                MessageBox.Show("Tener en cuenta que dicha oficina se debe exonerar previo al desembolso");
            }
            else if (TxtNom_oficina.Text == "GENTE BBVA" && cmbDestino.Text== "Compra de Cartera")
            {
                lbexonerar.Visible = true;
                MessageBox.Show("Tener en cuenta que dicha oficina se debe exonerar previo al desembolso");
            }
            else if (TxtNom_oficina.Text == "GENTE BBVA" && cmbDestino.Text == "Cpk Libranza")
            {
                lbexonerar.Visible = true;
                MessageBox.Show("Tener en cuenta que dicha oficina se debe exonerar previo al desembolso");
            }
            else if (TxtNom_oficina.Text == "GENTE BBVA" && cmbDestino.Text == "CPK + RTQ")
            {
                lbexonerar.Visible = true;
                MessageBox.Show("Tener en cuenta que dicha oficina se debe exonerar previo al desembolso");
            }
        }

        private void Txtcod_giro_Validated(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_oficinas WHERE codigo_oficina = @codigo ", con);
            comando.Parameters.AddWithValue("@codigo", Txtcod_giro.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                Txtoficina_girar.Text = registro["sucursal"].ToString();
            }
            con.Close();
        }       
        private void cmbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDestino.Text == "Compra de Cartera" && TxtNom_oficina.Text == "LETICIA")
            {
                lbexonerar.Visible = true;
            }
            else if (cmbDestino.Text == "CPK + RTQ" && TxtNom_oficina.Text == "LETICIA")
            {
                lbexonerar.Visible = true;
            }
            else if (cmbDestino.Text == "Compra de Cartera" && TxtNom_oficina.Text == "SAN ANDRES")
            {
                lbexonerar.Visible = true;
            }
            else if (cmbDestino.Text == "CPK + RTQ" && TxtNom_oficina.Text == "SAN ANDRES")
            {
                lbexonerar.Visible = true;
            }
            else
            {
                lbexonerar.Visible = false;
            }
            if (cmbDestino.Text == "Retanqueo")
            {
                TxtValor_Rtq.Enabled = true;
                TxtRauto.Enabled = true;
            }
            else if (cmbDestino.Text == "CPK + RTQ")
            {
                TxtValor_Rtq.Enabled = true;
                TxtRauto.Enabled = true;
                TxtNom_entidad1.Visible = true;
                Txtobligacion1.Visible = true;
                TxtNit1.Visible = true;
                TxtValor1.Visible = true;
            }
            else if (cmbDestino.Text == "Cpk Libranza")
            {
                TxtNom_entidad1.Visible = true;
                Txtobligacion1.Visible = true;
                TxtNit1.Visible = true;
                TxtValor1.Visible = true;
                TxtValor_Rtq.Enabled = false;
                TxtRauto.Enabled = false;
            }
            else if (cmbDestino.Text == "Compra de Cartera")
            {
                TxtNom_entidad1.Visible = true;
                Txtobligacion1.Visible = true;
                TxtNit1.Visible = true;
                TxtValor1.Visible = true;
                TxtValor_Rtq.Enabled = false;
                TxtRauto.Enabled = false;
            }
            else if (cmbDestino.Text == "Libre Inversion")
            {
                TxtValor_Rtq.Enabled = false;
                TxtRauto.Enabled = false;
                TxtNom_entidad1.Visible = false;
                Txtobligacion1.Visible = false;
                TxtNit1.Visible = false;
                TxtValor1.Visible = false;
                TxtNom_entidad2.Visible = false;
                Txtobligacion2.Visible = false;
                TxtNit2.Visible = false;
                TxtValor2.Visible = false;
                TxtNom_entidad3.Visible = false;
                Txtobligacion3.Visible = false;
                TxtNit3.Visible = false;
                TxtValor3.Visible = false;
                TxtNom_entidad4.Visible = false;
                Txtobligacion4.Visible = false;
                TxtNit4.Visible = false;
                TxtValor4.Visible = false;
                TxtNom_entidad5.Visible = false;
                Txtobligacion5.Visible = false;
                TxtNit5.Visible = false;
                TxtValor5.Visible = false;
                TxtNom_entidad6.Visible = false;
                Txtobligacion6.Visible = false;
                TxtNit6.Visible = false;
                TxtValor6.Visible = false;
                TxtNom_entidad7.Visible = false;
                Txtobligacion7.Visible = false;
                TxtNit7.Visible = false;
                TxtValor7.Visible = false;
                TxtNom_entidad8.Visible = false;
                Txtobligacion8.Visible = false;
                TxtNit8.Visible = false;
                TxtValor8.Visible = false;
            }
            else
            {
                TxtValor_Rtq.Enabled = false;
                TxtRauto.Enabled = false;
            }
        }

        private void TxtNom_oficina_TextChanged(object sender, EventArgs e)
        {
            if (cmbDestino.Text == "Compra de Cartera" && TxtNom_oficina.Text == "LETICIA")
            {
                lbexonerar.Visible = true;
            }
            else if (cmbDestino.Text == "CPK + RTQ" && TxtNom_oficina.Text == "LETICIA")
            {
                lbexonerar.Visible = true;
            }
            else if (cmbDestino.Text == "Compra de Cartera" && TxtNom_oficina.Text == "SAN ANDRES")
            {
                lbexonerar.Visible = true;
            }
            else if (cmbDestino.Text == "CPK + RTQ" && TxtNom_oficina.Text == "SAN ANDRES")
            {
                lbexonerar.Visible = true;
            }
            else
            {
                lbexonerar.Visible = false;
            }
        }

        private void TxtNom_entidad1_Validated(object sender, EventArgs e)
        {
            if (TxtNom_entidad1.Text == "")
            {
                TxtNit1.Text = null;
            }
        }

        private void TxtNom_entidad2_Validated(object sender, EventArgs e)
        {
            if (TxtNom_entidad2.Text == "")
            {
                TxtNit2.Text = null;
            }
        }

        private void TxtNom_entidad3_Validated(object sender, EventArgs e)
        {
            if (TxtNom_entidad3.Text == "")
            {
                TxtNit3.Text = null;
            }
        }

        private void TxtNom_entidad4_Validated(object sender, EventArgs e)
        {
            if (TxtNom_entidad4.Text == "")
            {
                TxtNit4.Text = null;
            }
        }

        private void TxtNom_entidad5_Validated(object sender, EventArgs e)
        {
            if (TxtNom_entidad5.Text == "")
            {
                TxtNit5.Text = null;
            }
        }

        private void TxtNom_entidad6_Validated(object sender, EventArgs e)
        {
            if (TxtNom_entidad6.Text == "")
            {
                TxtNit6.Text = null;
            }
        }

        private void TxtNom_entidad7_Validated(object sender, EventArgs e)
        {
            if (TxtNom_entidad7.Text == "")
            {
                TxtNit7.Text = null;
            }
        }

        private void TxtValor_Rtq_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtValor_Rtq.Text) > 0)
            {
                //TxtValor_Rtq.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor_Rtq.Text));
                TxtValor_Rtq.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtValor_Rtq.Text));
            }
            else if (TxtValor_Rtq.Text == "")
            {
                TxtValor_Rtq.Text = Convert.ToString(0);
            }
        }

        private void cmbCampaña_SelectedIndexChanged(object sender, EventArgs e)
        {            

            if (cmbcampaña.Text == "Campaña CAP" && cmbDestino.Text== "Retanqueo")
            {
                MessageBox.Show("Importante verificar que los retanqueos se encuentren atados y el scoring se encuentre con la marcacion correspondiente.", "Información Importante !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbcampaña.Text == "Campaña CAP" && cmbDestino.Text == "CPK + RTQ")
            {
                MessageBox.Show("Importante verificar que los retanqueos se encuentren atados y el scoring se encuentre con la marcacion correspondiente.", "Información Importante !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }

        private void TxtCuenta_Validated(object sender, EventArgs e)
        {
            string largo = TxtCuenta.Text;
            string length = Convert.ToString(largo.Length);

            if (Convert.ToInt32(length) < 20)
            {
                MessageBox.Show("Numero de la cuenta del cliente no contiene los 20 digitos correspondientes !! por favor revisar");
            }
        }

        private void TxtPeso_Validated(object sender, EventArgs e)
        {
            string extrae_estatura;
            int sobrepeso;
            string resultado;
            extrae_estatura = TxtEstatura.Text.Substring(TxtEstatura.Text.Length - 2);
            sobrepeso = Convert.ToInt32(TxtPeso.Text) - Convert.ToInt32(extrae_estatura);
            resultado = Convert.ToString(sobrepeso);
            if (sobrepeso >= 21)
            {
                MessageBox.Show("Cliente presenta sobrepeso, total diferencia " + resultado + " Kilos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSobrepeso.Text = "Reportar";
                cmbEstado_Reporte.Text = "Pte Preformalizacion";
            }
            else
            {
                cmbSobrepeso.Text = "No Aplica";
            }
        }

        private void Buscar_Entidad(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_entidades WHERE nit_entidad = @nit_entidad ", con);
            comando.Parameters.AddWithValue("@nit_entidad", TxtEntidad.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                lbentidad.Text = registro["nombre_entidad"].ToString();
            }
            else
            {
                lbentidad.Text = "Entidad no creada";
            }
            con.Close();
        }

        private void Cerrar(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form formulario = new FormOrden();
            formulario.Show();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtNom_entidad8_Validated(object sender, EventArgs e)
        {
            if (TxtNom_entidad8.Text == "")
            {
                TxtNit8.Text = null;
            }
        }

        private void TeclaEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void TxtValor6_Validated(object sender, EventArgs e)
        {
            string V_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el valor de la obligacion", "Confirmar valor de la obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic      
            if (V_Obligacion == TxtValor6.Text)
            {
                if (Convert.ToDouble(TxtValor6.Text) > 0)
                {
                    //TxtValor6.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor6.Text));
                    //TxtTotal.Text = string.Format("{0:#,##0.##}", double.Parse(TxtTotal.Text));
                    //TxtSaldo_cliente.Text = string.Format("{0:#,##0.##}", double.Parse(TxtSaldo_cliente.Text));
                    TxtValor6.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtValor6.Text));
                    TxtTotal.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtTotal.Text));
                    TxtSaldo_cliente.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtSaldo_cliente.Text));
                }
                else if (TxtValor6.Text == "")
                {
                    TxtValor6.Text = Convert.ToString(0);
                }
            }
            else
            {
                MessageBox.Show("Valor de la obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtValor6.Text = "";
                TxtValor7.Focus();
            }
        }

        private void TxtValor7_Validated(object sender, EventArgs e)
        {
            string V_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el valor de la obligacion", "Confirmar valor de la obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic      
            if (V_Obligacion == TxtValor7.Text)
            {
                if (Convert.ToDouble(TxtValor7.Text) > 0)
                {
                    //TxtValor7.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor7.Text));
                    //TxtTotal.Text = string.Format("{0:#,##0.##}", double.Parse(TxtTotal.Text));
                    //TxtSaldo_cliente.Text = string.Format("{0:#,##0.##}", double.Parse(TxtSaldo_cliente.Text));
                    TxtValor7.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtValor7.Text));
                    TxtTotal.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtTotal.Text));
                    TxtSaldo_cliente.Text = string.Format("{0:#,##0.#0}", double.Parse(TxtSaldo_cliente.Text));
                }
                else if (TxtValor7.Text == "")
                {
                    TxtValor7.Text = Convert.ToString(0);
                }
            }
            else
            {
                MessageBox.Show("Valor de la obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtValor7.Text = "";
                TxtValor7.Focus();
            }
        }

        private void TxtValor6_TextChanged_1(object sender, EventArgs e)
        {
            if (double.TryParse(TxtValor6.Text, out cpk6))
                Sumar1();
            else
                TxtValor6.Text = cpk6.ToString();
        }

        private void TxtValor7_TextChanged_1(object sender, EventArgs e)
        {
            if (double.TryParse(TxtValor7.Text, out cpk7))
                Sumar1();
            else
                TxtValor7.Text = cpk7.ToString();
        }

        private void TxtId_gestor_Validated(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM gestores WHERE Cedula_Gestor = @Cedula_Gestor ", con);
            comando.Parameters.AddWithValue("@Cedula_Gestor", TxtId_gestor.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                TxtNom_gestor.Text = registro["Nombre_Gestor"].ToString();
            }
            else
            {
                TxtNom_gestor.Text = null;
                MessageBox.Show("Asesor no se encuentra registrado, por favor reportar");
                con.Close();
            }
            con.Close();
        }

        private void TxtNit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TxtNit1.ReadOnly = true;
        }

        private void TxtNit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TxtNit2.ReadOnly = true;
        }

        private void TxtNit3_KeyPress(object sender, KeyPressEventArgs e)
        {
            TxtNit3.ReadOnly = true;
        }

        private void TxtNit4_KeyPress(object sender, KeyPressEventArgs e)
        {
            TxtNit4.ReadOnly = true;
        }

        private void TxtNit5_KeyPress(object sender, KeyPressEventArgs e)
        {
            TxtNit5.ReadOnly = true;
        }

        private void TxtNit6_KeyPress(object sender, KeyPressEventArgs e)
        {
            TxtNit6.ReadOnly = true;
        }

        private void TxtNit7_KeyPress(object sender, KeyPressEventArgs e)
        {
            TxtNit7.ReadOnly = true;
        }

        private void TxtNit8_KeyPress(object sender, KeyPressEventArgs e)
        {
            TxtNit8.ReadOnly = true;
        }

        private void TxtValor5_TextChanged_1(object sender, EventArgs e)
        {
            if (double.TryParse(TxtValor5.Text, out cpk5))
                Sumar1();
            else
                TxtValor5.Text = cpk5.ToString();
        }

        private void Txtobligacion1_Validated(object sender, EventArgs e)
        {
            string N_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el numero de obligacion", "Confirmar Numero de obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (N_Obligacion == Txtobligacion1.Text)
            {
                TxtNom_entidad1.Focus();
            }
            else
            {
                MessageBox.Show("Numero de obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txtobligacion1.Text = "";
                Txtobligacion1.Focus();
            }
        }

        private void Txtobligacion2_Validated(object sender, EventArgs e)
        {
            string N_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el numero de obligacion", "Confirmar Numero de obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (N_Obligacion == Txtobligacion2.Text)
            {
                TxtNom_entidad2.Focus();
            }
            else
            {
                MessageBox.Show("Numero de obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txtobligacion2.Text = "";
                Txtobligacion2.Focus();
            }
        }

        private void Txtobligacion3_Validated(object sender, EventArgs e)
        {
            string N_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el numero de obligacion", "Confirmar Numero de obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (N_Obligacion == Txtobligacion3.Text)
            {
                TxtNom_entidad3.Focus();
            }
            else
            {
                MessageBox.Show("Numero de obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txtobligacion3.Text = "";
                Txtobligacion3.Focus();
            }
        }

        private void Txtobligacion4_Validated(object sender, EventArgs e)
        {
            string N_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el numero de obligacion", "Confirmar Numero de obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (N_Obligacion == Txtobligacion4.Text)
            {
                TxtNom_entidad4.Focus();
            }
            else
            {
                MessageBox.Show("Numero de obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txtobligacion4.Text = "";
                Txtobligacion4.Focus();
            }
        }

        private void Txtobligacion5_Validated(object sender, EventArgs e)
        {
            string N_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el numero de obligacion", "Confirmar Numero de obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (N_Obligacion == Txtobligacion5.Text)
            {
                TxtNom_entidad5.Focus();
            }
            else
            {
                MessageBox.Show("Numero de obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txtobligacion5.Text = "";
                Txtobligacion5.Focus();
            }
        }

        private void Txtobligacion6_Validated(object sender, EventArgs e)
        {
            string N_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el numero de obligacion", "Confirmar Numero de obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (N_Obligacion == Txtobligacion6.Text)
            {
                TxtNom_entidad6.Focus();
            }
            else
            {
                MessageBox.Show("Numero de obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txtobligacion6.Text = "";
                Txtobligacion6.Focus();
            }
        }

        private void Txtobligacion7_Validated(object sender, EventArgs e)
        {
            string N_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el numero de obligacion", "Confirmar Numero de obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (N_Obligacion == Txtobligacion7.Text)
            {
                TxtNom_entidad7.Focus();
            }
            else
            {
                MessageBox.Show("Numero de obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txtobligacion7.Text = "";
                Txtobligacion7.Focus();
            }
        }

        private void Txtobligacion8_Validated(object sender, EventArgs e)
        {
            string N_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el numero de obligacion", "Confirmar Numero de obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (N_Obligacion == Txtobligacion8.Text)
            {
                TxtNom_entidad8.Focus();
            }
            else
            {
                MessageBox.Show("Numero de obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txtobligacion8.Text = "";
                Txtobligacion8.Focus();
            }
        }
        private void TxtConvenio_Validated(object sender, EventArgs e)
        {
            string cadena = TxtConvenio.Text;
            int largo = TxtConvenio.Text.Length;

            if (largo > 2)
            {
                string codigo_convenio = cadena.Substring(0, 3);
                if (codigo_convenio == "FCU")
                {
                    MessageBox.Show("Todas las operaciones se segmentaran a la oficina 583 Lourdes siempre que los clientes sean de Bogotá.");
                }
                else if (codigo_convenio == "CTC")
                {
                    MessageBox.Show("Todas las operaciones de Bogotá que en el formulario de vinculación registre la oficina 765 Agencia telefónica /23 Puente Largo se segmentaran a etas oficina sin aplicar política.");
                }
                else if (codigo_convenio == "FPC")
                {
                    MessageBox.Show(" Sino registra en la base de principalidad deben ser sementadas a la oficina 832 Congreso de la republica");
                }
                else if (codigo_convenio == "RBC")
                {
                    MessageBox.Show("Todas las operaciones sin principalidad se segmentaran a la oficina 601 MINIBANCO, las operaciones fuera de Bogotá se segmentaran a la oficina que indique el formulario.");
                }
            }
        }

        private void TxtOficina_Formulario_Validated(object sender, EventArgs e)
        {

            int largo = TxtOficina_Formulario.Text.Length;
            int Oficina = Convert.ToInt32(TxtOficina_Formulario.Text);
            if (largo >= 1)
            {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_oficinas WHERE codigo_oficina = @codigo ", con);
                comando.Parameters.AddWithValue("@codigo", TxtOficina_Formulario.Text);
                con.Open();
                MySqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    estado_oficina = registro["estado_oficina"].ToString();

                    if (estado_oficina == "Cerrada")
                    {
                        MessageBox.Show("Oficina a segmentar se encuentra cerrada, por favor revisar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        TxtSucursal_Formulario.Text = registro["sucursal"].ToString();
                        TxtCiudad_Formulario.Text = registro["ciudad"].ToString();
                    }
                }
                else
                {
                    TxtSucursal_Formulario.Text = "";
                    TxtCiudad_Formulario.Text = "";
                }
                con.Close();


                if (Oficina == 994)
                {
                    TxtOficina_Segmentar.Text = "994 AGENCIA CANTÓN NORTE";
                    TxtOficina_Retanqueo.Enabled = false;
                    TxtOficina_Principalidad.Enabled = false;
                    cmbEstado_Principalidad.Enabled = false;
                }
                else if (Oficina == 65)
                {
                    TxtOficina_Segmentar.Text = "65 BBVA SIEMENS";
                    TxtOficina_Retanqueo.Enabled = false;
                    TxtOficina_Principalidad.Enabled = false;
                    cmbEstado_Principalidad.Enabled = false;
                }
                else if (Oficina == 26)
                {
                    TxtOficina_Segmentar.Text = "26 ALBANIA";
                    TxtOficina_Retanqueo.Enabled = false;
                    TxtOficina_Principalidad.Enabled = false;
                    cmbEstado_Principalidad.Enabled = false;
                }
                else if (Oficina == 222)
                {
                    TxtOficina_Segmentar.Text = "222 AGENCIA BBVA TOLEMAIDA";
                    TxtOficina_Retanqueo.Enabled = false;
                    TxtOficina_Principalidad.Enabled = false;
                    cmbEstado_Principalidad.Enabled = false;
                }
                else if (Oficina == 821)
                {
                    TxtOficina_Segmentar.Text = "821 AGENCIA SCHLUMBERGER";
                    TxtOficina_Retanqueo.Enabled = false;

                    TxtOficina_Principalidad.Enabled = false;
                    cmbEstado_Principalidad.Enabled = false;
                }
                else if (Oficina == 755)
                {
                    TxtOficina_Segmentar.Text = "755 AGENCIA LARANDIA";
                    TxtOficina_Retanqueo.Enabled = false;
                    TxtOficina_Principalidad.Enabled = false;
                    cmbEstado_Principalidad.Enabled = false;
                }
                else
                {
                    TxtOficina_Principalidad.Enabled = true;
                    cmbEstado_Principalidad.Enabled = true;
                }
                if (cmbPolitica.Text == "Retanqueo")
                {
                    TxtOficina_Principalidad.Enabled = false;
                    cmbEstado_Principalidad.Enabled = false;
                }
                else if (cmbPolitica.Text == "Otros Destinos")
                {
                    TxtOficina_Principalidad.Enabled = true;
                    cmbEstado_Principalidad.Enabled = true;
                }
            }
        }

        private void cmbPolitica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPolitica.Text == "Retanqueo")
            {
                TxtOficina_Formulario.Text = "";
                TxtOficina_Principalidad.Text = "";
                cmbEstado_Principalidad.Text = "";
                TxtOficina_Retanqueo.Text = "";
                cmbCiudad_Residencia_Cliente.Text = "";
                TxtSucursal_Formulario.Text = "";
                TxtCiudad_Formulario.Text = "";
                TxtSucursal_Principalidad.Text = "";
                TxtCiudad_Principalidad.Text = "";
                TxtSucursal_Retanqueo.Text = "";
                TxtCiudad_Retanqueo.Text = "";
                TxtOficina_Segmentar.Text = "";

                TxtOficina_Retanqueo.Enabled = true;
                TxtOficina_Formulario.Enabled = true;
                TxtOficina_Principalidad.Enabled = false;
            }
            else if (cmbPolitica.Text == "Otros Destinos")
            {
                TxtOficina_Formulario.Text = "";
                TxtOficina_Principalidad.Text = "";
                cmbEstado_Principalidad.Text = "";
                TxtOficina_Retanqueo.Text = "";
                cmbCiudad_Residencia_Cliente.Text = "";
                TxtSucursal_Formulario.Text = "";
                TxtCiudad_Formulario.Text = "";
                TxtSucursal_Principalidad.Text = "";
                TxtCiudad_Principalidad.Text = "";
                TxtSucursal_Retanqueo.Text = "";
                TxtCiudad_Retanqueo.Text = "";
                TxtOficina_Segmentar.Text = "";
                TxtOficina_Principalidad.Enabled = true;
                TxtOficina_Retanqueo.Enabled = false;
                TxtOficina_Formulario.Enabled = true;
            }
        }

        private void TxtOficina_Retanqueo_Validated(object sender, EventArgs e)
        {
            int largo = TxtOficina_Retanqueo.Text.Length;
            int Oficina = Convert.ToInt32(TxtOficina_Retanqueo.Text);
            if (largo >= 1)
            {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_oficinas WHERE codigo_oficina = @codigo ", con);
                comando.Parameters.AddWithValue("@codigo", TxtOficina_Retanqueo.Text);
                con.Open();
                MySqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    estado_oficina = registro["estado_oficina"].ToString();

                    if (estado_oficina == "Cerrada")
                    {
                        MessageBox.Show("Oficina del retanqueo se encuentra cerrada, por favor revisar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        TxtSucursal_Retanqueo.Text = registro["sucursal"].ToString();
                        TxtCiudad_Retanqueo.Text = registro["ciudad"].ToString();
                    }
                }
                else
                {
                    TxtSucursal_Retanqueo.Text = "";
                    TxtCiudad_Retanqueo.Text = "";
                }
                con.Close();

                if (cmbCiudad_Residencia_Cliente.Text == "")
                {
                    MessageBox.Show("Debera seleccionar ciudad de residencia del cliente");
                }
                else
                {
                    if (cmbCiudad_Residencia_Cliente.Text == TxtCiudad_Retanqueo.Text)
                    {
                        TxtOficina_Segmentar.Text = TxtOficina_Retanqueo.Text + " " + TxtSucursal_Retanqueo.Text;
                    }
                    else
                    {
                        TxtOficina_Segmentar.Text = TxtOficina_Formulario.Text + " " + TxtSucursal_Formulario.Text;
                    }
                }
            }
        }

        private void TxtOficina_Principalidad_Validated(object sender, EventArgs e)
        {
            int largo = TxtOficina_Principalidad.Text.Length;
            int Oficina = Convert.ToInt32(TxtOficina_Principalidad.Text);
            if (largo >= 1)
            {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_oficinas WHERE codigo_oficina = @codigo ", con);
                comando.Parameters.AddWithValue("@codigo", TxtOficina_Principalidad.Text);
                con.Open();
                MySqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    estado_oficina = registro["estado_oficina"].ToString();

                    if (estado_oficina == "Cerrada")
                    {
                        MessageBox.Show("Oficina principalidad se encuentra cerrada, por favor revisar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        TxtSucursal_Principalidad.Text = registro["sucursal"].ToString();
                        TxtCiudad_Principalidad.Text = registro["ciudad"].ToString();
                    }
                }
                else
                {
                    TxtSucursal_Principalidad.Text = "";
                    TxtCiudad_Principalidad.Text = "";
                }
                con.Close();
            }
        }

        private void cmbEstado_Principalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPolitica.Text == "Otros Destinos")
            {
                if (cmbCiudad_Residencia_Cliente.Text == "")
                {
                    MessageBox.Show("Debera seleccionar ciudad de residencia del cliente");
                }
                else
                {
                    if (cmbEstado_Principalidad.Text == "NA")
                    {
                        if (cmbCiudad_Residencia_Cliente.Text == "Medellin")
                        {
                            if (TxtOficina_Principalidad.Text == "266" || TxtOficina_Principalidad.Text == "394" || TxtOficina_Principalidad.Text == "416" || TxtOficina_Principalidad.Text == "757")
                            {
                                TxtOficina_Segmentar.Text = TxtOficina_Principalidad.Text + " " + TxtSucursal_Principalidad.Text;
                            }
                            else
                            {
                                if (TxtCiudad_Formulario.Text == TxtCiudad_Principalidad.Text)
                                {
                                    TxtOficina_Segmentar.Text = TxtOficina_Principalidad.Text + " " + TxtSucursal_Principalidad.Text;
                                }
                                else
                                {
                                    TxtOficina_Segmentar.Text = TxtOficina_Formulario.Text + " " + TxtSucursal_Formulario.Text;
                                }
                            }
                        }
                        else
                        {
                            if (cmbCiudad_Residencia_Cliente.Text == TxtCiudad_Principalidad.Text)
                            {
                                TxtOficina_Segmentar.Text = TxtOficina_Principalidad.Text + " " + TxtSucursal_Principalidad.Text;
                            }
                            else
                            {
                                TxtOficina_Segmentar.Text = TxtOficina_Formulario.Text + " " + TxtSucursal_Formulario.Text;
                            }
                        }
                    }
                    else if (cmbEstado_Principalidad.Text == "DTN" || cmbEstado_Principalidad.Text == "INMOVILIZADA")
                    {
                        TxtOficina_Segmentar.Text = TxtOficina_Formulario.Text + " " + TxtSucursal_Formulario.Text;
                    }
                }
            }
        }

        void LimpiarTextbox(GroupBox Grupo)
        {
            //recorre todos los textbox que se encuentran dentro de un groupbox
            TextBox caja = default(TextBox);
            foreach (Control ctrl in Grupo.Controls)
            {
                caja = ctrl as TextBox;
                if ((caja != null))
                {
                    caja.Clear();
                }
            }
        }
        private void BtnLimpiar_Carteras_Click(object sender, EventArgs e)
        {
            LimpiarTextbox(groupBox4);
            TxtValor1.Text = "";
        }

        private void dtpFecha_Nacimiento_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFecha_Nacimiento.Text != "2021-01-01")
            {
                DateTime nacimiento = Convert.ToDateTime(dtpFecha_Nacimiento.Text); //Fecha de nacimiento del cliente.
                int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                TxtEdad_Cliente.Text = Convert.ToString(edad);
            }         
        }

        private void BtnVer_Antecedentes_Click(object sender, EventArgs e)
        {
            Form formulario = new Reporte_Seguros();
            formulario.Show();
        }

        private void cmbFormato_Seguros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormato_Seguros.Text == "Enfermedad")
            {
                MessageBox.Show("Validar cuadro de antecedentes y revisar si aplica o no reporte al area de Seguros BBVA");
                cmbReporte_Enfermedad.Text = "";
            }
            else
            {
                cmbReporte_Enfermedad.Text = "No Aplica";
            }

            if (cmbFormato_Seguros.Text == "No Aplica" && cmbReporte_Enfermedad.Text == "No Aplica" && cmbSeguros_Monto.Text == "No Aplica" && cmbSobrepeso.Text == "No Aplica")
            {
                cmbEstado_Reporte.Text = "No Aplica";
            }
            else if (cmbFormato_Seguros.Text == "No Aplica" && cmbReporte_Enfermedad.Text == "Reportar" && cmbSeguros_Monto.Text == "No Aplica" && cmbSobrepeso.Text == "No Aplica")
            {
                cmbEstado_Reporte.Text = "No Aplica";
            }
        }

        private void cmbReporte_Enfermedad_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbFormato_Seguros.Text == "No Aplica" && cmbReporte_Enfermedad.Text == "No Aplica" && cmbSeguros_Monto.Text == "No Aplica" && cmbSobrepeso.Text == "No Aplica")
            {
                cmbEstado_Reporte.Text = "No Aplica";
            }
        }

        private void cmbSeguros_Monto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormato_Seguros.Text == "No Aplica" && cmbReporte_Enfermedad.Text == "No Aplica" && cmbSeguros_Monto.Text == "No Aplica" && cmbSobrepeso.Text == "No Aplica")
            {
                cmbEstado_Reporte.Text = "No Aplica";
            }
        }

        private void cmbSobrepeso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormato_Seguros.Text == "No Aplica" && cmbReporte_Enfermedad.Text == "No Aplica" && cmbSeguros_Monto.Text == "No Aplica" && cmbSobrepeso.Text == "No Aplica")
            {
                cmbEstado_Reporte.Text = "No Aplica";
            }
        }

        private void BtnAñadir_Carteras_Click(object sender, EventArgs e)
        {
            if (cmbDestino.Text == "CPK + RTQ" || cmbDestino.Text == "Compra de Cartera" || cmbDestino.Text == "Retanqueo" || cmbDestino.Text == "Cpk Libranza")
            {
                if (Txtobligacion1.Visible == false)
                {
                    Txtobligacion1.Visible = true;
                    TxtNom_entidad1.Visible = true;
                    TxtNit1.Visible = true;
                    TxtValor1.Visible = true;
                }
                else if (Txtobligacion1.Visible == true && Txtobligacion2.Visible == false)
                {
                    TxtNom_entidad2.Visible = true;
                    Txtobligacion2.Visible = true;
                    TxtNit2.Visible = true;
                    TxtValor2.Visible = true;
                }
                else if (Txtobligacion1.Visible == true && Txtobligacion2.Visible == true && Txtobligacion3.Visible == false)
                {
                    TxtNom_entidad3.Visible = true;
                    Txtobligacion3.Visible = true;
                    TxtNit3.Visible = true;
                    TxtValor3.Visible = true;
                }
                else if (Txtobligacion1.Visible == true && Txtobligacion2.Visible == true && Txtobligacion3.Visible == true
                      && Txtobligacion4.Visible == false)
                {
                    TxtNom_entidad4.Visible = true;
                    Txtobligacion4.Visible = true;
                    TxtNit4.Visible = true;
                    TxtValor4.Visible = true;
                }
                else if (Txtobligacion1.Visible == true && Txtobligacion2.Visible == true && Txtobligacion3.Visible == true
                      && Txtobligacion4.Visible == true && Txtobligacion5.Visible == false)
                {
                    TxtNom_entidad5.Visible = true;
                    Txtobligacion5.Visible = true;
                    TxtNit5.Visible = true;
                    TxtValor5.Visible = true;
                }
                else if (Txtobligacion1.Visible == true && Txtobligacion2.Visible == true && Txtobligacion3.Visible == true
                      && Txtobligacion4.Visible == true && Txtobligacion5.Visible == true && Txtobligacion6.Visible == false)
                {
                    TxtNom_entidad6.Visible = true;
                    Txtobligacion6.Visible = true;
                    TxtNit6.Visible = true;
                    TxtValor6.Visible = true;
                }
                else if (Txtobligacion1.Visible == true && Txtobligacion2.Visible == true && Txtobligacion3.Visible == true
                      && Txtobligacion4.Visible == true && Txtobligacion5.Visible == true && Txtobligacion6.Visible == true
                      && Txtobligacion7.Visible == false)
                {
                    TxtNom_entidad7.Visible = true;
                    Txtobligacion7.Visible = true;
                    TxtNit7.Visible = true;
                    TxtValor7.Visible = true;
                }
                else if (Txtobligacion1.Visible == true && Txtobligacion2.Visible == true && Txtobligacion3.Visible == true
                      && Txtobligacion4.Visible == true && Txtobligacion5.Visible == true && Txtobligacion6.Visible == true
                      && Txtobligacion7.Visible == true && Txtobligacion8.Visible == false)
                {
                    TxtNom_entidad8.Visible = true;
                    Txtobligacion8.Visible = true;
                    TxtNit8.Visible = true;
                    TxtValor8.Visible = true;
                }
            }
            else if (cmbDestino.Text == "Libre Inversion")
            {
                MessageBox.Show("Destino del credito no admite cpk, por favor revisar!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Previo a agregar carteras por favor seleccionar destino de la operación!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
   
        private void TxtPlazo_solicitado_Validated(object sender, EventArgs e)
        {
            string N_Obligacion = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el numero de obligacion", "Confirmar Numero de obligacion", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (N_Obligacion == Txtobligacion1.Text)
            {
                TxtNom_entidad1.Focus();
            }
            else
            {
                MessageBox.Show("Numero de obligacion no es igual al diligenciado en el campo correspondiente, por favor revisar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txtobligacion1.Text = "";
                Txtobligacion1.Focus();
            }
        }

        private void Txtplazo_aprobado_Validated(object sender, EventArgs e)
        {
            string Plazo = Microsoft.VisualBasic.Interaction.InputBox("Digite el plazo solicitado por el cliente", "Plazo solicitado por el cliente", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (Plazo != Txtplazo_aprobado.Text)
            {
                MessageBox.Show("Plazo solicitado por el cliente vs plazo aprobado son diferentes, proceder a confirmar condiciones con el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbcambio_condiciones.Text = "Pendiente";
            }
            else
            {
                cmbcambio_condiciones.Text = "No Aplica";
            }          
        }

        private void Btn_segmentacion_Click(object sender, EventArgs e)
        {
            Form formulario = new Esquema_segmentacion();
            formulario.Show();
        }
        private void TxtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtSaldo_cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Modificar(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtValor8_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(TxtValor8.Text, out cpk8))
                Sumar1();
            else
                TxtValor8.Text = cpk8.ToString();
        }

        private void TxtValor7_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(TxtValor7.Text, out cpk7))
                Sumar1();
            else
                TxtValor7.Text = cpk7.ToString();
        }

        private void TxtValor6_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(TxtValor6.Text, out cpk6))
                Sumar1();
            else
                TxtValor6.Text = cpk6.ToString();
        }

        private void TxtValor5_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(TxtValor5.Text, out cpk5))
                Sumar1();
            else
                TxtValor5.Text = cpk5.ToString();
        }

        private void TxtValor4_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(TxtValor4.Text, out cpk4))
                Sumar1();
            else
                TxtValor4.Text = cpk4.ToString();
        }

        private void TxtValor3_TextChanged(object sender, EventArgs e)
        {

            if (double.TryParse(TxtValor3.Text, out cpk3))
                Sumar1();
            else
                TxtValor3.Text = cpk3.ToString();
        }

        private void TxtValor2_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(TxtValor2.Text, out cpk2))
                Sumar1();
            else
                TxtValor2.Text = cpk2.ToString();
        }

        private void TxtValor1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(TxtValor1.Text, out cpk1))
                Sumar1();
            else
                TxtValor1.Text = cpk1.ToString();
        }

        private void Sumar1()
        {
            cpktotal = cpk1+cpk2+cpk3+cpk4+cpk5+cpk6+cpk7+cpk8;
            TxtTotal.Text = cpktotal.ToString();
        }
      
        private void Restar1()
        {
            cpksaldo = cpk10 - cpk9;
            TxtSaldo_cliente.Text = cpksaldo.ToString();            
        }
    }
}
                        