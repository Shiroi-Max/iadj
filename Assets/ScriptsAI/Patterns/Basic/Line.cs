using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : FormationPattern
{
    public void Start()
    {
        numberSlots = 3;
        locations = new Dictionary<int, Location>();
        for (int i = 0; i < 3; i++)
            locations.Add(i, new Location(new Vector3(0, 0, i), 90));
    }

    public override Location GetDriftOffset(List<SlotAssignment> slotAssignments)
    {
        return new Location();
    }

    public override Location GetSlotLocation(int slotNumber)
    {
        return locations[slotNumber];
    }

    public override bool SupportSlots(int slotCount)
    {
        return slotCount <= numberSlots;
    }

    public override int GetLeaderSlot()
    {
        return 0;
    }
}