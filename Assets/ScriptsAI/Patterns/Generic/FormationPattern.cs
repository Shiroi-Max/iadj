using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationPattern : MonoBehaviour
{
    [SerializeField]
    protected int numberSlots;
    protected Dictionary<int, Location> locations;
    protected GridManager gridManager;

    public void Start()
    {

    }

    public void Update()
    {

    }

    public virtual Location GetDriftOffset(List<SlotAssignment> slotAssignments)
    {
        return null;
    }

    public virtual Location GetSlotLocation(int slotNumber)
    {
        return null;
    }

    public virtual bool SupportSlots(int slotCount)
    {
        return false;
    }

    public virtual int GetLeaderSlot()
    {
        return 0;
    }
}