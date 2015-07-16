namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using MVCInstagramFatih.Entity;

    public class InstagramModel : DbContext
    {
        // Your context has been configured to use a 'InstagramModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.InstagramModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'InstagramModel' 
        // connection string in the application configuration file.
        public InstagramModel()
        {
            Database.SetInitializer<InstagramModel>(new StartDatas());
        }
        public virtual DbSet<PhotoPost> PhotoPosts { get; set; }
        public virtual DbSet<PhotoComment> PhotoComments { get; set; }
        public virtual DbSet<PhotoLike> PhotoLikes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PostHashtag> PostHastags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class StartDatas : CreateDatabaseIfNotExists<InstagramModel>
    {
        protected override void Seed(InstagramModel context)
        {
            #region -  Add user --
            User u1 = new User()
            {
                AktifMi=true,
                Description = "Bir yönü ile Junior Web Developer bir yönü ile Biliþim Teknolojileri Öðretmeni. Eðitim ve teknolojiyi bir gören araþtýrmacý, meraklý ve çalýþkan bir insan. Biraz oyun baðýmlýsý biraz inatçý, nede olsa karadenizli kaný var.",
                FirstName="Fatih GÜRDAL",
                ProfilImagePath = "~/img/images/user/fatih.jpg",
                UserName="fatihgurdal",
                UserPass="1445"                
                
            };

            User u2 = new User()
            {
                AktifMi = true,
                Description = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                FirstName = "Enes GÜRDAL",
                ProfilImagePath = "~/img/images/user/enes.png",
                UserName = "enesgurdal",
                UserPass = "1445"                

            };
            context.Users.Add(u1);
            context.Users.Add(u2);

            context.SaveChanges();
            #endregion

            #region -  add hastag and post  -
            List<PostHashtag> Hastags = new List<PostHashtag>();
            List<PostHashtag> Hastags2 = new List<PostHashtag>();
            List<PostHashtag> Hastags3 = new List<PostHashtag>();
            Hastags.Add(new PostHashtag()
            {
                HastagName="Yazýlým"                
            });

            Hastags.Add(new PostHashtag()
            {
                HastagName = "C#"
            });

            Hastags2.Add(new PostHashtag()
            {
                HastagName = "MVC"
            });
            Hastags3.Add(new PostHashtag()
            {
                HastagName = "konudýþý"
            });

            PhotoPost p1 = new PhotoPost()
            {
                AktifMi=true,
                InsertDate=DateTime.Now,
                IsPhoto=true,
                PhotoDescription = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                PhotoPath = "~/img/images/post/col1-portfolio01.jpg",
                posthashtag = Hastags,
                user=u1
            };
          
            PhotoPost p2 = new PhotoPost()
            {
                AktifMi = true,
                InsertDate = DateTime.Now,
                IsPhoto = true,
                PhotoDescription = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                PhotoPath = "~/img/images/post/col1-portfolio02.jpg",
                posthashtag = Hastags2,
                user = u2
            };
            context.PhotoPosts.Add(p1);
            context.SaveChanges();
            context.PhotoPosts.Add(p2);
            context.SaveChanges();
          
            PhotoPost p3 = new PhotoPost()
            {
                AktifMi = true,
                InsertDate = DateTime.Now,
                IsPhoto = false,
                PhotoDescription = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                PhotoPath = "~/img/images/post/Wildlife.mp4",
                posthashtag = Hastags3,
                user = u1
            };
            context.PhotoPosts.Add(p3);
            context.SaveChanges();
            #endregion

            #region -  like and comment  -
            p1.photolikes.Add(new PhotoLike()
            {
                user=u1
            });

            p3.photolikes.Add(new PhotoLike()
            {
                user = u1
            });

            p1.photolikes.Add(new PhotoLike()
            {
                user = u2
            });

            p2.photolikes.Add(new PhotoLike()
            {
                user = u2
            });

            p1.photocomments.Add(new PhotoComment()
            {
                CommentStr = "yorum deneme 1 yorum deneme 1 yorum deneme 1 yorum deneme 1",
                InsertDate=DateTime.Now,
                user=u1
            });
            p1.photocomments.Add(new PhotoComment()
            {
                CommentStr = "yorum deneme 2 yorum deneme 2 yorum deneme 2 yorum deneme 2",
                InsertDate = DateTime.Now,
                user = u2
            });

            p3.photocomments.Add(new PhotoComment()
            {
                CommentStr = "yorum deneme 3 yorum deneme 3 yorum deneme 3 yorum deneme 3",
                InsertDate = DateTime.Now,
                user = u1
            });
            context.SaveChanges();
            #endregion
        }
    }
}