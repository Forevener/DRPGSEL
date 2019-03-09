using System;

namespace DoomRPG
{
    public enum IWAD
    {
        Doom1,
        Doom2,
        Plutonia,
        TNT
    }

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
        Nightmare,
        Hell,
        Armegeddon
    }

    public enum DRLAClass
    {
        Marine,
        Scout,
        Technician,
        Renegade,
        Demolitionist
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
