
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Система_учета_сотрудников._Дипломный_проект.Tools;

namespace Система_учета_сотрудников._Дипломный_проект.View.ProgramUserControl
{
    /// <summary>
    /// Логика взаимодействия для Tasks.xaml
    /// </summary>
    public partial class TasksBoard : UserControl
    {
        public ObservableCollection<ShareConfiguration> ShareList { get; set; }

        #region DraggedItem

        /// <summary>
        /// DraggedItem Dependency Property
        /// </summary>
        public static readonly DependencyProperty DraggedItemProperty =
            DependencyProperty.Register("DraggedItem", typeof(ShareConfiguration), typeof(TasksBoard));

        /// <summary>
        /// Gets or sets the DraggedItem property.  This dependency property 
        /// indicates ....
        /// </summary>
        public ShareConfiguration DraggedItem
        {
            get { return (ShareConfiguration)GetValue(DraggedItemProperty); }
            set { SetValue(DraggedItemProperty, value); }
        }

        #endregion
        public TasksBoard()
        {

            InitializeComponent();
            DataContext = this;

            //init a few sample items
            ShareList = new ObservableCollection<ShareConfiguration>();
            ShareList.Add(new ShareConfiguration { Name = "Home", NetworkLocation = @"\\10.0.0.100\home" });
            ShareList.Add(new ShareConfiguration { Name = "Media", NetworkLocation = @"\\10.0.0.50\media" });
            ShareList.Add(new ShareConfiguration { Name = "Backup", NetworkLocation = @"\\10.0.0.50\backup" });
            ShareList.Add(new ShareConfiguration { Name = "Blog", NetworkLocation = @"\\10.0.0.100\blog" });
        }
        /// <summary>
        /// State flag which indicates whether the grid is in edit
        /// mode or not.
        /// </summary>
        public bool IsEditing { get; set; }

        /// <summary>
        /// Keeps in mind whether
        /// </summary>
        public bool IsDragging { get; set; }

        private void OnBeginEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            IsEditing = true;
            //in case we are in the middle of a drag/drop operation, cancel it...
            if (IsDragging) ResetDragDrop();
        }

        private void OnEndEdit(object sender, DataGridCellEditEndingEventArgs e)
        {
            IsEditing = false;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //exit if in edit mode
            if (IsEditing) return;

            //find the clicked row
            var row = UIHelpers.TryFindFromPoint<DataGridRow>((UIElement)sender,
            e.GetPosition(shareGrid));
            if (row == null) return;

            //set flag that indicates we're capturing mouse movements
            IsDragging = true;
            DraggedItem = (ShareConfiguration)row.Item;
        }

        /// <summary>
        /// Completes a drag/drop operation.
        /// </summary>
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!IsDragging || IsEditing)
            {
                return;
            }

            //get the target item
            ShareConfiguration targetItem = (ShareConfiguration)shareGrid.SelectedItem;

            if (targetItem == null || !ReferenceEquals(DraggedItem, targetItem))
            {
                //remove the source from the list
                ShareList.Remove(DraggedItem);

                //get target index
                var targetIndex = ShareList.IndexOf(targetItem);

                //move source at the target's location
                ShareList.Insert(targetIndex, DraggedItem);

                //select the dropped item
                shareGrid.SelectedItem = DraggedItem;
            }

            //reset
            ResetDragDrop();
        }
        /// <summary>
        /// Completes a drag/drop operation.
        /// </summary>
       

        /// <summary>
        /// Closes the popup and resets the
        /// grid to read-enabled mode.
        /// </summary>
        private void ResetDragDrop()
        {
            IsDragging = false;
            popup1.IsOpen = false;
            shareGrid.IsReadOnly = false;
        }


        /// <summary>
        /// Updates the popup's position in case of a drag/drop operation.
        /// </summary>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!IsDragging || e.LeftButton != MouseButtonState.Pressed) return;

            //display the popup if it hasn't been opened yet
            if (!popup1.IsOpen)
            {
                //switch to read-only mode
                shareGrid.IsReadOnly = true;

                //make sure the popup is visible
                popup1.IsOpen = true;
            }


            Size popupSize = new Size(popup1.ActualWidth, popup1.ActualHeight);
            popup1.PlacementRectangle = new Rect(e.GetPosition(this), popupSize);

            //make sure the row under the grid is being selected
            Point position = e.GetPosition(shareGrid);
            var row = UIHelpers.TryFindFromPoint<DataGridRow>(shareGrid, position);
            if (row != null) shareGrid.SelectedItem = row.Item;
        }

    }
}
