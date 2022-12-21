using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {

        //public EntityBase() // Aşağıdaki proportilerin default değerlerini burada yapabildiğimiz gibi aşağıdaki gibi de yapılabilir aralarında pek bi fark yok, aşağıdakilerdeki gibi oluşturmak daha performanslı 
        //{
        //    Id = Guid.NewGuid();
        //    CreatedDate = DateTime.Now;

        //}
       
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual string CreatedBy { get; set; } = "Ibrahim";
        public virtual string ModifiedBy { get; set; }
        public virtual string DeletedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiedDate { get; set; }     
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
    }
}
