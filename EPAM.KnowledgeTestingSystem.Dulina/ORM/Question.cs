using System.Collections.Generic;

namespace ORM
{
    public class Question
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
