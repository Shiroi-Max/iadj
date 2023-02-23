using UnityEngine;

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

public class Formation : MonoBehaviour
{
    [SerializeField]
    private FormationPattern _pattern;
    private AgentNPC _leader;
    private int _slotNumber;
    private Agent npcVirtualTemp;
    public Agent npcVirtual;

    public FormationPattern Pattern
    {
        get { return _pattern; }
    }

    public AgentNPC Leader
    {
        get { return _leader; }
        set { _leader = value; }
    }

    public int SlotNumber
    {
        get { return _slotNumber; }
        set { _slotNumber = value; }
    }

    public void Update()
    {
        if (_leader == null && _pattern.GetLeaderSlot() == _slotNumber) return;

        float[,] orientationMatrix = { { Mathf.Cos(_leader.Orientation), -Mathf.Sin(_leader.Orientation) },
        { Mathf.Sin(_leader.Orientation), Mathf.Cos(_leader.Orientation) } };

        Location relativeLocation = _pattern.GetSlotLocation(_slotNumber);
        Location location = new Location();

        Vector3 orientationVector = new Vector3((relativeLocation.position.x * orientationMatrix[0, 0]) +
        (relativeLocation.position.x * orientationMatrix[1, 0]), 0, (relativeLocation.position.z * orientationMatrix[0, 1]) +
        (relativeLocation.position.z * orientationMatrix[1, 1]));
        location.position = orientationVector + _leader.Position;

        location.orientation = _leader.Orientation + relativeLocation.orientation;

        if (npcVirtualTemp == null)
            npcVirtualTemp = Instantiate(npcVirtual);

        npcVirtualTemp.Position = location.position;
        npcVirtualTemp.Orientation = location.orientation;

        this.gameObject.SendMessage("NewTarget", npcVirtualTemp);
    }
}