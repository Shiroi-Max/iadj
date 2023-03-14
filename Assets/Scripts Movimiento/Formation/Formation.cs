using UnityEngine;

public class Formation : MonoBehaviour
{
    [SerializeField] private Pattern _pattern;
    [SerializeField] private Agent npcVirtual;

    public AgentNPC leader;
    public int slotNumber;
    private Agent npcVirtualTemp;
    
    public Pattern Pattern
    {
        get { return _pattern; }
    }

    public void Update()
    {
        if (leader == null || _pattern.GetLeaderSlot() == slotNumber || this.GetComponent<Brain>().Status != Status.Formation) return;

        _pattern.OriginPosition(leader.Position);

        float[,] orientationMatrix = { { Mathf.Cos(leader.Orientation), -Mathf.Sin(leader.Orientation) },
        { Mathf.Sin(leader.Orientation), Mathf.Cos(leader.Orientation) } };

        Location relativeLocation = _pattern.GetSlotLocation(slotNumber);
        Location location = new Location();

        Vector3 orientationVector = new Vector3((relativeLocation.position.x * orientationMatrix[0, 0]) +
        (relativeLocation.position.x * orientationMatrix[1, 0]), 0, (relativeLocation.position.z * orientationMatrix[0, 1]) +
        (relativeLocation.position.z * orientationMatrix[1, 1]));
        location.position = _pattern.GetPositionPlane(orientationVector);

        location.orientation = leader.Orientation + relativeLocation.orientation;

        if (npcVirtualTemp == null)
            npcVirtualTemp = Instantiate(npcVirtual);

        npcVirtualTemp.Position = location.position;
        npcVirtualTemp.Orientation = location.orientation;

        this.gameObject.SendMessage("NewTarget", npcVirtualTemp);
    }
}