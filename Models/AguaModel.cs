using System;
using System.ComponentModel.DataAnnotations;
namespace AguaTrack.Models
{
    public class AguaModel
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "El valor para {0} debe ser POSITIVO.")]
        public int Cantidad { get; set; }

    }
}
