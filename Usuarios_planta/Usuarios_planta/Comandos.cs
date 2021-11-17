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



namespace Usuarios_planta
{
    class Comandos
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");




        public void Accesso_Aplicacion()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("control_acceso_aplicaciones", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Usuario", usuario.Nombre);
                cmd.Parameters.AddWithValue("@_Aplicacion", "Orden de giro");
                cmd.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public void Antecedentes_Reportes_Seguros(DataGridView dgvDatos_Seguros)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("antecedentes_reportes_seguros", con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvDatos_Seguros.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Guardar_Validacion_desembolso(TextBox TxtRadicado, TextBox TxtCedula, TextBox TxtNombre, DateTimePicker dtpFecha_Nacimiento, TextBox TxtEdad_Cliente, TextBox TxtEstatura, TextBox TxtPeso, TextBox TxtCuenta, DateTimePicker dtpfecha_aprobado_vb, TextBox TxtScoring, TextBox TxtValor_aprobado,
            TextBox Txtplazo_aprobado, ComboBox cmbDestino, TextBox TxtRauto, TextBox TxtValor_Rtq, TextBox TxtConvenio, TextBox TxtCod_oficina, TextBox TxtNom_oficina, TextBox TxtCiudad,
            TextBox Txtcod_giro, TextBox Txtoficina_girar, TextBox TxtId_gestor, TextBox TxtNom_gestor, ComboBox cmbCoordinador, ComboBox cmbDactiloscopia, ComboBox cmbG_telefonica, ComboBox cmbcampaña,
            TextBox Txtobligacion1, TextBox TxtNom_entidad1, TextBox TxtNit1, TextBox TxtValor1, TextBox Txtobligacion2, TextBox TxtNom_entidad2, TextBox TxtNit2, TextBox TxtValor2, TextBox Txtobligacion3, TextBox TxtNom_entidad3, TextBox TxtNit3, TextBox TxtValor3,
            TextBox Txtobligacion4, TextBox TxtNom_entidad4, TextBox TxtNit4, TextBox TxtValor4, TextBox Txtobligacion5, TextBox TxtNom_entidad5, TextBox TxtNit5, TextBox TxtValor5,
            TextBox Txtobligacion6, TextBox TxtNom_entidad6, TextBox TxtNit6, TextBox TxtValor6, TextBox Txtobligacion7, TextBox TxtNom_entidad7, TextBox TxtNit7, TextBox TxtValor7,
            TextBox Txtobligacion8, TextBox TxtNom_entidad8, TextBox TxtNit8, TextBox TxtValor8, ComboBox cmbFormato_Seguros,ComboBox cmbReporte_Enfermedad,ComboBox cmbSeguros_Monto,
            ComboBox cmbSobrepeso,ComboBox cmbEstado_Reporte,TextBox TxtTotal, TextBox TxtSaldo_cliente, ComboBox cmbestado, TextBox TxtPendientes)
        {

            con.Open();
            MySqlCommand cmd = new MySqlCommand("guardar_validacion_desembolso", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente 
            try
            {
                //dtpfecha_aprobado_vb.Format = DateTimePickerFormat.Custom;
                //dtpfecha_aprobado_vb.CustomFormat = "yyyy-MM-dd";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_radicado", TxtRadicado.Text);
                cmd.Parameters.AddWithValue("@_cedula", TxtCedula.Text);
                cmd.Parameters.AddWithValue("@_nombre", TxtNombre.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Nacimiento_Cliente", dtpFecha_Nacimiento.Text);
                cmd.Parameters.AddWithValue("@_Edad_Cliente", TxtEdad_Cliente.Text);
                cmd.Parameters.AddWithValue("@_cuenta", TxtCuenta.Text);
                cmd.Parameters.AddWithValue("@_fecha_aprobacion_vb", dtpfecha_aprobado_vb.Text);
                cmd.Parameters.AddWithValue("@_estatura", TxtEstatura.Text);
                cmd.Parameters.AddWithValue("@_peso", TxtPeso.Text);
                cmd.Parameters.AddWithValue("@_scoring", TxtScoring.Text);
                if (TxtValor_aprobado.Text != "")
                {
                    cmd.Parameters.AddWithValue("@_valor_aprobado", string.Format("{0:#}", double.Parse(TxtValor_aprobado.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_valor_aprobado", TxtValor_aprobado.Text);
                }          
                //cmd.Parameters.AddWithValue("@_plazo_solicitado", TxtPlazo_solicitado.Text);
                cmd.Parameters.AddWithValue("@_plazo_aprobado", Txtplazo_aprobado.Text);
                cmd.Parameters.AddWithValue("@_destino", cmbDestino.Text);
                //cmd.Parameters.AddWithValue("@_cambio_condiciones", cmbcambio_condiciones.Text);
                cmd.Parameters.AddWithValue("@_r_Automatico", TxtRauto.Text);
                if (TxtValor_Rtq.Text!="")
                {
                    cmd.Parameters.AddWithValue("@_valor_r_Automatico", string.Format("{0:#,##0.##}", double.Parse(TxtValor_Rtq.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_valor_r_Automatico", TxtValor_Rtq.Text);                   
                }                
                cmd.Parameters.AddWithValue("@_convenio", TxtConvenio.Text);
                cmd.Parameters.AddWithValue("@_codigo_oficina", TxtCod_oficina.Text);
                cmd.Parameters.AddWithValue("@_sucursal", TxtNom_oficina.Text);
                cmd.Parameters.AddWithValue("@_ciudad", TxtCiudad.Text);
                cmd.Parameters.AddWithValue("@_oficina_girar", Txtcod_giro.Text);
                cmd.Parameters.AddWithValue("@_sucursal_girar", Txtoficina_girar.Text);
                cmd.Parameters.AddWithValue("@_cedula_gestor", TxtId_gestor.Text);
                cmd.Parameters.AddWithValue("@_nombre_gestor", TxtNom_gestor.Text);
                cmd.Parameters.AddWithValue("@_nombre_coordinador", cmbCoordinador.Text);
                cmd.Parameters.AddWithValue("@_dactiloscopia", cmbDactiloscopia.Text);
                cmd.Parameters.AddWithValue("@_g_telefonica", cmbG_telefonica.Text);
                cmd.Parameters.AddWithValue("@_campaña", cmbcampaña.Text);                
                cmd.Parameters.AddWithValue("@_numero_obligacion1", Txtobligacion1.Text);
                cmd.Parameters.AddWithValue("@_nit_entidad1", TxtNit1.Text);
                cmd.Parameters.AddWithValue("@_nombre_entidad1", TxtNom_entidad1.Text);
                if (TxtValor1.Text!="")
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera1", string.Format("{0:#,##0.##}", double.Parse(TxtValor1.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera1", TxtValor1.Text);
                }                
                cmd.Parameters.AddWithValue("@_numero_obligacion2", Txtobligacion2.Text);
                cmd.Parameters.AddWithValue("@_nit_entidad2", TxtNit2.Text);
                cmd.Parameters.AddWithValue("@_nombre_entidad2", TxtNom_entidad2.Text);
                if (TxtValor2.Text != "")
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera2", string.Format("{0:#,##0.##}", double.Parse(TxtValor2.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera2", TxtValor2.Text);
                }          
                cmd.Parameters.AddWithValue("@_numero_obligacion3", Txtobligacion3.Text);
                cmd.Parameters.AddWithValue("@_nit_entidad3", TxtNit3.Text);
                cmd.Parameters.AddWithValue("@_nombre_entidad3", TxtNom_entidad3.Text);
                if (TxtValor3.Text != "")
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera3", string.Format("{0:#,##0.##}", double.Parse(TxtValor3.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera3", TxtValor3.Text);
                }          
                cmd.Parameters.AddWithValue("@_numero_obligacion4", Txtobligacion4.Text);
                cmd.Parameters.AddWithValue("@_nit_entidad4", TxtNit4.Text);
                cmd.Parameters.AddWithValue("@_nombre_entidad4", TxtNom_entidad4.Text);
                if (TxtValor4.Text != "")
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera4", string.Format("{0:#,##0.##}", double.Parse(TxtValor4.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera4", TxtValor4.Text);
                }          
                cmd.Parameters.AddWithValue("@_numero_obligacion5", Txtobligacion5.Text);
                cmd.Parameters.AddWithValue("@_nit_entidad5", TxtNit5.Text);
                cmd.Parameters.AddWithValue("@_nombre_entidad5", TxtNom_entidad5.Text);                
                if (TxtValor5.Text != "")
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera5", string.Format("{0:#,##0.##}", double.Parse(TxtValor5.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera5", TxtValor5.Text);
                }
                cmd.Parameters.AddWithValue("@_numero_obligacion6", Txtobligacion6.Text);
                cmd.Parameters.AddWithValue("@_nit_entidad6", TxtNit6.Text);
                cmd.Parameters.AddWithValue("@_nombre_entidad6", TxtNom_entidad6.Text);                
                if (TxtValor6.Text != "")
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera6", string.Format("{0:#,##0.##}", double.Parse(TxtValor6.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera6", TxtValor6.Text);
                }                
                cmd.Parameters.AddWithValue("@_numero_obligacion7", Txtobligacion7.Text);
                cmd.Parameters.AddWithValue("@_nit_entidad7", TxtNit7.Text);
                cmd.Parameters.AddWithValue("@_nombre_entidad7", TxtNom_entidad7.Text);
                if (TxtValor7.Text != "")
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera7", string.Format("{0:#,##0.##}", double.Parse(TxtValor7.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera7", TxtValor7.Text);
                }
                cmd.Parameters.AddWithValue("@_numero_obligacion8", Txtobligacion8.Text);
                cmd.Parameters.AddWithValue("@_nit_entidad8", TxtNit8.Text);
                cmd.Parameters.AddWithValue("@_nombre_entidad8", TxtNom_entidad8.Text);
                if (TxtValor8.Text != "")
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera8", string.Format("{0:#,##0.##}", double.Parse(TxtValor8.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_valor_cartera8", TxtValor8.Text);
                }
                if (TxtTotal.Text != "")
                {
                    cmd.Parameters.AddWithValue("@_total_cpk", string.Format("{0:#,##0.##}", double.Parse(TxtTotal.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_total_cpk", TxtTotal.Text);
                }
                cmd.Parameters.AddWithValue("@_Formato_Seguros", cmbFormato_Seguros.Text);
                cmd.Parameters.AddWithValue("@_Enfermedad", cmbReporte_Enfermedad.Text);
                cmd.Parameters.AddWithValue("@_Reporte_Monto", cmbSeguros_Monto.Text);
                cmd.Parameters.AddWithValue("@_Reporte_Sobrepeso", cmbSobrepeso.Text);
                cmd.Parameters.AddWithValue("@_Preformalizacion_Seguros", cmbEstado_Reporte.Text);
                if (TxtSaldo_cliente.Text != "")
                {
                    cmd.Parameters.AddWithValue("@_saldo_cliente", string.Format("{0:#,##0.##}", double.Parse(TxtSaldo_cliente.Text)));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@_saldo_cliente", TxtSaldo_cliente.Text);
                }
                cmd.Parameters.AddWithValue("@_estado", cmbestado.Text);
                cmd.Parameters.AddWithValue("@_pendientes", TxtPendientes.Text);
                cmd.Parameters.AddWithValue("@_nombre_funcionario", usuario.Nombre);
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Información Registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //dtpfecha_aprobado_vb.CustomFormat = "dd/MM/yyyy";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Guardar_Formalizacion(TextBox TxtRadicado, TextBox TxtCedula, TextBox TxtNombre, TextBox TxtCuenta, TextBox TxtScoring, 
                                          TextBox TxtValor_aprobado,ComboBox cmbDestino, ComboBox CmbResultado, TextBox TxtComentarios )
        {

            con.Open();
            MySqlCommand cmd = new MySqlCommand("guardar_Formalizacion", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente 
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_radicado", TxtRadicado.Text);
                cmd.Parameters.AddWithValue("@_cedula", TxtCedula.Text);
                cmd.Parameters.AddWithValue("@_nombre", TxtNombre.Text);
                cmd.Parameters.AddWithValue("@_cuenta", TxtCuenta.Text);                
                cmd.Parameters.AddWithValue("@_scoring", TxtScoring.Text);
                cmd.Parameters.AddWithValue("@_destino", TxtValor_aprobado.Text);
                cmd.Parameters.AddWithValue("@_destino", cmbDestino.Text);
                //cmd.Parameters.AddWithValue("@_pendientes", CmbResultado.Text);
                //cmd.Parameters.AddWithValue("@_pendientes", TxtComentarios.Text);
                cmd.Parameters.AddWithValue("@_nombre_funcionario", usuario.Nombre);
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Información Registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Buscar_Validacion_Desembolso(TextBox TxtRadicado, TextBox TxtCedula, TextBox TxtNombre, DateTimePicker dtpFecha_Nacimiento, TextBox TxtEdad_Cliente, TextBox TxtEstatura, 
                                                 TextBox TxtPeso, TextBox TxtCuenta, TextBox TxtScoring, TextBox TxtValor_aprobado, TextBox Txtplazo_aprobado, ComboBox cmbDestino,
                                                 TextBox TxtRauto, TextBox TxtValor_Rtq, TextBox TxtConvenio, TextBox TxtCod_oficina, TextBox TxtNom_oficina, TextBox TxtCiudad,
                                                 TextBox Txtcod_giro, TextBox Txtoficina_girar, TextBox TxtId_gestor, TextBox TxtNom_gestor, ComboBox cmbCoordinador, ComboBox cmbDactiloscopia, 
                                                 ComboBox cmbG_telefonica, ComboBox cmbcampaña, DateTimePicker dtpfecha_aprobado_vb, TextBox Txtobligacion1, TextBox TxtNom_entidad1, TextBox TxtNit1, 
                                                 TextBox TxtValor1, TextBox Txtobligacion2, TextBox TxtNom_entidad2, TextBox TxtNit2, TextBox TxtValor2, TextBox Txtobligacion3, TextBox TxtNom_entidad3,
                                                 TextBox TxtNit3, TextBox TxtValor3, TextBox Txtobligacion4, TextBox TxtNom_entidad4, TextBox TxtNit4, TextBox TxtValor4, TextBox Txtobligacion5,
                                                 TextBox TxtNom_entidad5, TextBox TxtNit5, TextBox TxtValor5, TextBox Txtobligacion6, TextBox TxtNom_entidad6, TextBox TxtNit6, TextBox TxtValor6,
                                                 TextBox Txtobligacion7, TextBox TxtNom_entidad7, TextBox TxtNit7, TextBox TxtValor7, TextBox Txtobligacion8, TextBox TxtNom_entidad8, TextBox TxtNit8,
                                                 TextBox TxtValor8, ComboBox cmbFormato_Seguros, ComboBox cmbReporte_Enfermedad, ComboBox cmbSeguros_Monto, ComboBox cmbSobrepeso, ComboBox cmbEstado_Reporte, 
                                                 TextBox TxtTotal, TextBox TxtSaldo, ComboBox cmbestado, TextBox TxtPendientes)
        {

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("buscar_validacion_desembolso", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_radicado", TxtRadicado.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {                    
                    TxtCedula.Text = registro["cedula"].ToString();
                    TxtNombre.Text = registro["nombre"].ToString();
                    dtpFecha_Nacimiento.Text = registro["Fecha_Nacimiento_Cliente"].ToString();
                    TxtEdad_Cliente.Text = registro["Edad_Cliente"].ToString();
                    TxtEstatura.Text = registro["estatura"].ToString();
                    TxtPeso.Text = registro["peso"].ToString();
                    TxtCuenta.Text = registro["cuenta"].ToString();
                    TxtScoring.Text = registro["scoring"].ToString();
                    TxtValor_aprobado.Text = registro["valor_aprobado"].ToString();
                    //TxtPlazo_solicitado.Text = registro["plazo_solicitado"].ToString();
                    Txtplazo_aprobado.Text = registro["plazo_aprobado"].ToString();
                    cmbDestino.Text = registro["destino"].ToString();
                    //cmbcambio_condiciones.Text = registro["cambio_condiciones"].ToString();
                    TxtRauto.Text = registro["r_Automatico"].ToString();
                    TxtValor_Rtq.Text = registro["valor_r_Automatico"].ToString();
                    TxtConvenio.Text = registro["convenio"].ToString();
                    TxtCod_oficina.Text = registro["codigo_oficina"].ToString();
                    TxtNom_oficina.Text = registro["sucursal"].ToString();
                    TxtCiudad.Text = registro["ciudad"].ToString();
                    Txtcod_giro.Text = registro["oficina_girar"].ToString();
                    Txtoficina_girar.Text = registro["sucursal_girar"].ToString();
                    TxtId_gestor.Text = registro["cedula_gestor"].ToString();
                    TxtNom_gestor.Text = registro["nombre_gestor"].ToString();
                    cmbCoordinador.Text = registro["nombre_coordinador"].ToString();
                    cmbDactiloscopia.Text = registro["dactiloscopia"].ToString();
                    cmbG_telefonica.Text = registro["g_telefonica"].ToString();
                    cmbcampaña.Text = registro["campaña"].ToString();
                    dtpfecha_aprobado_vb.Text = registro["fecha_aprobacion_vb"].ToString();
                    Txtobligacion1.Text = registro["numero_obligacion1"].ToString();
                    TxtNom_entidad1.Text = registro["nombre_entidad1"].ToString();
                    TxtNit1.Text = registro["nit_entidad1"].ToString();
                    TxtValor1.Text = registro["valor_cartera1"].ToString();
                    Txtobligacion2.Text = registro["numero_obligacion2"].ToString();
                    TxtNom_entidad2.Text = registro["nombre_entidad2"].ToString();
                    TxtNit2.Text = registro["nit_entidad2"].ToString();
                    TxtValor2.Text = registro["valor_cartera2"].ToString();
                    Txtobligacion3.Text = registro["numero_obligacion3"].ToString();
                    TxtNom_entidad3.Text = registro["nombre_entidad3"].ToString();
                    TxtNit3.Text = registro["nit_entidad3"].ToString();
                    TxtValor3.Text = registro["valor_cartera3"].ToString();
                    Txtobligacion4.Text = registro["numero_obligacion4"].ToString();
                    TxtNom_entidad4.Text = registro["nombre_entidad4"].ToString();
                    TxtNit4.Text = registro["nit_entidad4"].ToString();
                    TxtValor4.Text = registro["valor_cartera4"].ToString();
                    Txtobligacion5.Text = registro["numero_obligacion5"].ToString();
                    TxtNom_entidad5.Text = registro["nombre_entidad5"].ToString();
                    TxtNit5.Text = registro["nit_entidad5"].ToString();
                    TxtValor5.Text = registro["valor_cartera5"].ToString();
                    Txtobligacion6.Text = registro["numero_obligacion6"].ToString();
                    TxtNom_entidad6.Text = registro["nombre_entidad6"].ToString();
                    TxtNit6.Text = registro["nit_entidad6"].ToString();
                    TxtValor6.Text = registro["valor_cartera6"].ToString();
                    Txtobligacion7.Text = registro["numero_obligacion7"].ToString();
                    TxtNom_entidad7.Text = registro["nombre_entidad7"].ToString();
                    TxtNit7.Text = registro["nit_entidad7"].ToString();
                    TxtValor7.Text = registro["valor_cartera7"].ToString();
                    Txtobligacion8.Text = registro["numero_obligacion8"].ToString();
                    TxtNom_entidad8.Text = registro["nombre_entidad8"].ToString();
                    TxtNit8.Text = registro["nit_entidad8"].ToString();
                    TxtValor8.Text = registro["valor_cartera8"].ToString();
                    cmbFormato_Seguros.Text = registro["Formato_Seguros"].ToString();
                    cmbReporte_Enfermedad.Text = registro["Enfermedad"].ToString();
                    cmbSeguros_Monto.Text = registro["Reporte_Monto"].ToString();
                    cmbSobrepeso.Text = registro["Reporte_Sobrepeso"].ToString();
                    cmbEstado_Reporte.Text = registro["Preformalizacion_Seguros"].ToString();
                    TxtTotal.Text = registro["total_cpk"].ToString();
                    TxtSaldo.Text = registro["saldo_cliente"].ToString();
                    cmbestado.Text = registro["estado"].ToString();
                    TxtPendientes.Text = registro["pendientes"].ToString();
                    con.Close();
                }
                else
                {
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        public void Busqueda_VoBo(TextBox TxtRadicado, TextBox TxtCedula, TextBox TxtNombre,TextBox TxtScoring, TextBox TxtConvenio, ComboBox cmbDestino, TextBox TxtValor_aprobado,
                                  TextBox Txtplazo_aprobado, DateTimePicker dtpFecha_Cierre_Etapa, TextBox TxtNom_entidad1, TextBox TxtNom_entidad2, TextBox TxtNom_entidad3, TextBox TxtNom_entidad4,
                                  TextBox TxtNom_entidad5, TextBox TxtNom_entidad6, TextBox TxtNom_entidad7, TextBox TxtNom_entidad8)
        {           

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("busqueda_vobo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", TxtRadicado.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {                   
                    TxtCedula.Text = registro["Cedula_Cliente"].ToString();
                    TxtNombre.Text = registro["Nombre_Cliente"].ToString();                   
                    TxtScoring.Text = registro["Scoring"].ToString();
                    TxtConvenio.Text = registro["Codigo_Convenio"].ToString();
                    cmbDestino.Text = registro["Destino"].ToString();                    
                    TxtValor_aprobado.Text = registro["Monto_Aprobado"].ToString();
                    Txtplazo_aprobado.Text = registro["Plazo_Aprobado"].ToString();
                    dtpFecha_Cierre_Etapa.Text = registro["Fecha_Cierre_Etapa"].ToString();
                    TxtNom_entidad1.Text = registro["cartera1"].ToString();
                    TxtNom_entidad2.Text = registro["cartera2"].ToString();
                    TxtNom_entidad3.Text = registro["cartera3"].ToString();
                    TxtNom_entidad4.Text = registro["cartera4"].ToString();
                    TxtNom_entidad5.Text = registro["cartera5"].ToString();
                    TxtNom_entidad6.Text = registro["cartera6"].ToString();
                    TxtNom_entidad7.Text = registro["cartera7"].ToString();
                    TxtNom_entidad8.Text = registro["cartera8"].ToString();                    
                    con.Close();
                    TxtCedula.Focus();
                }
                else
                {                   
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Busqueda_Colp(TextBox TxtRadicado, TextBox TxtCedula, TextBox TxtNombre, TextBox TxtScoring,
                                  ComboBox cmbDestino, TextBox TxtValor_aprobado, TextBox Txtplazo_aprobado)
        {

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("busqueda_colpensiones", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", TxtRadicado.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    TxtCedula.Text = registro["Cedula"].ToString();
                    TxtNombre.Text = registro["Nombre_Cliente"].ToString();
                    TxtScoring.Text = registro["Scoring"].ToString();                    
                    cmbDestino.Text = registro["Destino"].ToString();
                    TxtValor_aprobado.Text = registro["Monto_Aprobado"].ToString();
                    Txtplazo_aprobado.Text = registro["Plazo_Aprobado"].ToString();
                    con.Close();
                }
                else
                {
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Actualizar_Contraseña(TextBox Txtusuario, TextBox Txtcontraseña)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("actualizar_contraseña", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Identificacion", Txtusuario.Text);
                cmd.Parameters.AddWithValue("@_Contraseña", Txtcontraseña.Text);
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Información Almacenada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void Buscar_formalizacion(TextBox TxtRadicado, TextBox TxtCedula, TextBox TxtNombre, TextBox TxtEstatura, TextBox TxtPeso, TextBox TxtCuenta, TextBox TxtScoring, TextBox TxtValor_aprobado,
           TextBox Txtplazo_aprobado, ComboBox cmbDestino, TextBox TxtRauto, TextBox TxtValor_Rtq, TextBox TxtConvenio, TextBox TxtCod_oficina, TextBox TxtNom_oficina, TextBox TxtId_gestor, TextBox TxtNom_gestor,
           TextBox Txtobligacion1, TextBox TxtNom_entidad1, TextBox TxtNit1, TextBox TxtValor1, TextBox Txtobligacion2, TextBox TxtNom_entidad2, TextBox TxtNit2, TextBox TxtValor2,
           TextBox Txtobligacion3, TextBox TxtNom_entidad3, TextBox TxtNit3, TextBox TxtValor3, TextBox Txtobligacion4, TextBox TxtNom_entidad4, TextBox TxtNit4, TextBox TxtValor4,
           TextBox Txtobligacion5, TextBox TxtNom_entidad5, TextBox TxtNit5, TextBox TxtValor5, TextBox Txtobligacion6, TextBox TxtNom_entidad6, TextBox TxtNit6, TextBox TxtValor6,
           TextBox Txtobligacion7, TextBox TxtNom_entidad7, TextBox TxtNit7, TextBox TxtValor7,TextBox Txtobligacion8, TextBox TxtNom_entidad8, TextBox TxtNit8, TextBox TxtValor8, TextBox TxtTotal, TextBox TxtSaldo_cliente)
        {

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("buscar_formalizacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_radicado", TxtRadicado.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    TxtCedula.Text = registro["cedula"].ToString();
                    TxtNombre.Text = registro["nombre"].ToString();
                    TxtEstatura.Text = registro["estatura"].ToString();
                    TxtPeso.Text = registro["peso"].ToString();
                    TxtCuenta.Text = registro["cuenta"].ToString();
                    TxtScoring.Text = registro["scoring"].ToString();
                    TxtValor_aprobado.Text = registro["valor_aprobado"].ToString();                    
                    Txtplazo_aprobado.Text = registro["plazo_aprobado"].ToString();
                    cmbDestino.Text = registro["destino"].ToString();                    
                    TxtRauto.Text = registro["r_Automatico"].ToString();
                    TxtValor_Rtq.Text = registro["valor_r_Automatico"].ToString();
                    TxtConvenio.Text = registro["convenio"].ToString();
                    TxtCod_oficina.Text = registro["codigo_oficina"].ToString();
                    TxtNom_oficina.Text = registro["sucursal"].ToString();                    
                    TxtId_gestor.Text = registro["cedula_gestor"].ToString();
                    TxtNom_gestor.Text = registro["nombre_gestor"].ToString();              
                    Txtobligacion1.Text = registro["numero_obligacion1"].ToString();
                    TxtNom_entidad1.Text = registro["nombre_entidad1"].ToString();
                    TxtNit1.Text = registro["nit_entidad1"].ToString();
                    TxtValor1.Text = registro["valor_cartera1"].ToString();
                    Txtobligacion2.Text = registro["numero_obligacion2"].ToString();
                    TxtNom_entidad2.Text = registro["nombre_entidad2"].ToString();
                    TxtNit2.Text = registro["nit_entidad2"].ToString();
                    TxtValor2.Text = registro["valor_cartera2"].ToString();
                    Txtobligacion3.Text = registro["numero_obligacion3"].ToString();
                    TxtNom_entidad3.Text = registro["nombre_entidad3"].ToString();
                    TxtNit3.Text = registro["nit_entidad3"].ToString();
                    TxtValor3.Text = registro["valor_cartera3"].ToString();
                    Txtobligacion4.Text = registro["numero_obligacion4"].ToString();
                    TxtNom_entidad4.Text = registro["nombre_entidad4"].ToString();
                    TxtNit4.Text = registro["nit_entidad4"].ToString();
                    TxtValor4.Text = registro["valor_cartera4"].ToString();
                    Txtobligacion5.Text = registro["numero_obligacion5"].ToString();
                    TxtNom_entidad5.Text = registro["nombre_entidad5"].ToString();
                    TxtNit5.Text = registro["nit_entidad5"].ToString();
                    TxtValor5.Text = registro["valor_cartera5"].ToString();
                    Txtobligacion6.Text = registro["numero_obligacion6"].ToString();
                    TxtNom_entidad6.Text = registro["nombre_entidad6"].ToString();
                    TxtNit6.Text = registro["nit_entidad6"].ToString();
                    TxtValor6.Text = registro["valor_cartera6"].ToString();
                    Txtobligacion7.Text = registro["numero_obligacion7"].ToString();
                    TxtNom_entidad7.Text = registro["nombre_entidad7"].ToString();
                    TxtNit7.Text = registro["nit_entidad7"].ToString();
                    TxtValor7.Text = registro["valor_cartera7"].ToString();
                    Txtobligacion8.Text = registro["numero_obligacion8"].ToString();
                    TxtNom_entidad8.Text = registro["nombre_entidad8"].ToString();
                    TxtNit8.Text = registro["nit_entidad8"].ToString();
                    TxtValor8.Text = registro["valor_cartera8"].ToString();
                    TxtTotal.Text = registro["total_cpk"].ToString();
                    TxtSaldo_cliente.Text = registro["saldo_cliente"].ToString();
                    con.Close();
                }
                else
                {
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Pendientes_Desembolso(DataGridView dgvDatos)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("pendientes_desembolso", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvDatos.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Ver_Asignacion_Desembolso_Funcionario(DataGridView dgvAsignacion, DateTimePicker dtpfecha_asignacion,ComboBox cmbestado_asignacion)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("asignacion_desembolso_funcionarios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_cmbestado_asignacion", cmbestado_asignacion.Text);
                cmd.Parameters.AddWithValue("@_dtpfecha_asignacion", dtpfecha_asignacion.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvAsignacion.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Ver_Asignacion_Desembolso_xFuncionario(DataGridView dgvTotal_Asignacion)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("asignacion_desembolso_xfuncionario", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@_nombre_funcionario", usuario.Nombre);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvTotal_Asignacion.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void Asignar_Desembolso(TextBox TxtRadicado,ComboBox CmbFuncionario_Desembolso, Label lblfecha, Label lblHora)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("asignar_desembolso", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_radicado", TxtRadicado.Text);
                cmd.Parameters.AddWithValue("@_nombre_funcionario", CmbFuncionario_Desembolso.Text);
                cmd.Parameters.AddWithValue("@_Estado", "En gestion");
                cmd.Parameters.AddWithValue("@_fecha_asignacion", lblfecha.Text);
                cmd.Parameters.AddWithValue("@_hora_asignacion", lblHora.Text);
                cmd.ExecuteNonQuery();
                myTrans.Commit();                             
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public void Actualiza_Desembolso(TextBox TxtRadicado, ComboBox CmbResultado, TextBox TxtComentarios)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("actualizarbd_formalizados", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_radicado", TxtRadicado.Text);
                cmd.Parameters.AddWithValue("@_estado", CmbResultado.Text);
                cmd.Parameters.AddWithValue("@_Observaciones", TxtComentarios.Text);
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Información Almacenada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public void Asignar_Actualizar_Base(TextBox TxtRadicado)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("asignar_actualizar_base", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_radicado", TxtRadicado.Text);                
                cmd.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}
