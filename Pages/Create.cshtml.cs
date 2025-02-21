using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguaTrack.Models;
using Microsoft.Data.Sqlite;

namespace AguaTrack.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public CreateModel(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public IActionResult OnGet()
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }

            using (var connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"INSERT INTO drinking_water(date, quantity) VALUES ('{Agua.Fecha}', {Agua.Cantidad})  ";

                tableCmd.ExecuteNonQuery();
                connection.Close();
            }
            return RedirectToPage("./Index");
        }

        [BindProperty]
        public AguaModel Agua { get; set; }


    }
}
