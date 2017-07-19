using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroCamiones
{
    public partial class frmOrden : Form
    {
        private String stringConnection;
        public frmOrden()
        {
            stringConnection = ConfigurationManager
                             .ConnectionStrings["camionesString"]
                             .ConnectionString;
            InitializeComponent();
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            guardarOrden();
            
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {

        }

        private void cargarTodo(object sender, EventArgs e)
        {
            cargaNumeroEquipo();
            cargaFlota();
            cargarTablaCamion();
            
          
        }

        private void cargaNumeroEquipo()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {


                try
                {
                    con.Open();
                    string query = "select * from TB_NumEquipos";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Equipos");

                    cbxnum.DisplayMember = "NumEquipo";
                    cbxnum.ValueMember = "NumEquipo";

                    cbxnum.DataSource = dataSet.Tables["Equipos"];
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                                            "Error al conectarse a la base de Datos : Al cargar Equipos" + ex,
                                            ".: Sistema Camiones :.",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error
                                            );
                }
                finally
                {
                    con.Close();
                }


            }

        }

        private void cargaFlota()
        {


            {
                using (SqlConnection con = new SqlConnection(stringConnection))
                {


                    try
                    {
                        con.Open();
                        string query = "select TB_FLOTA.FLoNombreFlota from TB_FLOTA";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "flota");

                        cbxflota.DisplayMember = "FloNombreFlota";
                        cbxflota.ValueMember = "FloNombreFlota";

                        cbxflota.DataSource = dataSet.Tables["flota"];
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(
                                                "Error al conectarse a la base de Datos : Al cargar Flota" + ex,
                                                ".: Sistema Camiones :.",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error
                                                );
                    }
                    finally
                    {
                        con.Close();
                    }


                }

            }
        }

        private void cargarTablaOrden()
        {

            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                try
                {
                    string query = "select TB_ORDEN_DE_TRABAJO.OrdDescripcion,TB_ORDEN_DE_TRABAJO.OrdPersonaResp,TB_ORDEN_DE_TRABAJO.PerCargo,TB_ORDEN_DE_TRABAJO.PerObs from TB_ORDEN_DE_TRABAJO";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Orden");
                    
                    dgvOrden.Rows.Clear();
                    foreach (DataRow row in ds.Tables["Orden"].Rows)
                    {

                        dgvOrden.Rows.Add(
                                row[0],
                                row[1],
                                row[2],
                                row[3],
                                new DataGridViewButtonColumn(),
                                new DataGridViewButtonColumn()
                                );

                    }
                }
                catch (SqlException es)
                {
                    MessageBox.Show(
          "Error al conectarse a la base de Datos : Al listar Trabajo en Grilla" + es,
          ".: Sistema Camiones :.",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
          );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                           "Error al conectarse a la base de Datos : Al listar Trabajo en Grilla" + ex,
                           ".: Sistema Camiones :.",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                           );
                }
            }

        }
        private void agregarCamion()
        {
            if (txtmarca.Equals("") || txtmodelo.Equals("") || txtmarca.Equals("") || txtaño.Equals("") || txtpatente.Equals("") || txtkilo.Equals(""))
            {
                MessageBox.Show(
                                "Faltan registros por ingresar en su formulario",
                                ".: Sistema Anotaciones :.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                                );
            }
            else
            {

                using (SqlConnection conn = new SqlConnection(stringConnection))
                {
                    conn.Open();
                    try
                    {
                        SqlCommand cmd;

                        if (btnGuardarCamion.Text == "Guardar")
                        {
                            cmd = new SqlCommand("insert into TB_EQUIPOS(EquiPatente,EquiMarca,EquiModelo,EquiAño,EquiKilometraje,NumEquipo,EquiFlota)Values(@patente,@marca,@modelo,@año,@kilom,@num,@flota)", conn);

                        }
                        else
                        {
                            cmd = new SqlCommand("update TB_EQUIPOS set EquiPatente = @patente,EquiMarca= @marca,EquiModelo= @modelo,EquiAño = @año ,EquiKilometraje = @kilom,NumEquipo =@num where EquiPatente = @patente and NumEquipo = '"+ cbxnum.SelectedValue +"'", conn);

                        }
                        cmd.Parameters.AddWithValue("@patente", txtpatente.Text);
                        cmd.Parameters.AddWithValue("@marca", txtmarca.Text);
                        cmd.Parameters.AddWithValue("@modelo", txtmodelo.Text);
                        cmd.Parameters.AddWithValue("@año", txtaño.Text);
                        cmd.Parameters.AddWithValue("@kilom", txtkilo.Text);
                        cmd.Parameters.AddWithValue("@num" ,cbxnum.SelectedValue);
                        cmd.Parameters.AddWithValue("@flota",cbxflota.SelectedValue);

                        cmd.ExecuteNonQuery();


                    }
                    catch (SqlException eSql)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Camion " + eSql,
                         ".: Sistema Camiones :.",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                         );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Camion " + ex,
                         ".: Sistema Camiones :.",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                         );
                    }
                    finally
                    {
                        conn.Close();
                        cargarTablaCamion();
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agregarCamion();
            cargarTablaCamion();
           
        }

        private void cargarTablaCamion()
        {

            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                try
                {
                    string query = "select TB_EQUIPOS.EquiPatente as Patente,TB_EQUIPOS.EquiMarca as Marca,TB_EQUIPOS.EquiModelo as Modelo,TB_EQUIPOS.EquiAño as Año,TB_EQUIPOS.EquiKilometraje as Kilometraje,TB_EQUIPOS.NumEquipo as Numero from TB_EQUIPOS where TB_EQUIPOS.EquiPatente = '"+ txtpatente.Text +" '";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Equipos");
                    
                    dgvCamion.Rows.Clear();
                    foreach (DataRow row in ds.Tables["Equipos"].Rows)
                    {

                        dgvCamion.Rows.Add(
                                row[0],
                                row[1],
                                row[2],
                                row[3],
                                row[4],
                                row[5],
                                
                                

                                new DataGridViewButtonColumn(),
                                new DataGridViewButtonColumn()
                                );

                    }
                }
                catch (SqlException es)
                {
                    MessageBox.Show(
          "Error al conectarse a la base de Datos : Al listar Trabajo en Grilla" + es,
          ".: Sistema Camiones :.",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
          );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                           "Error al conectarse a la base de Datos : Al listar Trabajo en Grilla" + ex,
                           ".: Sistema Camiones :.",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                           );
                }
            }

        }

        private void guardarOrden()
        {

            {
                if (txtmarca.Equals("") || txtmodelo.Equals("") || txtmarca.Equals("") || txtaño.Equals("") || txtpatente.Equals("") || txtkilo.Equals(""))
                {
                    MessageBox.Show(
                                    "Faltan registros por ingresar en su formulario",
                                    ".: Sistema Anotaciones :.",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                    );
                }
                else
                {

                    using (SqlConnection conn = new SqlConnection(stringConnection))
                    {
                        conn.Open();
                        try
                        {
                            SqlCommand cmd;

                            if (btngenerar.Text == "Guardar")
                            {
                                cmd = new SqlCommand("insert into TB_ORDEN_DE_TRABAJO(OrdDescripcion,OrdPersonaResp,PerCargo,PerObs)VALUES(@desc,@pers,@cargo,@obs)", conn);

                            }
                            else
                            {
                                cmd = new SqlCommand("UPDATE TB_ORDEN_DE_TRABAJO SET OrdDescripcion=@desc, OrdPersonaResp=@pers, PerCargo=@cargo, PerObs=@obs WHERE  OrdPersonaResp=@pers", conn);

                            }
                            cmd.Parameters.AddWithValue("@desc", txtTrabajo.Text);
                            cmd.Parameters.AddWithValue("@pers", txtPersona.Text);
                            cmd.Parameters.AddWithValue("@cargo", txtCargo.Text);
                            cmd.Parameters.AddWithValue("@obs", txtObservaciones.Text);
                            cmd.ExecuteNonQuery();


                        }
                        catch (SqlException eSql)
                        {
                            MessageBox.Show(
                             "Error al conectarse a la base de Datos : Al guardar Orden " + eSql,
                             ".: Sistema Camiones :.",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                             );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                             "Error al conectarse a la base de Datos : Al guardar Orden " + ex,
                             ".: Sistema Camiones :.",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                             );
                        }
                        finally
                        {
                            conn.Close();
                            cargarTablaOrden();
                        }
                    }

                }
            }


        }

        private void buscarCamion()
        {

            //update TB_EQUIPOS set EquiPatente = @patente, EquiMarca = @marca, EquiModelo = @modelo, EquiAño = @año, EquiKilometraje = @kilom, NumEquipo = @num where EquiPatente = @patente and NumEquipo = @num"
            {
                using (SqlConnection conn = new SqlConnection(stringConnection))
                {
                    try
                    {
                        string query = "select * FROM TB_EQUIPOS WHERE NumEquipo ='" + cbxnum.SelectedValue + "'";
                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        conn.Open();
                        DataSet ds = new DataSet();
                        da.Fill(ds, "Camion");
                        foreach (DataRow fila in ds.Tables["Camion"].Rows)
                        {
                            txtmarca.Text = fila[0].ToString();
                            txtmodelo.Text = fila[1].ToString();
                            txtaño.Text = fila[2].ToString();
                            txtpatente.Text = fila[3].ToString();
                            txtkilo.Text = fila[4].ToString();
                            cbxnum.SelectedValue = fila[5].ToString();
                            cbxflota.SelectedValue = fila[6].ToString();

                            btnGuardarCamion.Text = "Guardar Cambios";
                            cbxnum.Enabled = false;
                        }

                    }
                    catch (SqlException x)
                    {
                        MessageBox.Show(
                                       "Error al conectarse a la base de Datos : Al listar datos de Camion" + x.Message,
                                       ".: Sistema Camiones :.",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error
                                       );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                                       "Error al conectarse a la base de Datos : Al listar datos de Camiones" + ex.Message,
                                       ".: Sistema Camiones :.",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error
                                       );
                    }
                }
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            buscarCamion();
        }
    }
}




    

