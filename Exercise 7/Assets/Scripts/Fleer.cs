using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    [SerializeField] Agent target;

    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 fleeForce = Flee(target);

        return fleeForce;
    }
}
