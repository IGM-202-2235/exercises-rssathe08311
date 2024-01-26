using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Demo : MonoBehaviour
{
    public string name;

    [SerializeField]
    int favNumber = 34;

    [SerializeField]
    MeshRenderer meshRenderer;

    [SerializeField]
    GameObject thing;

    // Start is called before the first frame update
    //used for initialization, works like setup
    void Start()
    {
        //Debug.Log("hello there!");

        //meshRenderer.materials = null;

        for(int i = 0; i < 10; i++)
        {
            Instantiate(thing);
        }
    }

    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hey!");
        Debug.Log(favNumber);
    }
}
