using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WorkerManagementBLL.Models;
using WorkerManagementBLL.ViewModels;



namespace WorkerManagementUI.Views
{
    public partial class WorkerEditorWindow : Window
    {
        public WorkerModel EditedWorker
        {
            get { return ((WorkerEditorViewModel)DataContext).Worker; }
        }


        public WorkerEditorWindow()
        {
            InitializeComponent();

            WorkerModel workerModel = new WorkerModel();
            DataContext = new WorkerEditorViewModel(workerModel);
        }



        public WorkerEditorWindow(WorkerModel workerModel)
        {
            InitializeComponent();

            DataContext = new WorkerEditorViewModel(workerModel);
        }



        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
