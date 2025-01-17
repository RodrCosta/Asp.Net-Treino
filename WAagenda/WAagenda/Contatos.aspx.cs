﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WAagenda
{
    public partial class Contatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text != "" && txtNome.Text != "" && txtTelefone.Text != "")
                {
                    //capturar a string de conexão
                    System.Configuration.Configuration RootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
                    System.Configuration.ConnectionStringSettings ConnString;
                    ConnString = RootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];

                    //cria um objeto de conexão
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConnString.ToString();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into contato (nome,email,telefone) values (@nome,@email,@telefone)";
                    cmd.Parameters.AddWithValue("nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("telefone", txtTelefone.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                }
                else
                {
                    throw new Exception("Campos em branco");
                }
                
            }
            catch (Exception erro)
            {

                Response.Write("<script>mensagem de erro: alert(" + erro.Message+");<script>");

            }
          
        }
    }
}