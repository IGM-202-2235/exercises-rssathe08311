using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum to refer to the different types of animal sprites
public enum AnimalTypes
{
    Elephant,
    Turtle,
    Snail,
    Octopus,
    Kangaroo
}

public class SpawnManager : Singleton<SpawnManager>
{
    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    public SpriteRenderer animalPrefab;//reference to the animal prefab

    public List<Sprite> animalSprites;//list of animal sprites to be populated in the inspector

    public int animalCount;//variable to dictate how many animals to spawn

    List<SpriteRenderer> spawnedAnimals = new List<SpriteRenderer>();//list of animals displaying 

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

    public void Spawn()
    {
        animalCount = Random.Range(1, 200);

        //clears the old list and old animals
        CleanUp();

        //spawns animals
        for (int i = 0; i < animalCount; i++)
        {
            SpawnAnimal(PickRandomCreature());
        }
    }

    public void SpawnAnimal(AnimalTypes type)
    {
        SpriteRenderer newAnimal = Instantiate(animalPrefab);

        //cast the animalType to an int 
        newAnimal.sprite = animalSprites[(int)type];

        //color it 
        newAnimal.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);

        //set its location
        float heightStd = (Camera.main.orthographicSize * 2f) / 8f;
        float widthStd = heightStd * Camera.main.aspect;
        newAnimal.transform.position = new Vector3(Gaussian(0, widthStd), Gaussian(0, heightStd));

        spawnedAnimals.Add(newAnimal);
    }

    //clears list and deletes objects from list and canvas
    public void CleanUp()
    {
        foreach(SpriteRenderer animal in spawnedAnimals)
        {
            Destroy(animal.gameObject);
            
        }

        spawnedAnimals.Clear();
    }

    //method to calculate a Gaussian Distribution 
    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue = Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *  Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }


    //method to pick creatures based upon probablilites stated in assignment
    AnimalTypes PickRandomCreature()
    {
        float randVal = Random.Range(0f, 1f);

        if(randVal < .25f)
        {
            return AnimalTypes.Elephant;
        }
        else if(randVal < .45f)
        {
            return AnimalTypes.Turtle;
        }
        else if(randVal < .6f)
        {
            return AnimalTypes.Snail;
        }
        else if (randVal < .7f)
        {
            return AnimalTypes.Octopus;
        }
        else
        {
            return AnimalTypes.Kangaroo;
        }
    }

}
