using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject creaturePrefab;

    [SerializeField]
    Vector3 spawnLoc1 = new Vector3(0f, 0f, 0f);
    [SerializeField]
    Vector3 spawnLoc2 = new Vector3(2f, 2f, 0f);
    [SerializeField]
    Vector3 spawnLoc3 = new Vector3(-2f, -2f, 0f);



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(creaturePrefab, spawnLoc1, Quaternion.identity);
        Instantiate(creaturePrefab, spawnLoc2, Quaternion.identity);
        Instantiate(creaturePrefab, spawnLoc3, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
