using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField] float wanderTime = 1f;
    [SerializeField] float wanderRadius = 1f;


    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 wanderForce = Wander(wanderTime, wanderRadius);

        return wanderForce;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        Vector3 futurePosition = CalcFuturePosition(wanderTime);
        Gizmos.DrawWireSphere(futurePosition, wanderRadius);

        float randAngle = Random.Range(0f, Mathf.PI * 2f);

        Gizmos.color = Color.red;
        Vector3 wanderPoint = futurePosition;
        wanderPoint.x += Mathf.Cos(randAngle) * wanderRadius;
        wanderPoint.y += Mathf.Sin(randAngle) * wanderRadius;
        Gizmos.DrawLine(transform.position, wanderPoint);
    }
}
