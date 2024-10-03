using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    public GameObject Monster;

    public Transform[] spawnpoints;

    public float minSpawnInterval = 15f;

    public float maxSpawnInterval = 25f;
   
    public float reducedSpawnInterval = 0.5f;
    
    public float intitalDelay = 10f;

    private GameObject currentMonster;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster1());
    }

    IEnumerator SpawnMonster1()
    {
        yield return new WaitForSeconds(intitalDelay);
        
        while (true)
        {
            if (currentMonster == null)
            {
                SpawnMonster();
            }

            float randomInterval;

            if (Input.GetKey(KeyCode.Space))
            {
                randomInterval = reducedSpawnInterval;
            }
            else
            { 
                randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval); 
            }
            
            yield return new WaitForSeconds(randomInterval);
        }
    }

    void SpawnMonster()
    {
        //Random spawnpoint
        int randomindex = Random.Range(0, spawnpoints.Length);
        Transform spawnpoint = spawnpoints[randomindex];
        

       currentMonster = Instantiate(Monster, spawnpoint.position, spawnpoint.rotation);

       MonsterCode monsterScript = currentMonster.GetComponent<MonsterCode>();
       monsterScript.Initialize(randomindex);

    }

    public void OnMonsterDestroyed()
    {
        currentMonster = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
