using Blog.Core.Entities;

namespace Blog.Entity.Entities
{
    public class Category : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public ICollection<Article> Articles { get; set; }
    }
}
