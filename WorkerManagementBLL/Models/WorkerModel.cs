using System;
using System.ComponentModel;
using WorkerManagementDAL.DataModel;



namespace WorkerManagementBLL.Models
{
    public class WorkerModel : ModelBase, IDataErrorInfo
    {
        #region Id

        private int _id;


        public int Id
        {
            get { return _id; }

            set
            {
                if (_id == 0 && _id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        #endregion

        #region FirstName

        private string _firstName;


        public string FirstName
        {
            get { return _firstName; }

            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        #endregion

        #region LastName

        private string _lastName;


        public string LastName
        {
            get { return _lastName; }

            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        #endregion

        #region BirthDate

        private DateTime _birthDate;


        public DateTime BirthDate
        {
            get { return _birthDate; }

            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged("BirthDate");
                }
            }
        }

        #endregion

        #region SexIsMale

        private bool _sexIsMale;


        public bool SexIsMale
        {
            get { return _sexIsMale; }

            set
            {
                if (_sexIsMale != value)
                {
                    _sexIsMale = value;
                    OnPropertyChanged("SexIsMale");
                }
            }
        }

        #endregion

        #region ChildrenExists

        private bool _childrenExists;


        public bool ChildrenExists
        {
            get { return _childrenExists; }

            set
            {
                if (_childrenExists != value)
                {
                    _childrenExists = value;
                    OnPropertyChanged("ChildrenExists");
                }
            }
        }

        #endregion


        #region члены IDataErrorInfo

        public string Error
        {
            get
            {
                if (string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(FirstName))
                    return "Поля, выделенные красным цветом, должны быть заполнены.";

                return null;
            }
        }


        public string this[string columnName]
        {
            get
            {
                if (columnName == "LastName")
                {
                    if (string.IsNullOrWhiteSpace(LastName))
                        return "Введите фамилию";
                }

                if (columnName == "FirstName")
                {
                    if (string.IsNullOrWhiteSpace(LastName))
                        return "Введите имя";
                }

                return null;
            }
        }

        #endregion


        #region конструкторы

        public WorkerModel()
        {
            BirthDate = new DateTime(2000, 1, 1);
        }



        public WorkerModel(Worker worker)
        {
            Id = worker.Id;
            LastName = worker.LastName;
            FirstName = worker.FirstName;
            BirthDate = worker.BirthDate;
            SexIsMale = worker.SexIsMale;
            ChildrenExists = worker.ChildrenExists;
        }

        #endregion


        #region методы

        public WorkerModel Duplicate()
        {
            return new WorkerModel
            {
                Id = Id,
                LastName = LastName,
                FirstName = FirstName,
                BirthDate = BirthDate,
                SexIsMale = SexIsMale,
                ChildrenExists = ChildrenExists
            };
        }



        public Worker ToWorkerRecord()
        {
            return new Worker
            {
                Id = Id,
                LastName = LastName,
                FirstName = FirstName,
                BirthDate = BirthDate,
                SexIsMale = SexIsMale,
                ChildrenExists = ChildrenExists
            };
        }

        #endregion
    }
}
