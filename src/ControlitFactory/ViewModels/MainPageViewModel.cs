using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ControlitFactory.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace ControlitFactory.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            HelpCommand = new DelegateCommand(Help);
        }

        private void Help()
        {
            if (App.Profils == null)
            {
                Device.OpenUri(new Uri("http://controlit.lv/en/mobile-app/"));
            }
            else
            {
                switch (App.Profils.Valoda)
                {
                    case "LV":
                        Device.OpenUri(new Uri("http://controlit.lv/mob-aplikacija/"));
                        break;
                    case "SE":
                        Device.OpenUri(new Uri("http://controlit.lv/sv/mobilapplikation/"));
                        break;
                    case "LT":
                        Device.OpenUri(new Uri("http://controlit.lv/lt/1041-2/"));
                        break;
                    default:
                        Device.OpenUri(new Uri("http://controlit.lv/en/mobile-app/"));
                        break;
                }
            }
        }

        public DelegateCommand PievienotDefektacijasAktuCommand { get; set; }

        public DelegateCommand HelpCommand { get; set; }
        public DelegateCommand<DefektacijasAkts> AtvertDefektacijasAktuCommand { get; set; }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Implement your initialization logic
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            switch (parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    // TODO: Handle any tasks that should occur only when navigated back to
                    break;
                case NavigationMode.New:
                    // TODO: Handle any tasks that should occur only when navigated to for the first time
                    break;
            }

            // TODO: Handle any tasks that should be done every time OnNavigatedTo is triggered
        }
    }
}