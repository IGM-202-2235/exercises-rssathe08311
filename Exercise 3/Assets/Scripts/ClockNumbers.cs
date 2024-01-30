using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{

    [SerializeField]
    public TextMesh numberPrefab;
    TextMesh[] prefabArr = new TextMesh[12];

    [SerializeField] float radius = 1;
    private float startPos = Mathf.PI / 3; //Makes the clock start at the position 1 would be at 

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            prefabArr[i] = Instantiate(numberPrefab, new Vector3(Mathf.Cos(startPos)*radius, Mathf.Sin(startPos) * radius, 0), Quaternion.identity);
            startPos -= Mathf.PI / 6;

        }

        for (int i = 1; i <= 12; i++)
        {
            prefabArr[i - 1].text = i.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
