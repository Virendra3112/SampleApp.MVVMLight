﻿using SampleApp.MVVMLight.Models;
using System;
using System.Collections.ObjectModel;

namespace SampleApp.MVVMLight.ViewModels
{
    public class NavigationDrawerPageViewModel : BaseViewModel
    {
        private ObservableCollection<MenuModel> _menuList;
        public ObservableCollection<MenuModel> MenuList
        {
            get
            {
                return _menuList;
            }
            set
            {
                if (_menuList != value)
                {
                    _menuList = value;
                    OnPropertyChanged();
                }
            }
        }

        private MenuModel _selectedMenu;
        public MenuModel SelectedMenu
        {
            get
            {
                return _selectedMenu;
            }
            set
            {
                _selectedMenu = value;
                OnPropertyChanged();

                if (_selectedMenu != null)
                    NavigateToPage(_selectedMenu);
            }
        }
        public NavigationDrawerPageViewModel()
        {
        }

        public void GetData()
        {
            try
            {
                MenuList = new ObservableCollection<MenuModel>();

                MenuList.Add(new MenuModel
                {
                    Icon = "icon",
                    PageName = "",
                    Title = "Home"
                });

                MenuList.Add(new MenuModel
                {
                    Icon = "icon",
                    PageName = "",
                    Title = "SampleItem1"
                });
                MenuList.Add(new MenuModel
                {
                    Icon = "icon",
                    PageName = "",
                    Title = "SampleItem2"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void NavigateToPage(MenuModel selectedMenu)
        {
            try
            {
                //ToDo: Add page navigation here

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
