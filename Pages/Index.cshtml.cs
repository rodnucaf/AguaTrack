using AguaTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using System.Data.SqlTypes;
using System.Globalization;

namespace AguaTrack.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public List<AguaModel> Registro { get; set; }

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            Registro = GetAllRegistros();
        }

        private List<AguaModel> GetAllRegistros()
        {
            using (var connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"Select * FROM drinking_water";

                var tableData = new List<AguaModel>();
                SqliteDataReader reader = tableCmd.ExecuteReader();

                while (reader.Read())
                {
                    tableData.Add
                    (
                        new AguaModel
                        {
                            Id = reader.GetInt32(0),
                            Fecha = DateTime.Parse(reader.GetString(1), CultureInfo.CurrentCulture.DateTimeFormat),
                            Cantidad = reader.GetInt32(2)
                        }
                    );
                }
                return tableData;
            }

        }
    }
}
