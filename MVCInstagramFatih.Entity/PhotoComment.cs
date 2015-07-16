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
    public class PhotoComment
    {
        [Key]
        public int PhotoCommentId { get; set; }
        public int UserId { get; set; }
        public int PhotoPostId { get; set; }
        [DisplayName("Yorum"),MaxLength(200),Required]
        public string CommentStr { get; set; }
        [DisplayName("Eklenme Tarihi"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime InsertDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User user { get; set; }
        [ForeignKey("PhotoPostId")]
        public virtual PhotoPost photopost { get; set; }
    }
}
