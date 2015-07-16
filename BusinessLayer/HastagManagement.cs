using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using MVCInstagramFatih.Entity;


namespace BusinessLayer
{
    public class HastagManagement
    {
        private Repository<PostHashtag> Rep { get; set; }

        public HastagManagement()
        {
            Rep = new Repository<PostHashtag>();
        }

        public IEnumerable<PostHashtag> GetHashtag()
        {
            return Rep.Listele();
        }
        public IEnumerable<PostHashtag> GetHashtag(string hastag)
        {
            return Rep.SorguyaGoreListele(x => x.HastagName == hastag);
        }
        public object PopulerHastag(int number)
        {
            List<PostHashtag> Hastaglar = Rep.Listele();

            var Hastaglar2 = (

                        from PostHashtag in Hastaglar
                        group PostHashtag by new
                        {
                            PostHashtag.HastagName
                        } into g
                        orderby
                          g.Count(p => p.HastagName != null) descending
                        select new
                        {
                            HastagCount = g.Count(p => p.HastagName != null),
                            HastagName = g.Key.HastagName
                        }
                );

            return Hastaglar2;
        }
            

    }
}
