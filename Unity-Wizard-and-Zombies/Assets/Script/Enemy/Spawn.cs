using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] spawnSpots;
    public Transform[] zombieList;
    public float startTimeBtwSpawns;

    private float timeBtwSpawns;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    private void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length);
            int randZombie = Random.Range(0, zombieList.Length);
            Instantiate(zombieList[randZombie], spawnSpots[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}