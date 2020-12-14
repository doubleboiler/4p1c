using UnityEngine;

public class Player
{
    public byte Id;

    public string NickName;

    public Color Color;

    public Cell CurrentCell;
    public Cell OriginalCell;

    public Player(byte id, string name, Color color)
    {
        Id = id;
        NickName = name;
        Color = color;
    }
}
