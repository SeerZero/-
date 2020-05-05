﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NEUVolunteer.Models
{
    [SQLite.Table("Apply")]
    public class Apply
    {
        [SQLite.Column("ApplyId")] 
        public int ApplyId { get; set; }

        [SQLite.Column("ApplyActivityId")]
        public int ApplyActivityId { get; set; }

        [SQLite.Column("ApplyManagerId")]
        public int ApplyManagerId { get; set; }

        [SQLite.Column("GatherTime")]
        public string GatherTime { get; set; }

        [SQLite.Column("StartTime")]
        public string StartTime { get; set; }

        [SQLite.Column("EndTime")]
        public string EndTime { get; set; }
        
        [SQLite.Column("Number")]
        public int Number { get; set; }

    }
}