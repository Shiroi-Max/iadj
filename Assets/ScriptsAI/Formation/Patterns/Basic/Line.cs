using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : FormationPattern
{
    public void Start()
    {
        _namePattern = "Line";
        gridManager = new GridManager(1, numberSlots, 2, Vector3.zero);
        locations = new Dictionary<int, Location>();
        for (int i = 0; i < 3; i++)
            locations.Add(i, new Location(new Vector3(0, 0, i), 0));
        gridManager.leaderPosition = locations[0].position;
    }

    public override Location GetSlotLocation(int slotNumber)
    {
        return locations[slotNumber];
    }
}