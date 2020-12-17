using UnityEngine;

public class GamePlayer
{
    public byte Id;

    public string NickName;

    public Color Color;

    public GamePlayer(byte id, string name, Color color)
    {
        Id = id;
        NickName = name;
        Color = color;
    }
}
