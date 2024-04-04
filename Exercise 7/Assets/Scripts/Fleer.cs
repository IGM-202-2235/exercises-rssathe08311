using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    [SerializeField] Agent target;

    public float fleeWeight = 1f, boundsWeight = 10f;

    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 fleeForce = Vector3.zero;


        fleeForce += Flee(target) * fleeWeight;
        fleeForce += StayInBounds() * boundsWeight;

        return fleeForce;
    }
}
