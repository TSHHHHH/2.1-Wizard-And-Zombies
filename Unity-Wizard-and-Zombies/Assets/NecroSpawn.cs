using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroSpawn : MonoBehaviour {

    public Transform[] spawnSpots;
    public Transform[] zombieList;
    public float startTimeBtwSpawns;
    public GameObject summonAni;

    private float timeBtwSpawns;
    private NecroZombie necroScript;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;

        necroScript = GetComponent<NecroZombie>();
    }

    private void Update()
    {
        if(necroScript.summon == true)
        {
            if (timeBtwSpawns <= 0)
            {
                int randPos = Random.Range(0, spawnSpots.Length);
                int randZombie = Random.Range(0, zombieList.Length);
                Instantiate(zombieList[randZombie], spawnSpots[randPos].position, Quaternion.identity);
                Instantiate(summonAni, spawnSpots[randPos].position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
