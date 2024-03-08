using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOTELNAPOLI.Models
{
    public class Prenotazioni
    {
        [Display(Name = "N° Prenotazione")]
        public int ID { get; set; }
        [Display(Name = "Data Prenotazione")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPrenotazione { get; set; }
        [Display(Name = "Data Inizio Soggiorno")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataInizioSoggiorno { get; set; }
        [Display(Name = "Data Fine Soggiorno")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataFineSoggiorno { get; set; }
        [Display(Name = "Anno")]
        public string Anno { get; set; }
        [Display(Name = "Acconto")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public double Acconto { get; set; }
        [Display(Name = "Prezzo")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public double Prezzo { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [ForeignKey("Cliente")]
        public int IDCliente { get; set; }
        public Clienti? Cliente { get; set; }

        [Display(Name = "Camera")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [ForeignKey("Camera")]
        public int IDCamera { get; set; }
        public Camere? Camera { get; set; }

        [Display(Name = "Pensione")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [ForeignKey("Pensione")]
        public int IDPensione { get; set; }
        public Pensioni? Pensione { get; set; }
    }
}
