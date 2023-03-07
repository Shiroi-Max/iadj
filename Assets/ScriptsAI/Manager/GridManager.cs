using UnityEngine;

public class GridManager
{
    public int rows;
    public int columns;
    public float size;
    public Vector3 origin;
    public Vector3 leaderPosition;

    public Vector3 GetPositionPlane(Vector3 posGrid)
    {
        float x = posGrid.x * size + origin.x;
        float z = posGrid.z * size + origin.z;
        return new Vector3(x + size / 2, 0, z + size / 2);
    }

    public Vector3 GetPositionGrid(Vector3 posPlane)
    {
        int i = (int)((posPlane.x - origin.x) / size);
        int j = (int)((posPlane.z - origin.z) / size);
        return new Vector3(i, 0, j);
    }

    public Vector3 GetRelativePosition(Vector3 posGrid)
    {
        return posGrid - leaderPosition;
    }
}
