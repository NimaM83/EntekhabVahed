﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Domain.Entities.Time
{
    public  class Time
    {
        [Key]
        public Guid Id { get; set; }
        public TimeOnly From { get; set; }
        public TimeOnly To { get; set; }
        public Guid EVId { get; set; }

    }
}
