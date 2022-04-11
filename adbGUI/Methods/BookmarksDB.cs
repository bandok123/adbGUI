using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adbGUI.Methods
{
    public static class BookmarksHelper
    {
        private static string s_dataPath = Path.Combine(Application.LocalUserAppDataPath, "bookmarks.db");
        private static BookmarksDB s_db;

        public static event Action OnBookmarkChanged;

        static BookmarksHelper()
        {
            s_db = new BookmarksDB();
            s_db.Load(s_dataPath);
        }

        public static int GetBookmarkCount()
        {
            return s_db.Items.Count;
        }

        public static BookmarksItem GetBookmarkItem(int i)
        {
            return s_db.Items[i];
        }

        public static void ModifyBoolmarkItem(int i, string label, string command)
        {
            if (string.IsNullOrEmpty(label) || string.IsNullOrEmpty(command))
                return;
            var item = s_db.Items[i];
            item.Label = label;
            item.Command = command;

            OnBookmarkChanged?.Invoke();
        }

        public static void DeleteBookmarkItem(int i)
        {
            if (i < 0 || i >= s_db.Items.Count)
                return;

            s_db.Items.RemoveAt(i);

            OnBookmarkChanged?.Invoke();
        }

        public static void AddBookmarkItem(string label, string command)
        {
            if (string.IsNullOrEmpty(label) || string.IsNullOrEmpty(command))
                return;

            s_db.Items.Add(new BookmarksItem() { Label = label, Command = command });

            Flush();

            OnBookmarkChanged?.Invoke();
        }
        
        public static void Flush()
        {
            s_db.Save(s_dataPath);
        }
    }

    public class BookmarksDB
    {
        private const string c_split_marker = "|*|";

        public List<BookmarksItem> Items;

        public BookmarksDB()
        {
            Items = new List<BookmarksItem>();
        }

        public void Load(string filePath)
        {
            if (File.Exists(filePath) == false)
                return;

            Items.Clear();
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; ++i)
            {
                var line = lines[i];
                var item = Parse(line);
                if (item != null)
                    Items.Add(item);
            }
        }

        private BookmarksItem Parse(string content)
        {
            if (string.IsNullOrEmpty(content))
                return null;

            var array = content.Split(new string[] { c_split_marker }, StringSplitOptions.RemoveEmptyEntries);
            if (array == null || array.Length != 2)
                return null;

            BookmarksItem item = new BookmarksItem();
            item.Label = array[0];
            item.Command = array[1];
            return item;
        }

        public void Save(string filePath)
        {
            if (Items == null || Items.Count <= 0)
                return;

            StringBuilder strBuilder = new StringBuilder();
            foreach (var item in Items)
            {
                strBuilder.AppendLine($"{item.Label}{c_split_marker}{item.Command}");
            }
            File.WriteAllText(filePath, strBuilder.ToString());
        }
    }

    public class BookmarksItem
    {
        public string Label;
        public string Command;
    }
}
