using System;

namespace DoomRPG
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
        Nightmare,
        Hell
    }

    public enum DRLADifficulty
    {
        VeryEasy,
        Easy,
        Moderate,
        Standard,
        Adaptive,
        Nightmare,
        Technophobia,
        Armageddon       
    }

    

    public enum MultiplayerMode
    {
        Hosting,
        Joining
    }

    public enum ServerType
    {
        PeerToPeer,
        PacketServer
    }

    struct DMFlag
    {
        public int Key { get; }
        public string Name { get; }
        public bool DefaultState { get; }
        public string Description { get; }

        public DMFlag(int key, string name, bool state, string desc)
        {
            Key = key;
            Name = name;
            DefaultState = state;
            Description = desc;
        }
    }
}
