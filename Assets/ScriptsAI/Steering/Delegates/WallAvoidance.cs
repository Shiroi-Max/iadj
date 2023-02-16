using UnityEngine;

public class WallAvoidance : SteeringBehaviour
{
    public Seek seek;
    private Agent npcVirtualTemp;
    public Agent npcVirtual;
    public float avoidDistance;
    public float maxDistance;
    public int nRays;

    void Start()
    {
        this.nameSteering = "WallAvoidance";
    }

    public override Steering GetSteering(Agent agent)
    {
        float angle = 60 / nRays;
        float orientationRay = agent.Orientation;

        if ((nRays % 2) == 0)
            orientationRay += angle;

        float distanceMin = 999999;
        Vector3 pointMin = new Vector3();
        Vector3 normalMin = new Vector3();
        for (int i = 0; i < nRays; i++)
        {
            Ray ray = new Ray(agent.Position, Bodi.OrientationToVector(orientationRay));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                RayTraceScreen.draw(ray, hit);
                if (hit.distance < distanceMin)
                {
                    distanceMin = hit.distance;
                    pointMin = hit.point;
                    normalMin = hit.normal;
                }
            }

            if ((i % 2) == 0)
                orientationRay -= angle * (i + 1);
            else
                orientationRay += angle * (i + 1);
        }

        if (distanceMin == 999999)
            return new Steering();

        if (npcVirtualTemp == null)
            npcVirtualTemp = Instantiate(npcVirtual);
        npcVirtualTemp.Position = pointMin + normalMin * avoidDistance;
        seek.target = npcVirtualTemp;

        return seek.GetSteering(agent);
    }
}