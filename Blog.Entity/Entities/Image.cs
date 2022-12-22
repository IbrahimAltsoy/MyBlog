using Blog.Core.Entities;

namespace Blog.Entity.Entities
{
    public class Image : EntityBase
    {
        public Image()
        {


        }
        public Image(string fillName, string fillType)
        {
            FillName= fillName;
            FillType= fillType;

        }
        public Guid Id { get; set; }
        public string FillName { get; set; }
        public string FillType { get; set; }


        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
