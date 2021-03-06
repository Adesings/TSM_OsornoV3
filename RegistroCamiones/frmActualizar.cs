﻿using System;
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
    public partial class frmActualizar : Form
    {
        private String stringConnection;
        public frmActualizar()
        {
            stringConnection = ConfigurationManager
                             .ConnectionStrings["camionesString"]
                             .ConnectionString;
            InitializeComponent();
        }

        private void frmActualizar_Load(object sender, EventArgs e)
        {
            cargaNumeroEquipo();
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

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            agregarCamion();

          
            
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

                            btnBuscar.Text = "Guardar Cambios";
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

        private void actualizarCamion() {

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
                        da.Fill(ds, "AlumnoDatos");
                        foreach (DataRow fila in ds.Tables["AlumnoDatos"].Rows)
                        {
                            txtmarca.Text = fila[0].ToString();
                            txtmodelo.Text = fila[1].ToString();
                            txtaño.Text = fila[2].ToString();
                            txtpatente.Text = fila[3].ToString();
                            txtkilo.Text = fila[4].ToString();
                            cbxnum.SelectedValue = fila[5].ToString();
                            cbxflota.SelectedValue = fila[6].ToString();

                            btnGuardar.Text = "Guardar Cambios";
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

        private void agregarCamion()
        {
        

                using (SqlConnection conn = new SqlConnection(stringConnection))
                {
                    conn.Open();
                    try
                    {
                        SqlCommand cmd;

                        if (btnGuardar.Text == "Guardar")
                        {
                            cmd = new SqlCommand("insert into TB_EQUIPOS(EquiPatente,EquiMarca,EquiModelo,EquiAño,EquiKilometraje,NumEquipo,EquiFlota)Values(@patente,@marca,@modelo,@año,@kilom,@num,@flota)", conn);
                        MessageBox.Show("Camion Guardado Exitomente");
                        }
                        else
                        {
                            cmd = new SqlCommand("update TB_EQUIPOS set EquiPatente = @patente,EquiMarca= @marca,EquiModelo= @modelo,EquiAño = @año ,EquiKilometraje = @kilom,NumEquipo =@num,EquiFlota =@flota where EquiPatente = @patente and NumEquipo = '" + cbxnum.SelectedValue + "'", conn);

                        }
                        cmd.Parameters.AddWithValue("@patente", txtpatente.Text);
                        cmd.Parameters.AddWithValue("@marca", txtmarca.Text);
                        cmd.Parameters.AddWithValue("@modelo", txtmodelo.Text);
                        cmd.Parameters.AddWithValue("@año", txtaño.Text);
                        cmd.Parameters.AddWithValue("@kilom", txtkilo.Text);
                        cmd.Parameters.AddWithValue("@num", cbxnum.SelectedValue);
                        cmd.Parameters.AddWithValue("@flota", cbxflota.SelectedValue);

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarCamion();
        }
    }

        
     
    }
