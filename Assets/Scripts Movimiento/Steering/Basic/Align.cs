using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Align : SteeringBehaviour
{
    [SerializeField] private float timeToTarget = .1f;

    void Start()
    {
        this.nameSteering = "Align";
    }

    public override Steering GetSteering(Agent agent)
    {
        Steering steer = new Steering();
        if (target == null) return steer;

        float rotation = target.Orientation - agent.Orientation;
        rotation = Bodi.MapToRange(rotation, new Range(-180, 360));

        float rotationSize = Mathf.Abs(rotation);
        if (rotationSize >= target.InteriorAngle)
        {
            float targetRotation;
            if (rotationSize > target.ExteriorAngle)
                targetRotation = agent.MaxRotation;
            else
                targetRotation = agent.MaxRotation * rotationSize / target.ExteriorAngle;

            targetRotation *= rotation / rotationSize;

            steer.angular = (targetRotation - agent.Rotation) / timeToTarget;
            float angularAcc = Mathf.Abs(steer.angular);

            if (angularAcc > agent.MaxAngularAcc)
                steer.angular = (steer.angular / angularAcc) * agent.MaxAngularAcc;
        }
        else if (Mathf.Abs(agent.Rotation) > .01)
            steer.angular = agent.Rotation * -1;

        return steer;
    }
}