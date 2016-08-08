using System.Collections.Generic;
using DAL.DataTransferObject;

namespace BLL.Entities
{
    public class QuestionEntity : IEntity
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public virtual ICollection<AnswerEntity> Answers { get; set; }
    }
}
