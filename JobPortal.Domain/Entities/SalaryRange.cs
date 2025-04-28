using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Enums;

namespace JobPortal.Domain.Entities
{
    public class SalaryRange
    {
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public string? Currency { get; set; }
        public SalaryFrequency SalaryFrequency { get; set; } = SalaryFrequency.Negotiable;
    }
}
