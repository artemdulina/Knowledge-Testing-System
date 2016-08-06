using System.Collections.Generic;

namespace DAL.DataTransferObject
{
    public class DalQuestion : IEntity
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public virtual ICollection<DalAnswer> Answers { get; set; }
    }
}
