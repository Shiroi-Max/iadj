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
}