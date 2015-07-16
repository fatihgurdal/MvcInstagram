using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInstagramFatih.Entity
{
    public class PhotoLike
    {
        [Key]
        public int PhotoLikeId { get; set; }
        public int UserId { get; set; }
        public int PhotoPostId { get; set; }

        [ForeignKey("UserId")]
        public virtual User user { get; set; }
        [ForeignKey("PhotoPostId")]
        public virtual PhotoPost photopost { get; set; }

    }
}
