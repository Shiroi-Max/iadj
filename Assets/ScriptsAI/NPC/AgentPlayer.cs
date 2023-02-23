using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentPlayer : Agent
{
    public virtual void Update()
    {
        Vector3 Velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Velocity *= MaxSpeed;
        this.Velocity = Velocity;
        Vector3 translation = Velocity * Time.deltaTime;
        transform.Translate(translation, Space.World);

        transform.LookAt(transform.position + Velocity);
        Orientation = transform.rotation.eulerAngles.y;
    }

}
