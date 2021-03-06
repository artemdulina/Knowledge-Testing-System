﻿using System;
using System.Collections.Generic;

namespace DAL.DataTransferObject
{
    public class DalTest : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Topic { get; set; }

        public ICollection<DalUser> Users { get; set; }

        public ICollection<DalQuestion> Questions { get; set; }

        public TimeSpan TimeLimit { get; set; }
    }
}
