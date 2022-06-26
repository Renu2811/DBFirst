using EFDBFirst.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBFirst.Data
{
    public class CrudManager
    {
        readonly DBFirstContext dBFirstContext = new DBFirstContext();


        public void Insert(Train train)
        {
            dBFirstContext.Trains.Add(train);
            dBFirstContext.SaveChanges();
        }

        public void Update(int trainNo, Train modifiedTrain)
        {
            var train = dBFirstContext.Trains.Where(x => x.TrainNo == trainNo).FirstOrDefault();
            if (train == null)
            {
                Console.WriteLine($"Train with ID:{trainNo} Not Found");



            }


            else
            {
                train.TrainName = modifiedTrain.TrainName;
                train.FromStation = modifiedTrain.FromStation;

                // Entity state : Modified
                dBFirstContext.Trains.Update(train);

                // This issues insert statement
                dBFirstContext.SaveChanges();
            }

            
        }

        public void Delete(decimal trainNo)
        {
            var train = dBFirstContext.Trains.Where(x => x.TrainNo == trainNo).FirstOrDefault();
            if (train == null)
            {
                Console.WriteLine($"Train with number:{trainNo} Not Found");
            }
            else
            {

                dBFirstContext.Trains.Remove(train);

                // This issues insert statement
                dBFirstContext.SaveChanges();
            }

            
        }

        public void GetTrainDetailsByNo(int trainNo)
        {
            // Tracking not required
            var train = dBFirstContext.Trains.Where(x => x.TrainNo == trainNo)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            if (train == null)
            {
                Console.WriteLine($"Train with number:{trainNo} Not Found");

                
            }
            else
            {
                
                Console.WriteLine($"Train Name of TrainNo 8765 is {train.TrainName}, starting from {train.FromStation} and landed at {train.ToStation}");

            }




        }

        public void GetTrainDetailsByStations(string fromStation, string toStation)
        {
            var train = dBFirstContext.Trains.Where(x => x.FromStation == fromStation || x.ToStation == toStation)
                                        .AsNoTracking()
                            .FirstOrDefaultAsync().Result;
            if (train == null)
            {
                Console.WriteLine($"Train with stations {fromStation} and {toStation} Not Found");
            }
            else
            {
                Console.WriteLine($"The train details from {train.FromStation} and {train.ToStation} are \n Train No:{train.TrainNo}\n Train Name: {train.TrainName}" +
            $"\n Train FromStation: {train.FromStation}\n Train ToStation: {train.ToStation}\n");

            }
        }

        public void PrintAllTraindetails()
        {
            var train = dBFirstContext.Trains.Include(x => x.TrainWorkingDays).ToList();
            if (train != null)
            {
                foreach (Train train1 in train)
                {
                    Console.WriteLine("Train Number  :" + train1.TrainNo);
                    Console.WriteLine("Train Name  :" + train1.TrainName);
                    Console.WriteLine("Train From Station  :" + train1.FromStation);
                    Console.WriteLine("Train To Station  :" + train1.ToStation);
                    Console.WriteLine("Train Journey starts Time :" + train1.JourneyStartTime);
                    Console.WriteLine("Train Journey Ends Time :" + train1.JourneyEndTime);

                    foreach (TrainWorkingDay trainWorkingDays in train1.TrainWorkingDays)
                    {
                        Console.WriteLine("Train ID :" + trainWorkingDays.TrainId);
                        Console.WriteLine("Train Run Days :" + trainWorkingDays.Date);
                        Console.WriteLine("Train Run Days :" + trainWorkingDays.Day);

                    }
                    Console.WriteLine();
                    Console.WriteLine("Train  Details");
                }
            }
            else
            {
                Console.WriteLine(" Record has been not found :");
            }
        }
    }







}


