using System;
using System.Collections.Generic;

namespace EFDBFirst.Data.Models
{
    public partial class TrainWorkingDay
    {
        public int TrainId { get; set; }
        public DateTime? Date { get; set; }
        public string? Day { get; set; }
        public decimal? TrainNo { get; set; }

        public virtual Train? TrainNoNavigation { get; set; }
    }
}
