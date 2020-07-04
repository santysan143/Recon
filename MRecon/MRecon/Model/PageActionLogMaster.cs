﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class PageActionLogMaster
    {
        [Key]
        public Int64 PageActionLogID { get; set; }
        [Required]
        public Int64 LogID { get; set; }
        [Required]
        public string MethodName { get; set; }
        [Required]
        public DateTime ActivityStartDtTm { get; set; }
        public DateTime? ActivityEndDtTm { get; set; }
        public string RemarkType { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
