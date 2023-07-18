using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreProject.Models
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sehir { get; set; }
        public string GorselYol { get; set; }
        [NotMapped]
        public IFormFile Gorsel { get; set; }
        public int BirimID { get; set; }
        public Birim Birim { get; set; }
    }
}
