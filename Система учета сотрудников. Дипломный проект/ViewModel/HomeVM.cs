using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Система_учета_сотрудников._Дипломный_проект.View;
using Система_учета_сотрудников._Дипломный_проект.View.Pages;
using Система_учета_сотрудников._Дипломный_проект.View.ProgramUserControl;

namespace Система_учета_сотрудников._Дипломный_проект.ViewModel
{
    public class HomeVM
    {
        public Command Find {  get; set; }

        public Command GoToPersonalCabinet {  get; set; }
        public Command GoToHome {  get; set; }
        public Command GoToSystemSettings {  get; set; }
        public Command GoToAdministrationOffice {  get; set; }
        public Command GoToUploadLists {  get; set; }

        public Command ShowKPDWorkers {  get; set; }
        public Command ShowWeekendsPlan {  get; set; }
        public Command ShowWorkersGraphiks {  get; set; }

        public Command EditWorkers {  get; set; }
        public Command EditPosition {  get; set; }
        public Command EditWorkersGraphiks {  get; set; }

        public HomeVM() { }

        public HomeVM(ContentControl control)
        {
            Find = new Command(() =>
            {
               
            }, () =>
            {
                return true;
            });
            // go to
            GoToPersonalCabinet = new Command(() =>
            {
                Navigation.Instance().CurrentPage = new PersonalCabinet();
            }, () =>
            {
                return true;
            });
            GoToHome = new Command(() =>
            {
                control.Content = new TasksBoard();
            }, () =>
            {
                return true;
            });
            GoToAdministrationOffice = new Command(() =>
            {
            }, () =>
            {
                return true;
            });
            GoToSystemSettings = new Command(() =>
            {
            }, () =>
            {
                return true;
            });
            GoToUploadLists = new Command(() =>
            {
            }, () =>
            {
                return true;
            });
            //    show
            ShowKPDWorkers = new Command(() =>
            {
            }, () =>
            {
                return true;
            });
            ShowWeekendsPlan = new Command(() =>
            {
            }, () =>
            {
                return true;
            });
            ShowWorkersGraphiks = new Command(() =>
            {
            }, () =>
            {
                return true;
            });
            //     edit
            EditWorkers = new Command(() =>
            {
            }, () =>
            {
                return true;
            });
            EditPosition = new Command(() =>
            {
            }, () =>
            {
                return true;
            });
            EditWorkersGraphiks = new Command(() =>
            {
            }, () =>
            {
                return true;
            });
        }

    }
}
