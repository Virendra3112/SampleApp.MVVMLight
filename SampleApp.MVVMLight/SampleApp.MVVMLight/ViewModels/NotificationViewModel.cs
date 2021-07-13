using SampleApp.MVVMLight.Models.UIModels;
using System;
using System.Collections.ObjectModel;

namespace SampleApp.MVVMLight.ViewModels
{
    public class NotificationViewModel : BaseViewModel
    {
        private ObservableCollection<Notification> _detailsList;
        public ObservableCollection<Notification> DetailsList
        {
            get
            {
                return _detailsList;
            }
            set
            {
                if (_detailsList != value)
                {
                    _detailsList = value;
                    OnPropertyChanged();
                }
            }
        }
        public NotificationViewModel()
        {

        }

        public void GetData()
        {
            try
            {
                DetailsList = new ObservableCollection<Notification>();
                DetailsList.Add(new Notification
                {
                    Body = "Test body",
                    Title = "Test Titel"
                }); DetailsList.Add(new Notification
                {
                    Body = "Test body",
                    Title = "Test Titel"
                }); DetailsList.Add(new Notification
                {
                    Body = "Test body",
                    Title = "Test Titel"
                }); DetailsList.Add(new Notification
                {
                    Body = "Test body",
                    Title = "Test Titel"
                }); DetailsList.Add(new Notification
                {
                    Body = "Test body",
                    Title = "Test Titel"
                });

            }
            catch (Exception ex)
            {

            }
        }
    }
}
