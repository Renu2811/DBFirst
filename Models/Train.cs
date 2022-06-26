using System;
using System.Collections.Generic;

namespace EFDBFirst.Data.Models
{
    public partial class Train
    {
        public Train()
        {
            TrainWorkingDays = new HashSet<TrainWorkingDay>();
        }

        public decimal TrainNo { get; set; }
        public string? TrainName { get; set; }
        public string? FromStation { get; set; }
        public string? ToStation { get; set; }
        public TimeSpan? JourneyStartTime { get; set; }
        public TimeSpan? JourneyEndTime { get; set; }

        public virtual ICollection<TrainWorkingDay> TrainWorkingDays { get; set; }
    }
}
