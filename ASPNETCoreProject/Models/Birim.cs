using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreProject.Models
{
    public class Birim
    {
        [Key]
        public int BirimID { get; set; }
        public string BirimAd { get; set; }
        public IList<Personel> Personels { get; set; }
    }
}
