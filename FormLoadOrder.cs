using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoomRPG
{
    public partial class FormLoadOrder : Form
    {
        public List<string> LoadOrder;
        public FormLoadOrder(List<string> mods)
        {
            InitializeComponent();
            listViewLoadOrder.MouseDown += ListViewLoadOrder_MouseDown;
            listViewLoadOrder.DragOver += ListViewLoadOrder_DragOver;
            listViewLoadOrder.DragDrop += ListViewLoadOrder_DragDrop;
            // REFACTORING : TRY BINDING ITEMS
            foreach (string s in mods)
                listViewLoadOrder.Items.Add(s);
            listViewLoadOrder.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void ListViewLoadOrder_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(typeof(ListViewItem[])) as ListViewItem[];
            Point p = listViewLoadOrder.PointToClient(new Point(e.X, e.Y));
            ListViewItem target = listViewLoadOrder.GetItemAt(p.X, p.Y);

            for (int i = 0; i < data.Length; i++)
            {
                var item = data[i];
                listViewLoadOrder.Items.Remove(item);
                listViewLoadOrder.Items.Insert(target?.Index ?? listViewLoadOrder.Items.Count, item);
            }
        }

        private void ListViewLoadOrder_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ListViewLoadOrder_MouseDown(object sender, MouseEventArgs e)
        {
            var target = listViewLoadOrder.GetItemAt(e.Location.X, e.Location.Y);
            if (listViewLoadOrder.SelectedItems.Count != 0 && target != null && listViewLoadOrder.SelectedItems.Contains(target))
                listViewLoadOrder.DoDragDrop(listViewLoadOrder.SelectedItems.Cast<ListViewItem>().ToArray(), DragDropEffects.Move);
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            LoadOrder = new List<string>(listViewLoadOrder.Items.Count);
            foreach (ListViewItem item in listViewLoadOrder.Items)
                LoadOrder.Add(item.Text);
        }
    }
}
