﻿using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class City : RecordBase
    {
        [Required]
        [StringLength(170)]
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<UserDetail> UserDetails { get; set; }
    }
}
