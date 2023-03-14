using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int rows;
    [SerializeField] private int columns;

    public float size;
    public Vector3 origin;
    public Vector3 leaderPosition;
    private Grid[,] grids;

    public GridManager(int rows, int columns, float size, Vector3 origin)
    {
        this.rows = rows;
        this.columns = columns;
        this.size = size;
        this.origin = origin;
        grids = new Grid[rows, columns];
    }
    
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

    public Grid GetGrid(Vector3 posGrid)
    {
        return grids[(int)posGrid.x,(int)posGrid.z];
    }

    public void InitializeH(Vector3 posGrid, Distance dist)
    {
        int x = (int) posGrid.x;
        int z = (int) posGrid.z;
        for (int i = 0; i < rows; i++)
            for (int j = 0; i < columns; j++)
                switch (dist)
                {
                    case Distance.Manhattan:
                        grids[i,j].h = Mathf.Abs(x - i) + Mathf.Abs(z - j);
                        break;
                    case Distance.Chebyshev:
                        grids[i,j].h = Mathf.Max(Mathf.Abs(x - i), Mathf.Abs(z - j));
                        break;
                    case Distance.Euclidea:
                        grids[i,j].h = (int)(Mathf.Sqrt(Mathf.Pow(x - i, 2) + Mathf.Pow(z - j, 2)));
                        break;
                }
    }
}
