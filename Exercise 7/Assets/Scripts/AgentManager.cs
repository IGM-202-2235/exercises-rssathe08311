using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    [SerializeField]
    Agent agentPrefab;

    public List<Agent> agents;

    [SerializeField] int spawnCount = 100;

    Vector2 screenSize = Vector2.zero;

    public Vector2 ScreenSize
    {
        get { return screenSize; }
    }

    // Start is called before the first frame update
    void Start()
    {
        screenSize.y = Camera.main.orthographicSize;
        screenSize.x = screenSize.y * Camera.main.aspect;

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            Agent newAgent = Instantiate(agentPrefab, PickRandomPosition(), Quaternion.identity);

            newAgent.agentManager = this;

            agents.Add(newAgent);
        }
       
    }

    Vector2 PickRandomPosition()
    {
        Vector2 randPos = Vector2.zero;

        randPos.x = Random.Range(-screenSize.x, screenSize.x);
        randPos.y = Random.Range(-screenSize.y, screenSize.y);

        return randPos;
    }
}
