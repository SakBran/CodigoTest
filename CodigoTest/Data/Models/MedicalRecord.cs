using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace template.Data.Models
{
    public class MedicalRecord
    {
        public MedicalRecord()
        {
            this.CreatedDate=DateTime.UtcNow;
        }
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public string sex { get; set; }
        public string phone { get; set; }
        public DateTime date { get; set; }
        public string bloodPressure { get; set; }
        public string pulseRate { get; set; }
        public string temperature { get; set; }
        public string SPO2 { get; set; }
        public string historyOfPresentIllness { get; set; }
        public string drugHistory { get; set; }
        public string examination { get; set; }
        public string investigations { get; set; }
        public string treatment { get; set; }
        public string pastMedicalHistory { get; set; }
        public string  currentDrugs { get; set; }
        public decimal fees { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}