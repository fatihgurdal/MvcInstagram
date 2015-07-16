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
    public class PhotoPost
    {
        public PhotoPost()
        {
            this.photocomments = new HashSet<PhotoComment>();
            this.photolikes = new HashSet<PhotoLike>();
            this.posthashtag = new HashSet<PostHashtag>();
        }
        [Key]
        public int PhotoPostId { get; set; }
        [DisplayName("Fotoğraf Yolu"),Required,MaxLength(200),DataType(DataType.Upload)]
        public string PhotoPath { get; set; }
        [DisplayName("Fotoğraf Açıklaması"),MaxLength(200)]
        public string PhotoDescription { get; set; }
        [DisplayName("Fotoğraf Aktif Mi?")]
        public bool AktifMi { get; set; }
        public bool IsPhoto { get; set; }
        [DisplayName("Eklenme Tarihi"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime InsertDate { get; set; }
        [NotMapped]
        public int UserId { 
            get {
                return this.user.UserId;
            }
        }
        
        public virtual User user { get; set; }
        public virtual ICollection<PhotoComment> photocomments { get; set; }
        public virtual ICollection<PhotoLike> photolikes { get; set; }
        public virtual ICollection<PostHashtag> posthashtag { get; set; }
    }
}
