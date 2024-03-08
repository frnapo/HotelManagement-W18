using System.ComponentModel.DataAnnotations;

namespace HOTELNAPOLI.Models
{
    public enum DescrizioneServizi
    {
        [Display(Name = "Colazione in camera")]
        ColazioneInCamera,
        [Display(Name = "Bevande e cibo")]
        BevandeECibo,
        [Display(Name = "Internet")]
        Internet,
        [Display(Name = "Letto aggiuntivo")]
        LettoAggiuntivo,
        [Display(Name = "Culla")]
        Culla,
    }
}
