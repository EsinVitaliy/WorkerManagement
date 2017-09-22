using WorkerManagementBLL.Models;



namespace WorkerManagementBLL.ViewModels
{
    public class WorkerEditorViewModel
    {
        #region свойство

        public WorkerModel Worker { get; private set; }

        #endregion


        #region конструктор

        public WorkerEditorViewModel(WorkerModel workerModel)
        {
            Worker = workerModel;
        }

        #endregion
    }
}
