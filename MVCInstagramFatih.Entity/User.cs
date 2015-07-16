using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInstagramFatih.Entity
{
    public class User
    {
        public User()
        {
           // this.likes = new HashSet<PhotoLike>();
            this.photoposts = new HashSet<PhotoPost>();
           // this.photocomments = new HashSet<PhotoComment>();
        }
        [Key]
        public int UserId { get; set; }
        [DisplayName("Kullanici Adi"),MaxLength(30),Required]
        public string UserName { get; set; }
        [DisplayName("Kullanici Şifresi"), MaxLength(30),Required,DataType(DataType.Password)]
        public string UserPass { get; set; }
        [DisplayName("Adı ve Soyadi"), MaxLength(50),Required]
        public string FirstName { get; set; }
        [DisplayName("Açıklama"), MaxLength(2000)]
        public string Description { get; set; }
        [DisplayName("Aktif Kullanici Mi?")]
        public bool AktifMi { get; set; }
        [DisplayName("Profil Resmi"),MaxLength(100),DataType(DataType.Upload)]
        public string ProfilImagePath { get; set; }

       
        //[DisplayName("Beğendikleri")]
        //public virtual ICollection<PhotoLike> likes { get; set; }
        [DisplayName("Paylaşımları")]
        public virtual ICollection<PhotoPost> photoposts { get; set; }
        //[DisplayName("Yorumları")]
        //public virtual ICollection<PhotoComment> photocomments { get; set; }
        
    }
}
