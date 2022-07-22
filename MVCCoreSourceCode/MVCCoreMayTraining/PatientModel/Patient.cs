﻿using System;
using System.Collections.Generic;

namespace PatientModel
{
    public class Patient
    {
        public int id { get; set; }
        public string patientName { get; set; }

        public List<Problem> Problems { get; set; }
    }
    public class Problem
    {
        public int id { get; set; }
        public string description { get; set; }
    }
}
