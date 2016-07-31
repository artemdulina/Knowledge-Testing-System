using System;
using System.Collections.Generic;

namespace ORM
{
    public class Test
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Topic { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public TimeSpan TimeLimit { get; set; }
    }
}
