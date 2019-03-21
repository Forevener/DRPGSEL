using System;
using System.Collections.Generic;
using System.IO;

namespace DoomRPG
{
    public class PatchInfo
    {
        string name;
        public string Name
        {
            get { return name; }
        }

        private List<string> conflicts = new List<string>();
        public List<string> Conflicts
        {
            get { return conflicts; }
        }

        private List<string> requires = new List<string>();
        public List<string> Requires
        {
            get { return requires; }
        }

        private List<string> reqiredMods = new List<string>();
        public List<string> ReqiredMods
        {
            get { return reqiredMods; }
        }

        private string path;
        public string Path
        {
            get { return path; }
        }

        private bool enabled;
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public static PatchInfo ReadPatch(string path)
        {
            PatchInfo info = new PatchInfo
            {
                path = System.IO.Path.GetDirectoryName(path)
            };

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] s = line.Split('=');

                    if (s.Length == 2)
                    {
                        // Name
                        if (s[0].ToLower() == "name")
                            info.name = s[1];

                        // Conflicts
                        else if (s[0].ToLower() == "conflicts")
                            info.conflicts.Add(s[1]);

                        // Requires
                        else if (s[0].ToLower() == "requires")
                            info.requires.Add(s[1]);

                        // Requires
                        else if (s[0].ToLower() == "mods")
                            info.reqiredMods.Add(s[1]);
                    }
                }
            }
            else
            {
                Utils.ShowError("Invalid Patch path\n\n" + path);
                return null;
            }

            return info;
        }

        public static bool CheckForRequirements(List<PatchInfo> patches)
        {
            string error = string.Empty;
            bool hasError = false;

            foreach (PatchInfo patch in patches.FindAll(p => p.enabled))
            {
                foreach (string req in patch.requires)
                {
                    if (!patches.Find(p => p.name == req)?.enabled ?? false)
                    {
                        error += $"Patch {patch.name} requires the patch {req}\n";
                        hasError = true;
                    }
                }
            }

            if (hasError)
            {
                Utils.ShowError(error.TrimEnd('\n'), "Patch Conflict");
                return false;
            }
            else
                return true;
        }

        public static bool CheckForMods(List<PatchInfo> patches, List<string> mods)
        {
            string error = string.Empty;
            bool hasError = false;

            foreach (PatchInfo patch in patches.FindAll(p => p.Enabled))
            {
                foreach (string mod in patch.reqiredMods)
                {
                    if (!mods.Exists(m => m.Contains(mod)))
                    {
                        error += $"Patch {patch.name} requires the file {mod}\n";
                        hasError = true;
                    }
                }
            }

            if (hasError)
            {
                Utils.ShowError(error.TrimEnd('\n'), "Mods missing");
                return false;
            }
            else
                return true;
        }

        public static bool CheckForConflicts(List<PatchInfo> patches)
        {
            string error = string.Empty;
            bool hasError = false;

            foreach (PatchInfo patch in patches.FindAll(p => p.enabled))
            {
                foreach (string conf in patch.conflicts)
                {
                    if (patches.Find(p => p.name == conf)?.enabled ?? false)
                    {
                        error += $"Patch {patch.name} conflicts with patch {conf}\n";
                        hasError = true;
                    }
                }
            }

            if (hasError)
            {
                Utils.ShowError(error.TrimEnd('\n'), "Patch Conflict");
                return false;
            }
            else
                return true;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
