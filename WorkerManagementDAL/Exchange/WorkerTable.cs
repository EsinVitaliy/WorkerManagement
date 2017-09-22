using System;
using System.Collections.Generic;
using System.Linq;
using WorkerManagementDAL.DataModel;



namespace WorkerManagementDAL.Exchange
{
    public class WorkerTable
    {
        public List<Worker> GetWorkers()
        {
            using (var context = new DatabaseContext())
            {
                var workers = context.Workers.ToList();

                if (workers.Count == 0)
                {
                    FillEmptyDatabase(context);
                    workers = context.Workers.ToList();
                }

                return workers;
            }
        }



        private void FillEmptyDatabase(DatabaseContext context)
        {
            List<Worker> workers = new List<Worker>();


            Worker worker = new Worker
            {
                LastName = "Иванов",
                FirstName = "Иван",
                BirthDate = new DateTime(2000, 01, 01),
                SexIsMale = true,
                ChildrenExists = false
            };

            workers.Add(worker);


            worker = new Worker
            {
                LastName = "Екатеринова",
                FirstName = "Екатерина",
                BirthDate = new DateTime(1990, 12, 15),
                SexIsMale = false,
                ChildrenExists = true
            };

            workers.Add(worker);


            context.Workers.AddRange(workers);
            context.SaveChanges();
        }



        public int InsertWorker(Worker newWorker)
        {
            using (var context = new DatabaseContext())
            {
                var addedRecord = context.Workers.Add(newWorker);
                context.SaveChanges();
                return addedRecord.Id;
            }
        }



        public void UpdateWorker(Worker updatedWorker)
        {
            using (var context = new DatabaseContext())
            {
                var worker = context.Workers.FirstOrDefault(i => i.Id == updatedWorker.Id);

                if (worker == null)
                    return;


                worker.LastName = updatedWorker.LastName;
                worker.FirstName = updatedWorker.FirstName;
                worker.BirthDate = updatedWorker.BirthDate;
                worker.SexIsMale = updatedWorker.SexIsMale;
                worker.ChildrenExists = updatedWorker.ChildrenExists;

                context.SaveChanges();
            }
        }



        public void DeleteWorker(int workerId)
        {
            using (var context = new DatabaseContext())
            {
                // удаление за один запрос к базе
                var toDelete = new Worker { Id = workerId };
                context.Workers.Attach(toDelete);
                context.Workers.Remove(toDelete);

                context.SaveChanges();
            }
        }
    }
}
