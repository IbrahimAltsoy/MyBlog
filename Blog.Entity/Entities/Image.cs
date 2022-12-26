using Blog.Core.Entities;
using Blog.Entity.Enums;

namespace Blog.Entity.Entities
{
    public class Image : EntityBase
    {
        public Image()
        {


        }
        public Image(string fillName, string fillType, string createdBy)
        {
            FillName= fillName;
            FillType= fillType;
            CreatedBy= createdBy;

        }
        //public Guid Id { get; set; } Buraya dikkat et!!! 
        public string FillName { get; set; }
        public string FillType { get; set; }
        


        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get; set; }

       
    }
}
