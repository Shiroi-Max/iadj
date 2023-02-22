using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : FormationPattern
{
    public void Start()
    {
        gridManager = new GridManager();
        gridManager.rows = 1;
        gridManager.columns = numberSlots;
        gridManager.size = 2;
        locations = new Dictionary<int, Location>();
        for (int i = 0; i < 3; i++)
            locations.Add(i, new Location(new Vector3(0, 0, i), 0));
        gridManager.leaderPosition = locations[0].position;
    }

    public void Update()
    {

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