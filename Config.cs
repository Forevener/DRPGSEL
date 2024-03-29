﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace DoomRPG
{
    public class Config
    {
        public string Name;

        // Basic
        public string fork = "WNC12k/DoomRPG-Rebalance";
        public string branch = "master";
        public string portPath = string.Empty;
        public string IWADPath = string.Empty;
        public string DRPGPath = string.Empty;
        public string modsPath = string.Empty;
        public string savePath = string.Empty;
        public string iwad = "doom2.wad";
        public string demo = string.Empty;
        public bool enableCheats = false;
        public bool enableLogging = false;
        public List<string> mods = new List<string>();
        public string customCommands = string.Empty;

        // Startup
        public int startupMode = 0;
        public int difficulty = 1;
        public string rlClass = "Marine";
        public int mapNumber = 1;

        // Multiplayer
        public bool multiplayer = false;
        public MultiplayerMode multiplayerMode = MultiplayerMode.Hosting;
        public ServerType serverType = ServerType.PeerToPeer;
        public int players = 2;
        public string hostname = string.Empty;
        public bool extraTics = false;
        public int duplicate = 1;

        // Gameplay
        public bool EnableDMFlags = false;
        public int DMFlags = 0;
        public bool EnableDMFlags2 = false;
        public int DMFlags2 = 0;

        // Warnings
        public bool wipeWarning = true;
        public Size windowSize = new Size(475, 536);

        public Config()
        {

        }

        public Config(string name)
        {
            Name = name;
        }

        public List<string> Save()
        {
            List<string> data = new List<string>();
            FieldInfo[] fields = GetType().GetFields();           

            foreach (FieldInfo field in fields)
            {
                // Array Types
                if (field.GetValue(this).GetType() == typeof(bool[]))
                {
                    bool[] bools = (bool[])field.GetValue(this);
                    string boolString = field.Name + "=";
                    for (int i = 0; i < bools.Length; i++)
                        boolString += bools[i] + ",";
                    data.Add(boolString.Substring(0, boolString.Length - 1));
                }
                // List types
                else if (field.GetValue(this).GetType() == typeof(List<string>))
                {
                    List<string> strings = (List<string>)field.GetValue(this);
                    string listString = field.Name + "=";
                    foreach (string s in strings)
                        listString += "{" + s + "};";
                    if (listString[listString.Length - 1] == ';')
                        listString = listString.Remove(listString.Length - 1);
                    data.Add(listString);
                }
                else if (field.GetValue(this).GetType() == typeof(Size))
                {
                    Size size = (Size)field.GetValue(this);
                    data.Add($"{field.Name}={size.Width};{size.Height}");
                }
                else // Basic Type
                    data.Add(field.Name + "=" + field.GetValue(this));
            }

            return data;
        }

        public void Load(List<string> data)
        {
            FieldInfo[] fields = GetType().GetFields();

            foreach (string option in data)
            {
                string[] s = option.Split('=');

                if (s.Length == 2)
                {
                    FieldInfo field = fields.FirstOrDefault(o => o.Name == s[0]);

                    if (field != null)
                    {
                        // Basic Types
                        if (field.GetValue(this).GetType() == typeof(bool))
                            field.SetValue(this, bool.Parse(s[1]));
                        if (field.GetValue(this).GetType() == typeof(int))
                            field.SetValue(this, int.Parse(s[1]));
                        if (field.GetValue(this).GetType() == typeof(float))
                            field.SetValue(this, float.Parse(s[1]));
                        if (field.GetValue(this).GetType() == typeof(string))
                            field.SetValue(this, s[1]);
                        
                        // String List
                        if (field.GetValue(this).GetType() == typeof(List<string>))
                        {
                            List<string> listStrings = new List<string>();
                            string[] entries = s[1].Split(';');
                            if (entries.Length > 0 && entries[0] != string.Empty)
                                foreach (string entry in entries)
                                    listStrings.Add(entry.Trim(new char[] { '{', '}' }));
                            field.SetValue(this, listStrings);
                        }

                        // Enums
                        if (field.GetValue(this).GetType() == typeof(MultiplayerMode))
                            for (int i = 0; i < Enum.GetNames(typeof(MultiplayerMode)).Length; i++)
                                if (Enum.GetNames(typeof(MultiplayerMode))[i].Contains(s[1]))
                                    field.SetValue(this, Enum.ToObject(typeof(MultiplayerMode), i));
                        if (field.GetValue(this).GetType() == typeof(ServerType))
                            for (int i = 0; i < Enum.GetNames(typeof(ServerType)).Length; i++)
                                if (Enum.GetNames(typeof(ServerType))[i].Contains(s[1]))
                                    field.SetValue(this, Enum.ToObject(typeof(ServerType), i));

                        // Structs
                        if (field.GetValue(this).GetType() == typeof(Size))
                        {
                            string[] entries = s[1].Split(';');
                            field.SetValue(this, new Size(int.Parse(entries[0]), int.Parse(entries[1])));
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
