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
    public partial class Agregar : Form
    {
        private String stringConnection;
        public Agregar()
        {
            stringConnection = ConfigurationManager
                          .ConnectionStrings["camionesString"]
                          .ConnectionString;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregaCamion();
        }

        private void agregaCamion() {

            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                conn.Open();
                try
                {
                    SqlCommand cmd;

                    if (btnAgregar.Text == "Guardar")
                    {
                        cmd = new SqlCommand("insert into TB_EQUIPOS(EquiPatente,EquiMarca,EquiModelo,EquiAño,EquiKilometraje,NumEquipo,EquiFlota)Values(@patente,@marca,@modelo,@año,@kilom,@num,@flota)", conn);

                    }
                    else
                    {
                        cmd = new SqlCommand("update TB_EQUIPOS set EquiPatente = @patente,EquiMarca= @marca,EquiModelo= @modelo,EquiAño = @año ,EquiKilometraje = @kilom,NumEquipo =@num where EquiPatente = @patente and NumEquipo = '" + cbxnum.SelectedValue + "'", conn);

                    }
                    cmd.Parameters.AddWithValue("@patente", txtpatente.Text);
                    cmd.Parameters.AddWithValue("@marca", txtmarca.Text);
                    cmd.Parameters.AddWithValue("@modelo", txtmodelo.Text);
                    cmd.Parameters.AddWithValue("@año", txtaño.Text);
                    cmd.Parameters.AddWithValue("@kilom", txtkilo.Text);
                    cmd.Parameters.AddWithValue("@num", cbxnum.SelectedValue);
                    cmd.Parameters.AddWithValue("@flota", cbxflota.SelectedValue.ToString());

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
                    
                }
            }

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

        private void CargaTodo(object sender, EventArgs e)
        {
            cargaFlota();
            cargaNumeroEquipo();
        }
    }
    }

