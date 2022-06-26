using EFDBFirst.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBFirst.Data
{
    public  class CrudTrainWorkingDays
    {
        readonly DBFirstContext demoDbContext = new DBFirstContext();

       
        public void InsertTrainAndWorkingDays(Train train, List<TrainWorkingDay> trainWorkingDays)
        {
            var objTrain = new Train
            {
                TrainNo=train.TrainNo,
                TrainName = train.TrainName,
                FromStation = train.FromStation,
                ToStation = train.ToStation,
                JourneyStartTime = train.JourneyStartTime,
                JourneyEndTime = train.JourneyEndTime,
                TrainWorkingDays =trainWorkingDays



            };

            demoDbContext.Trains.Add(objTrain);
            demoDbContext.SaveChanges();


        }

        public void InsertTrainWorkingDaysofExistingTrain(int trainNo, List<TrainWorkingDay> trainWorkingDays)
        {
            var objTrain = demoDbContext.Trains.Where(x => x.TrainNo == trainNo).Include(e => e.TrainWorkingDays).First();


           
            
            //objEmployee.OrganizationList.Clear();
            //demoDbContext.SaveChanges();

            foreach (TrainWorkingDay trainWorkingDay in trainWorkingDays)
            {
                objTrain.TrainWorkingDays.Add(trainWorkingDay);
            }

            demoDbContext.TrainWorkingDays.UpdateRange();
            demoDbContext.SaveChanges();
        }
    }
}


