using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISPAWNER : MonoBehaviour
{
    public GameObject[] CARS;
    public Vector3 spawnVal;
    public float SpawnDelay, spawnMostWait, SpawnLeastWait, StartWait;
    public bool stop;
    private Transform player;
    int randCars;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(WaitSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnDelay = Random.Range(SpawnLeastWait, spawnMostWait);
    }

    IEnumerator WaitSpawn()
    {
       
        
        yield return new WaitForSeconds(StartWait);

        while (!stop)
        {
            randCars = Random.Range(0, CARS.Length);

            Vector3 spawnPos = new Vector3(Random.Range(-spawnVal.x, spawnVal.x), 1f, player.position.z+50);

            Instantiate(CARS[randCars],spawnPos+transform.TransformPoint(0,0,0),gameObject.transform.rotation);
            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}
