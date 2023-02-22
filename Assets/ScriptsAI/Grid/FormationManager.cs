using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotAssignment
{
    public Agent character;
    public int slotNumber;
}

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

public class FormationManager : MonoBehaviour
{
    public FormationPattern pattern;
    private List<SlotAssignment> slotAssignments;
    private Location driftOffset;
    private Agent npcVirtualTemp;
    public Agent npcVirtual;

    public void Start()
    {
        slotAssignments = new List<SlotAssignment>();
    }

    public void Update()
    {
        if (slotAssignments.Count == 0) return;

        int slotNumber = pattern.GetLeaderSlot();

        SlotAssignment leaderSlot = null;
        foreach (SlotAssignment s in slotAssignments)
            if (s.slotNumber == slotNumber)
                leaderSlot = s;

        float[,] orientationMatrix = { { Mathf.Cos(leaderSlot.character.Orientation), -Mathf.Sin(leaderSlot.character.Orientation) }, { Mathf.Sin(leaderSlot.character.Orientation), Mathf.Cos(leaderSlot.character.Orientation) } };

        foreach (SlotAssignment s in slotAssignments)
        {
            if (s.Equals(leaderSlot)) continue;

            Location relativeLocation = pattern.GetSlotLocation(s.slotNumber);
            Location location = new Location();

            Vector3 orientationVector = new Vector3((relativeLocation.position.x * orientationMatrix[0, 0]) + (relativeLocation.position.x * orientationMatrix[1, 0]), 0, (relativeLocation.position.z * orientationMatrix[0, 1]) + (relativeLocation.position.z * orientationMatrix[1, 1]));
            location.position = orientationVector + leaderSlot.character.Position - driftOffset.position;

            location.orientation = leaderSlot.character.Orientation + relativeLocation.orientation - driftOffset.orientation;

            if (npcVirtualTemp == null)
                npcVirtualTemp = Instantiate(npcVirtual);

            npcVirtualTemp.Position = location.position;
            npcVirtualTemp.Orientation = location.orientation;

            s.character.gameObject.SendMessage("NewTarget", npcVirtualTemp);
        }
    }

    public void UpdateSlotAssignments()
    {
        for (int i = 0; i < slotAssignments.Count; i++)
            slotAssignments[i].slotNumber = i;

        driftOffset = pattern.GetDriftOffset(slotAssignments);
    }

    public bool AddCharacter(Agent character)
    {
        if (!pattern.SupportSlots(slotAssignments.Count + 1))
            return false;

        SlotAssignment slot = new SlotAssignment();
        slot.character = character;
        slotAssignments.Add(slot);

        UpdateSlotAssignments();

        return true;
    }

    public bool RemoveCharacter(Agent character)
    {
        SlotAssignment slot = null;
        foreach (SlotAssignment s in slotAssignments)
            if (s.character.Equals(character))
                slot = s;

        if (slot == null)
            return false;

        slotAssignments.Remove(slot);
        UpdateSlotAssignments();
        return true;
    }
}