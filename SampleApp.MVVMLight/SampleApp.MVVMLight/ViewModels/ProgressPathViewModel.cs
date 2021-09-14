using SampleApp.MVVMLight.Models.UIModels;
using System;
using System.Collections.ObjectModel;

namespace SampleApp.MVVMLight.ViewModels
{
    public class ProgressPathViewModel : BaseViewModel
    {

        private ObservableCollection<ProgressPathModel> _groupedItems;
        public ObservableCollection<ProgressPathModel> GroupedItems
        {
            get { return _groupedItems; }
            set
            {
                _groupedItems = value; OnPropertyChanged();
            }
        }

        public ProgressPathViewModel()
        {
            GroupedItems = new ObservableCollection<ProgressPathModel>();

            GetData();
        }

        private void GetData()
        {
            try
            {
                GroupedItems.Add(new ProgressPathModel
                {
                    Id = 1,
                    Name = "Test Item 1",
                    ImageOrientation = "Horizontal",
                    ImagePath = "resource://SampleApp.MVVMLight.Resources.path.svg",
                    IsCompleted = true
                });

                GroupedItems.Add(new ProgressPathModel
                {
                    Id = 2,
                    Name = "Test Item 2",
                    ImageOrientation = "Vertical",
                    ImagePath = "resource://SampleApp.MVVMLight.Resources.pathvertical.svg",
                    IsCompleted = false
                });

                GroupedItems.Add(new ProgressPathModel
                {
                    Id = 3,
                    Name = "Test Item 3",
                    ImageOrientation = "Horizontal",
                    ImagePath = "resource://SampleApp.MVVMLight.Resources.pathvertical.svg",
                    IsCompleted = false
                });

                GroupedItems.Add(new ProgressPathModel
                {
                    Id = 4,
                    Name = "Test Item 4",
                    ImageOrientation = "Vertical",
                    ImagePath = "resource://SampleApp.MVVMLight.Resources.pathvertical.svg",
                    IsCompleted = false
                });
                GroupedItems.Add(new ProgressPathModel
                {
                    Id = 5,
                    Name = "Test Item 5",
                    ImageOrientation = "Vertical",
                    ImagePath = "resource://SampleApp.MVVMLight.Resources.pathvertical.svg",
                    IsCompleted = false
                });
                GroupedItems.Add(new ProgressPathModel
                {
                    Id = 6,
                    Name = "Test Item 6",
                    ImageOrientation = "Vertical",
                    ImagePath = "resource://SampleApp.MVVMLight.Resources.pathvertical.svg",
                    IsCompleted = false
                });
                GroupedItems.Add(new ProgressPathModel
                {
                    Id = 7,
                    Name = "Test Item 7",
                    ImageOrientation = "Vertical",
                    ImagePath = "resource://SampleApp.MVVMLight.Resources.pathvertical.svg",
                    IsCompleted = false
                });

            }

            catch (Exception ex)
            {

            }
        }
    }
}
