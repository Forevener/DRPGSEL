using System;
using System.IO;
using System.Runtime.InteropServices;
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

        public static string GetRelativePath(string path1, string path2, bool quotes = false)
        {
            // From .NET Core 3.1
            if (string.IsNullOrEmpty(path1))
            {
                throw new ArgumentException("Path must have a value", nameof(path1));
            }

            if (string.IsNullOrEmpty(path2))
            {
                throw new ArgumentException("Path must have a value", nameof(path2));
            }

            StringComparison compare;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                compare = StringComparison.OrdinalIgnoreCase;
                // check if paths are on the same volume
                if (!string.Equals(Path.GetPathRoot(path1), Path.GetPathRoot(path2), compare))
                {
                    // on different volumes, "relative" path is just path2
                    return path2;
                }
            }
            else
            {
                compare = StringComparison.Ordinal;
            }

            var index = 0;
            var path1Segments = path1.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var path2Segments = path2.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            // if path1 does not end with / it is assumed the end is not a directory
            // we will assume that is isn't a directory by ignoring the last split
            var len1 = path1Segments.Length - 1;
            var len2 = path2Segments.Length;

            // find largest common absolute path between both paths
            var min = Math.Min(len1, len2);
            while (min > index)
            {
                if (!string.Equals(path1Segments[index], path2Segments[index], compare))
                {
                    break;
                }
                // Handle scenarios where folder and file have same name (only if os supports same name for file and directory)
                // e.g. /file/name /file/name/app
                else if ((len1 == index && len2 > index + 1) || (len1 > index && len2 == index + 1))
                {
                    break;
                }
                ++index;
            }

            var path = "";

            // check if path2 ends with a non-directory separator and if path1 has the same non-directory at the end
            if (len1 + 1 == len2 && !string.IsNullOrEmpty(path1Segments[index]) &&
                string.Equals(path1Segments[index], path2Segments[index], compare))
            {
                return path;
            }

            for (var i = index; len1 > i; ++i)
            {
                path += ".." + Path.DirectorySeparatorChar;
            }

            for (var i = index; len2 - 1 > i; ++i)
            {
                path += path2Segments[i] + Path.DirectorySeparatorChar;
            }
            // if path2 doesn't end with an empty string it means it ended with a non-directory name, so we add it back
            if (!string.IsNullOrEmpty(path2Segments[len2 - 1]))
            {
                path += path2Segments[len2 - 1];
            }

            return quotes && path.Contains(" ") ? $"\"{path.TrimStart('\\')}\"" : path.TrimStart('\\');
        }
    }
}
