using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Система_учета_сотрудников._Дипломный_проект.View;
using Система_учета_сотрудников._Дипломный_проект.View.PageParts;
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
        public Command ShowWorkersKPDGraphiks {  get; set; }
        public Command ShowWorkersTimeTable {  get; set; }
        public Command ShowVisualPartsAllProjects {  get; set; }
        public Command ShowDiagramGant {  get; set; }

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
                control.Content = new KPDWorkers();
            }, () =>
            {
                return true;
            });
            ShowWorkersKPDGraphiks = new Command(() =>
            {
                control.Content = new Workers();
            }, () =>
            {
                return true;
            });
            ShowWorkersTimeTable = new Command(() =>
            {
                control.Content = new WorkersTimeTable();
            }, () =>
            {
                return true;
            });
            ShowVisualPartsAllProjects = new Command(() =>
            {
                control.Content = new VisualPartsAllProjects();
            }, () =>
            {
                return true;
            });
            ShowDiagramGant = new Command(() =>
            {
                control.Content = new DiagramGant();
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
