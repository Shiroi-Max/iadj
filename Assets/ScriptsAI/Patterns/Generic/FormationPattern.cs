using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationPattern : MonoBehaviour
{
    protected string _namePattern;
    [SerializeField]
    protected int numberSlots;
    protected Dictionary<int, Location> locations;
    protected GridManager gridManager;

    public string NamePattern
    {
        get { return _namePattern; }
        set { _namePattern = value; }
    }

    public virtual Location GetSlotLocation(int slotNumber)
    {
        return null;
    }

    public bool SupportSlots(int slotCount)
    {
        return slotCount <= numberSlots;
    }

    public int GetLeaderSlot()
    {
        return 0;
    }

    public Vector3 GetPositionPlane(Vector3 posGrid)
    {
        return gridManager.GetPositionPlane(posGrid);
    }

    public Vector3 GetPositionGrid(Vector3 posPlane)
    {
        return gridManager.GetPositionGrid(posPlane);
    }

    public void OriginPosition(Vector3 posPlane)
    {
        // gridManager.origin.x = posPlane.x - gridManager.size / 2;
        // gridManager.origin.z = posPlane.z - gridManager.size / 2;
        gridManager.origin.x = posPlane.x;
        gridManager.origin.z = posPlane.z;
    }
}