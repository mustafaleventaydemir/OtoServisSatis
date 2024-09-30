using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{
    public class Servis : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Servise Geliş Tarihi")]
        public DateTime ServiseGelisTarihi { get; set; }
        [StringLength(500), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        [Display(Name = "Araç Sorunu")]
        public string AracSorunu { get; set; }
        [Display(Name = "Servis Ücreti")]
        public decimal ServisUcreti { get; set; }
        [Display(Name = "Servisten Çıkış Tarihi")]
        public DateTime ServistenCikisTarihi { get; set; }
        [StringLength(500)]
        [Display(Name = "Yapılan İşlemler")]
        public string? YapilanIslemler { get; set; }
        [Display(Name = "Garanti Kapsamında mı?")]
        public bool GarantiKapsamindaMi { get; set; }
        [StringLength(15), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        [Display(Name = "Araç Plakası")]
        public string AracPlaka { get; set; }
        [StringLength(30), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Marka { get; set; }
        [StringLength(30)]
        public string? Model { get; set; }
        [StringLength(30)]
        [Display(Name = "Kasa Tipi")]
        public string? KasaTipi { get; set; }
        [StringLength(50)]
        [Display(Name = "Şase No"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string SaseNo { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Notlar { get; set; }
    }
}
