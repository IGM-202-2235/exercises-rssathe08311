using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] Agent seeker;
    [SerializeField] Agent fleer;

    public void Update()
    {
        if (CircleCollision(seeker, fleer))
        {
            Debug.Log("collision");
            float heightStd = (Camera.main.orthographicSize * 2f) / 8f;
            float widthStd = heightStd * Camera.main.aspect;
            fleer.physicsObject.position = new Vector3(Gaussian(0, widthStd), Gaussian(0, heightStd));
        }
    }

    bool CircleCollision(Agent seeker, Agent fleer)
    {
        //spriteA.transform.position = center of the object
        bool collision = false;

        float xDist = Mathf.Pow(Mathf.Abs(seeker.transform.position.x - fleer.transform.position.x), 2);
        float yDist = Mathf.Pow(Mathf.Abs(seeker.transform.position.y - fleer.transform.position.y), 2);

        float distance = Mathf.Sqrt(xDist + yDist);

        float minDist = seeker.physicsObject.radius + fleer.physicsObject.radius;

        if (distance < minDist)
        {
            collision = true;
        }

        return collision;
    }


    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue = Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }
}
