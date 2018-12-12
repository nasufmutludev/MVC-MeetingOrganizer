using System.ComponentModel.DataAnnotations;

namespace MOEntities
{
    public abstract class Entity
    {
        [Key]
        public virtual int ID { get; set; }

        public bool IsDeleted { get; set; }
    }
}
