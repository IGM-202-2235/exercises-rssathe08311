using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionManager : MonoBehaviour
{
    //list of sprites with spriteinfo class
    [SerializeField] List<SpriteInfo> sprites = new List<SpriteInfo>();//player should be the first index for simplicities sake

    [SerializeField] bool aabbCol;

    [SerializeField] TextMesh instruction;


    // Start is called before the first frame update
    void Start()
    {
        aabbCol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (aabbCol)
            {
                aabbCol = false;
                instruction.text = "Collision Mode: Circle Collision \nClick to change collision mode";
                
            }
            else
            {
                aabbCol = true;
                instruction.text = "Collision Mode: AABB Collision \nClick to change collision mode";
            }
        }

        for(int i = 0; i < sprites.Count; i++)
        {
            sprites[i].spriteRenderer.color = Color.white;
        }

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
            }
            
            else
            {
                if (CircleCollision(sprites[0], sprites[i]))
                {
                    sprites[0].spriteRenderer.color = Color.red;
                    sprites[i].spriteRenderer.color = Color.red;
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
