using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //list of sprites with spriteinfo class
    [SerializeField] List<SpriteInfo> sprites = new List<SpriteInfo>();//player should be the first index for simplicities sake

    [SerializeField] bool aabbCol;


    // Start is called before the first frame update
    void Start()
    {
        aabbCol = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (aabbCol)
            {
                aabbCol = false;
            }
            else
            {
                aabbCol = true;
            }
        }
        */

        for(int i = 1; i < sprites.Count; i++)
        {
            if (aabbCol)
            {
                if (AABBCollisionCheck(sprites[0], sprites[i]))
                {
                    Debug.Log(sprites[0].spriteRenderer.color.ToString());
                    sprites[0].spriteRenderer.color = Color.red;
                    sprites[i].spriteRenderer.color = Color.red;
                }
                else
                {
                    // Set the color of both sprites to white if there's no collision
                    //sprites[0].spriteRenderer.color = Color.white;
                    sprites[i].spriteRenderer.color = Color.white;
                }
            }
            
            else
            {
                if (CircleCollision(sprites[0], sprites[i]))
                {
                    sprites[0].spriteRenderer.color = Color.red;
                    sprites[i].spriteRenderer.color = Color.red;
                }
                else
                {
                    // Set the color of both sprites to white if there's no collision
                    sprites[0].spriteRenderer.color = Color.white;
                    sprites[i].spriteRenderer.color = Color.white;
                }
            }
            
        }
    }

    bool AABBCollisionCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        bool collision = false;

        if((spriteB.min.x < spriteA.max.x) && (spriteB.max.x > spriteA.min.x) && (spriteB.max.y > spriteA.min.y) && (spriteB.min.y < spriteA.max.y))
        {
            collision = true;
        }

        return collision;
    }

    bool CircleCollision(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        //spriteA.transform.position = center of the object
        bool collision = false;

        float xDist = Mathf.Pow(Mathf.Abs(spriteA.transform.position.x - spriteB.transform.position.x), 2);
        float yDist = Mathf.Pow(Mathf.Abs(spriteA.transform.position.y - spriteB.transform.position.y), 2);

        float distance = Mathf.Sqrt(xDist + yDist);

        float minDist = spriteA.radius + spriteB.radius;

        if (distance < minDist)
        {
            collision = true;
        }

        return collision;
    }
}
