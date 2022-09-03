﻿using System;
using System.Windows.Forms;

namespace DoomRPG
{
    public static class Utils
    {
        public static void ShowError(Exception e)
        {
            MessageBox.Show(e.Message + "\n\n" + e.StackTrace + "\n\n" + e.InnerException, "An error has occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(string text, string caption = "Error")
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string RelativePath(string path, string root)
        {
            string result = "\"" + new Uri(root).MakeRelativeUri(new Uri(path)).ToString().Replace("/", "\\") + "\"";
            return result.Replace("%20", " ");
        }
    }
}
