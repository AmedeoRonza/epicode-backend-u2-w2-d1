using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InsertCliente() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertCliente(Cliente Model) 
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GestionaleSpedizioni"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try
            {

                string query = "INSERT INTO Spedizioni (idCliente, Nominativo, IsAzienda, codiceFiscale, partitaIva) VALUES ( @idCliente, @Nominativo, @IsAzienda, @codiceFiscale, @partitaIva )";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idCliente", Model.idCliente);
                cmd.Parameters.AddWithValue("@Nominativo", Model.Nominativo);
                cmd.Parameters.AddWithValue("@IsAzienda", Model.IsAzienda);
                cmd.Parameters.AddWithValue("@codiceFiscale", Model.codiceFiscale);
                cmd.Parameters.AddWithValue("@partitaIva", Model.partitaIva);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Errore nella richiesta SQL");
                return View(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return View();
        }
    }
}