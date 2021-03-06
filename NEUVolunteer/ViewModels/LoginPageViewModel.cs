﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NEUVolunteer.Models;
using NEUVolunteer.Services;
using Xamarin.Essentials;

namespace NEUVolunteer.ViewModels
{
    public class LoginPageViewModel : NavigationViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService, IAlertService alertService, IDBService dbService) : base(
            navigationService) {
            _dbService = dbService;
            _alertService = alertService;
            
        }

        private IDBService _dbService;

        private IVolunteer _vi;
        private IManager _mi;
        private IAlertService _alertService;
        private string _username;
        public string UserName
        {
            get => _username;
            set => Set(nameof(UserName), ref _username, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => Set(nameof(Password), ref _password, value);
        }

        private RelayCommand _buttonCommand;

        public RelayCommand ButtonCommand =>
            _buttonCommand ?? (_buttonCommand = new RelayCommand(async () =>
        {
            if (_username == null || _password == null || _username == "" || _password == "")
            {
                await _alertService.ShowAlertAsync("登录失败", "用户名或密码不能为空", "确认");
            }
            else if (_username[0] >= 'a' && _username[0] <= 'z' || _username[0] >= 'A' && _username[0] <= 'Z')
            {
                //管理员
                Manager x = await _dbService.GetManagerAsync(_username);
                if (x == null || x.ManagerPassword != _password)
                {
                    //登录失败
                    await _alertService.ShowAlertAsync("登录失败", "用户名或密码错误，请输入正确的用户名和密码", "确认");

                }
                else
                {
                    //密码正确，跳转界面
                    User.UserId = x.ManagerId;
                    User.IsManager = true;
                    await _alertService.ShowAlertAsync("登录成功", "成功", "确认");
                    _navigationService.NavigationTo(NavigationServiceConstants.AdminPage, false);
                }

            }

            else
            {
                //志愿者
                Volunteer x = await _dbService.GetVolunteerAsync(_username);
                if (x == null || x.VolunteerPassword != _password)
                {
                    //登录失败
                    await _alertService.ShowAlertAsync("登录失败", "用户名或密码错误，请输入正确的用户名和密码", "确认");
                }
                else
                {
                    //密码正确，跳转界面
                    User.UserId = x.VolunteerId;
                    User.IsManager = false;
                    Preferences.Set("user", x.VolunteerId);
                    await _alertService.ShowAlertAsync("登录成功", "成功", "确认");
                    _navigationService.NavigationTo(NavigationServiceConstants.HomePage, false);

                }
            }
         }));
    }
}