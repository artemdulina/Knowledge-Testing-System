﻿using System;
using System.Collections.Generic;
using DAL.DataTransferObject;

namespace BLL.Entities
{
    public class TestEntity : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Topic { get; set; }

        public virtual ICollection<QuestionEntity> Questions { get; set; }

        public TimeSpan TimeLimit { get; set; }
    }
}
