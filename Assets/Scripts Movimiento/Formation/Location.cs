using UnityEngine;

public class Location
{
    public Vector3 position;
    public float orientation;

    public Location()
    {
        position = new Vector3();
        orientation = 0;
    }

    public Location(Vector3 position, float orientation)
    {
        this.position = position;
        this.orientation = orientation;
    }
}
