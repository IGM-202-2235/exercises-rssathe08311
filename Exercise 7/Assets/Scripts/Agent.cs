using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Agent : MonoBehaviour
{

    [SerializeField] public PhysicsObject physicsObject;
    float randAngle;


    protected Vector3 totalForce = Vector3.zero;
    float maxForce = 5f;

    public AgentManager agentManager;

    // Start is called before the first frame update
    void Start()
    {
        randAngle = Random.Range(0f, Mathf.PI * 2f);
    }

    // Update is called once per frame
    void Update()
    {
        totalForce += CalculateSteeringForces();

        totalForce = Vector3.ClampMagnitude(totalForce, maxForce);

        physicsObject.ApplyForce(totalForce);

        totalForce = Vector3.zero;

    }

    protected abstract Vector3 CalculateSteeringForces();

    public Vector3 Seek(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = targetPos - transform.position;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * physicsObject.maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - physicsObject.velocity;

        // Return seek steering force
        return seekingForce;

    }

    public Vector3 Seek(Agent target)
    {
        return Seek(target.transform.position);
    }

    
    public Vector3 Flee(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity =  transform.position - targetPos;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * physicsObject.maxSpeed;

        // Calculate seek steering force
        Vector3 fleeingForce = desiredVelocity - physicsObject.velocity;

        // Return seek steering force
        return fleeingForce;
    }

    public Vector3 Flee(Agent target)
    {
        return Flee(target.transform.position);
    }

    //the only difference between evade and flee is target.calcFuturePosition * time
    public Vector3 Evade(Agent target)
    {
        return Flee(target.CalcFuturePosition(5f));
    }

    public Vector3 CalcFuturePosition(float futureTime)
    {
        return transform.position + (physicsObject.Direction * futureTime);
    }

    public Vector3 Wander(float futureTime, float circleRadius, float range)
    {
        Vector3 futurePosition = CalcFuturePosition(futureTime);

        float rad = range * Mathf.Deg2Rad;

        randAngle += Random.Range((rad * -1), rad);

        Vector3 wanderPoint = futurePosition;

        wanderPoint.x += Mathf.Cos(randAngle) * circleRadius;
        wanderPoint.y += Mathf.Sin(randAngle) * circleRadius;
        


        return Seek(wanderPoint);
    }

    public Vector3 StayInBounds()
    {
        Vector3 steeringForce = Vector3.zero;

        Debug.Log((CheckIfInBounds(transform.position)));
        //Do stuff
        if(!CheckIfInBounds(transform.position))
        {
            steeringForce = Seek(Vector3.zero);
        }

        return steeringForce;
    }

    protected bool CheckIfInBounds(Vector3 position)
    {
        float totalCamHeight = (Camera.main.orthographicSize * 2f) / 2;
        float totalCamWidth = (totalCamHeight * Camera.main.aspect);

        if (position.y > totalCamHeight || (position.y < (totalCamHeight * -1)))
        {
            return false;
        }
        if (position.x > totalCamWidth || (position.x < (totalCamWidth * -1)))
        {
            return false;
        }
        
        return true;
    }

    public Vector3 Seperate()
    {
        return Vector3.zero;
    }

    //alignment - seek the average location of the flock, dont use seek or flee instead desired velocity - current velocity like those two functions 
}
