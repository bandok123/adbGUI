using adbGUI.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adbGUI.Forms
{
    public partial class Bookmarks : Form
    {
        public Bookmarks()
        {
            InitializeComponent();

            BookmarksHelper.OnBookmarkChanged += RefreshBookmarksListView;
            RefreshBookmarksListView();
        }

        private void RefreshBookmarksListView()
        {
            bookmarksListView.BeginUpdate();

            bookmarksListView.Items.Clear();
            int count = BookmarksHelper.GetBookmarkCount();
            for (int i = 0; i < count; ++i)
            {
                var item = BookmarksHelper.GetBookmarkItem(i);

                ListViewItem listViewItem = new ListViewItem(item.Label);
                listViewItem.SubItems.Add(item.Command);
                bookmarksListView.Items.Add(listViewItem);
            }

            bookmarksListView.EndUpdate();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (bookmarksListView.SelectedItems == null ||
                bookmarksListView.SelectedItems.Count <= 0)
            {
                MessageBox.Show(
                    @"you must select item",
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var index = bookmarksListView.SelectedItems[0].Index;
            BookmarksHelper.DeleteBookmarkItem(index);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var label = labelTB.Text;
            var command = commandTB.Text;
            if (string.IsNullOrEmpty(label) || string.IsNullOrEmpty(command))
            {
                MessageBox.Show(
                    @"label and command must have values",
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            BookmarksHelper.AddBookmarkItem(label, command);
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            var command = commandTB.Text;
            if (string.IsNullOrEmpty(command))
            {
                MessageBox.Show(
                    @"command must have values",
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            HelperClass.Execute(command);
        }

        private void Bookmarks_Shown(object sender, EventArgs e)
        {

        }

        private void bookmarksListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                var label = e.Item.Text;
                var command = e.Item.SubItems[1].Text;
                labelTB.Text = label;
                commandTB.Text = command;
            }
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            if (bookmarksListView.SelectedItems == null ||
                bookmarksListView.SelectedItems.Count <= 0)
            {
                MessageBox.Show(
                    @"you must select item",
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var label = labelTB.Text;
            var command = commandTB.Text;
            if (string.IsNullOrEmpty(label) || string.IsNullOrEmpty(command))
            {
                MessageBox.Show(
                    @"label and command must have values",
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var index = bookmarksListView.SelectedItems[0].Index;
            BookmarksHelper.ModifyBoolmarkItem(index, label, command);
        }

        private void Bookmarks_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookmarksHelper.OnBookmarkChanged -= RefreshBookmarksListView;
        }
    }
}
