using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    [SerializeField] Agent target;

    public float seekWeight = 1f, boundsWeight = 10f;


    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 seekForce = Vector3.zero;


        seekForce += Seek(target) * seekWeight;
        seekForce += StayInBounds() * boundsWeight;

        return seekForce;
    }

    
}
