
using EFDBFirst.Data;
using EFDBFirst.Data.Models;

namespace EFDBFirstConsole
{

    public static class Program
    {
        public static void Main()
        {
            CrudManager obj = new CrudManager();

            //Console.WriteLine("Adding the new train details");
            //obj.Insert(new Train { TrainNo = 1234, TrainName = "VenkatadriExpress", FromStation = "Secunderabad", ToStation = "Thirupathi", JourneyStartTime = new TimeSpan(3, 00, 00), JourneyEndTime = new TimeSpan(7, 00, 00) });
            //obj.Insert(new Train { TrainNo = 4563, TrainName = "ShivaniExpress", FromStation = "Hyderabad", ToStation = "Kadapa", JourneyStartTime = new TimeSpan(2, 30, 00), JourneyEndTime = new TimeSpan(8, 00, 00) });
            //obj.Insert(new Train { TrainNo = 8765, TrainName = "RajdhaniExpress", FromStation = "Vizag", ToStation = "Hyderabad", JourneyStartTime = new TimeSpan(5, 00, 00), JourneyEndTime = new TimeSpan(9, 45, 00) });

            //Console.WriteLine("Updating the train details");
            //obj.Update(4563, new Train { TrainName = "MahendraExpress", FromStation = "Kurnool" });

            //Console.WriteLine("Deleting the train details");
            //obj.Delete(4563);


            //Console.WriteLine("Retrieving Train details by TrainNo");
            //var train = obj.GetTrainDetailsByNo(8765);

            //Console.WriteLine("Retrieving Train details by From and To Stations");
            //var train1 = obj.GetTrainDetailsByStations("Vizag", "Hyderabad");



            CrudTrainWorkingDays obj1 = new CrudTrainWorkingDays();
            //Console.WriteLine("Inserting Train details in train and working days");

            //List<TrainWorkingDay> trainWorkingDays = new List<TrainWorkingDay>();
            //trainWorkingDays.Add(new TrainWorkingDay { Date = new DateTime(2022, 06, 25), Day = "Sunday" });
            //trainWorkingDays.Add(new TrainWorkingDay { Date = new DateTime(2022, 07, 10), Day = "Wednesday" });

            //obj1.InsertTrainAndWorkingDays(new Train
            //{   TrainNo = 2536, 
            //    TrainName = "ShivaniExpress",
            //    FromStation = "Kurnool", 
            //    ToStation = "Kadapa", 
            //    JourneyStartTime = new TimeSpan(04, 35, 00),
            //    JourneyEndTime = new TimeSpan(02, 3, 00)
            //},
            //    trainWorkingDays);
            Console.WriteLine("Inserting Train Details of existing train");
            List<TrainWorkingDay> trainWorkingDays = new List<TrainWorkingDay>();


            //trainWorkingDays.Add(new TrainWorkingDay {Date=new DateTime(2022,09,12),Day="Thursday"});
            //trainWorkingDays.Add(new TrainWorkingDay { Date = new DateTime(2022,10,29), Day = "Monday" });

            //obj1.InsertTrainWorkingDaysofExistingTrain(2536, trainWorkingDays);



            //trainWorkingDays.Add(new TrainWorkingDay { Date = new DateTime(2022,12,03), Day = "Friday" });
            //trainWorkingDays.Add(new TrainWorkingDay { Date = new DateTime(2022, 11,10), Day = "Sunday" });

            //obj1.InsertTrainWorkingDaysofExistingTrain(1234, trainWorkingDays);



            trainWorkingDays.Add(new TrainWorkingDay { Date = new DateTime(2022, 10,16), Day = "Wednesday" });
            trainWorkingDays.Add(new TrainWorkingDay { Date = new DateTime(2022,08,20), Day = "Thursday" });
            trainWorkingDays.Add(new TrainWorkingDay { Date = new DateTime(2022, 07,25), Day = "Tuesday" });


            obj1.InsertTrainWorkingDaysofExistingTrain(8765, trainWorkingDays);


            //pint all the Train Details 
            obj.PrintAllTraindetails();

            Console.ReadLine();
        }
    }

}