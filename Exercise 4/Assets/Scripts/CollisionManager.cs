using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //list of sprites with spriteinfo class
    [SerializeField] List<SpriteInfo> sprites = new List<SpriteInfo>();//player should be the first index for simplicities sake

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // loop through list
    }

    bool AABBCollisionCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        bool collision = false;

        if(spriteA.max.x > 0)
        {
            collision = true;
        }

        return collision;
    }

    bool CircleCollision(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        //spriteA.transform.position = center of the object
        bool collision = false;

        if (spriteA.max.x > 0)
        {
            collision = true;
        }

        return collision;
    }
}
