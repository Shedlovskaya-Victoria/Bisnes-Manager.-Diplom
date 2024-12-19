using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BisnesManager.Client.Tools;
using BisnesManager.Client.View;
using BisnesManager.Client.View.PageParts;
using BisnesManager.Client.View.Pages;
using BisnesManager.Client.View.ProgramUserControl;

namespace BisnesManager.Client.ViewModel
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
            // settings
            GoToSystemSettings = new Command(() =>
            {
                control.Content = new Settings();
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
                control.Content = new AccountsWorkers();
            }, () =>
            {
                return true;
            });
            EditPosition = new Command(() =>
            {
                control.Content = new EditDolzjnost();
            }, () =>
            {
                return true;
            });
        }

    }
}
