using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using WebDashboard;

namespace WebDashboard
{
    class SourcingResult
    {
        public string Product { get; set; }

        public int Quanity { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }
    }
    interface IRepository
    {
        IEnumerable<SourcingResult> GetSourcingResults();
    }
    class SqlDBconnection
    {
        private static SqlConnection Conn;
        internal static SqlConnection Connection
        {
            get
            {
                return SqlDBconnection.Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ReeseDB"].ConnectionString);
            }
        }
    }

    class SQLRepository : IRepository
    {
        public IEnumerable<SourcingResult> GetSourcingResults()
        {
            DataTable dtData = new DataTable();
            SqlConnection sqlCon = SqlDBconnection.Connection;
            SqlDataAdapter sqlCmd = new SqlDataAdapter(
                "Select [product_name] as Product" +
                ", [quanity] as Quanity" +
                ", [amount] as Price" +
                ", [total] as Total " +
                " FROM [dbo].[product_trans]", sqlCon);

            sqlCon.Open();

            sqlCmd.Fill(dtData);

            sqlCon.Close();

            foreach(DataRow row in dtData.Rows )
            {
                yield return new SourcingResult
                {
                    Product = row["Product"].ToString(),
                    Quanity = Convert.ToInt32(row["Quanity"]),
                    Price = Convert.ToDecimal(row["Price"]),
                    Total = Convert.ToDecimal(row["Total"])
                };
            }
        }
    }

    class WebServiceRepository : IRepository
    {
        public IEnumerable<SourcingResult> GetSourcingResults()
        {
            // TODO: call a web service, get the data, and transform to SourcingResult objects
            throw new NotImplementedException();
        }
    }
    public class DBdata : Page
    {
        [WebMethod]
        [ScriptMethod( UseHttpGet = true, ResponseFormat = ResponseFormat.Json )]
        public static string GetData()
        {
            IRepository repository = new SQLRepository();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(repository.GetSourcingResults());
        }
    }
}
