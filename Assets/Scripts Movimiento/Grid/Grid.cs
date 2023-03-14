using UnityEngine;

public enum Terrain
{
    Default,
    Forest
}

public class Grid
{
    public int h;
    public Terrain terrain = Terrain.Default;
}
