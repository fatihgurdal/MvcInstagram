using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInstagramFatih.Entity
{
    public class PostHashtag
    {
        [Key]
        public int PostHastagId { get; set; }
        public int PhotoPostId { get; set; }
        [DisplayName("Hastag Adı"),Required,MaxLength(50)]
        public string HastagName { get; set; }

        [ForeignKey("PhotoPostId")]
        public PhotoPost photopost { get; set; }
    }
}
