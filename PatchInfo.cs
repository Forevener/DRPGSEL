using System;
using System.Collections.Generic;
using System.IO;

namespace DoomRPG
{
    public class PatchInfo
    {
        public string Name { get; private set; }
        public List<string> Conflicts { get; } = new List<string>();
        public List<string> Requires { get; } = new List<string>();
        public List<string> ReqiredMods { get; } = new List<string>();
        public string Path { get; private set; }
        public bool Enabled { get; set; }

        public static PatchInfo ReadPatch(string path)
        {
            PatchInfo info = new PatchInfo
            {
                Path = System.IO.Path.GetDirectoryName(path)
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
                            info.Name = s[1];

                        // Conflicts
                        else if (s[0].ToLower() == "conflicts")
                            info.Conflicts.Add(s[1]);

                        // Requires
                        else if (s[0].ToLower() == "requires")
                            info.Requires.Add(s[1]);

                        // Requires
                        else if (s[0].ToLower() == "mods")
                            info.ReqiredMods.Add(s[1]);
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

            foreach (PatchInfo patch in patches.FindAll(p => p.Enabled))
            {
                foreach (string req in patch.Requires)
                {
                    if (!patches.Find(p => p.Name == req)?.Enabled ?? false)
                    {
                        error += $"Patch {patch.Name} requires the patch {req}\n";
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
                foreach (string req in patch.ReqiredMods)
                {
                    if (!mods.Exists(m => m.Contains(req)))
                    {
                        error += $"Patch {patch.Name} requires the file {req}\n";
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

            foreach (PatchInfo patch in patches.FindAll(p => p.Enabled))
            {
                foreach (string conf in patch.Conflicts)
                {
                    if (patches.Find(p => p.Name == conf)?.Enabled ?? false)
                    {
                        error += $"Patch {patch.Name} conflicts with patch {conf}\n";
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
            return Name;
        }
    }
}
