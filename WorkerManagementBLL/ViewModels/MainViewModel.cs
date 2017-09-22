using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WorkerManagementBLL.Foundation;
using WorkerManagementBLL.Models;
using WorkerManagementDAL.Exchange;



namespace WorkerManagementBLL.ViewModels
{
    public class MainViewModel
    {
        #region свойства

        public ObservableCollection<WorkerModel> Workers { get; private set; }

        public ObservableCollection<string> Genders { get; private set; }

        public WorkerModel SelectedItem { get; set; }

        #endregion


        #region конструктор

        public MainViewModel()
        {
#if DEBUG
            // защита от запуска из дизайнера окна
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;
 #endif


            WorkerTable workerTable = new WorkerTable();
            var workerRecords = workerTable.GetWorkers();

            ObservableCollection<WorkerModel> workers = new ObservableCollection<WorkerModel>();

            foreach (var record in workerRecords)
            {
                WorkerModel worker = new WorkerModel(record);
                workers.Add(worker);
            }

            Workers = workers;


            Genders = new ObservableCollection<string> { "женский", "мужской" };


            DeleteCommand = new RelayCommand(DeleteSelectedWorker);
        }

        #endregion


        #region команда

        public ICommand DeleteCommand { get; set; }


        private void DeleteSelectedWorker(object parameter)
        {
            if (SelectedItem == null)
                return;


            var dialogResult = MessageBox.Show("Подтверждаете удаление?", "Удаление", MessageBoxButton.YesNo);

            if (dialogResult == MessageBoxResult.Yes)
            {
                WorkerTable table = new WorkerTable();
                table.DeleteWorker(SelectedItem.Id);

                Workers.Remove(SelectedItem);
            }
        }

        #endregion


        #region методы

        public void AddWorker(WorkerModel worker)
        {
            WorkerTable table = new WorkerTable();
            int id = table.InsertWorker(worker.ToWorkerRecord());
            worker.Id = id;

            Workers.Add(worker);
        }



        public void UpdateWorker(WorkerModel originalWorker, WorkerModel updatedWorker)
        {
            WorkerTable table = new WorkerTable();
            table.UpdateWorker(updatedWorker.ToWorkerRecord());

            var workerIndex = Workers.IndexOf(originalWorker);

            if (workerIndex == -1)
                return;


            Workers[workerIndex] = updatedWorker;
        }

        #endregion
    }
}
