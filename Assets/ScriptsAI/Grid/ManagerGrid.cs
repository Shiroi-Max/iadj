using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{

}

public class ManagerGrid : MonoBehaviour
{
    public int rows;
    public int columns;
    public float size;
    public Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {

    }

    public Vector3 getPositionPlane(Vector3 posGrid)
    {
        int x = (int)((posGrid.x + origin.x) * size);
        int z = (int)((posGrid.z + origin.z) * size);
        return new Vector3(x + size / 2, 0, z + size / 2);
    }

    public Vector3 getPositionGrid(Vector3 posPlane)
    {
        int i = (int)((posPlane.x - origin.x) / size);
        int j = (int)((posPlane.z - origin.z) / size);
        return new Vector3(i, 0, j);
    }
}
