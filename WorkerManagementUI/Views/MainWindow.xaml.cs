using System.Windows;
using System.Windows.Input;
using WorkerManagementBLL.Tests;
using WorkerManagementBLL.ViewModels;



namespace WorkerManagementUI.Views
{
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; private set; }


        public MainWindow()
        {
            InitializeComponent();

            CheckDatabaseConnection();

            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }



        private void CheckDatabaseConnection()
        {
            ConnectionCheck check = new ConnectionCheck();

            if (!check.CheckDatabase())
            {
                MessageBox.Show("Ошибка соединия с SQL сервером. Настройте файл \"App.config\".", "Ошибка", MessageBoxButton.OK);
                Application.Current.Shutdown();
            }
        }



        private void ItemAddRecord_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new WorkerEditorWindow();
            window.Owner = this;
            var dialogResult = window.ShowDialog();

            if (dialogResult == true)
                ViewModel.AddWorker(window.EditedWorker);
        }



        private void GridWorkers_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditSelectedRecord();
        }



        private void ItemEditRecord_OnClick(object sender, RoutedEventArgs e)
        {
            EditSelectedRecord();
        }



        private void EditSelectedRecord()
        {
            if (ViewModel.SelectedItem == null)
                return;


            var window = new WorkerEditorWindow(ViewModel.SelectedItem.Duplicate());
            window.Owner = this;
            var dialogResult = window.ShowDialog();

            if (dialogResult == true)
                ViewModel.UpdateWorker(ViewModel.SelectedItem, window.EditedWorker);
        }
    }
}
