using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOTELNAPOLI.Models
{
    public class Servizi
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Display(Name = "Descrizione")]
        public string Descrizione { get; set; }
        [Display(Name = "Prezzo")]
        public double? Prezzo { get; set; }

        [Display(Name = "Data Richiesta Servizio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataRichiestaServizio { get; set; }

        [Display(Name = "Prenotazione")]
        [ForeignKey("Prenotazione")]
        public int IDPrenotazione { get; set; }
        public Prenotazioni? Prenotazione { get; set; }

    }
}
