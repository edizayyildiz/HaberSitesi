using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.Model
{
    public class Post : BaseEntity
    {
        [Display(Name = "Haber Başlığı")]
        public string Title { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Haber İçeriği")]
        public string Body { get; set; }

        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
