using WorkerManagementDAL.Exchange;



namespace WorkerManagementBLL.Tests
{
    public class ConnectionCheck
    {
        public bool CheckDatabase()
        {
            try
            {
                WorkerTable workerTable = new WorkerTable();
                workerTable.GetWorkers();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
