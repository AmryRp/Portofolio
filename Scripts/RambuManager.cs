using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RambuManager : MonoBehaviour
{
    public ObjectRambu2[] Rambu;
    public Vector3 spawnVal;
    public float SpawnDelay, spawnMostWait, SpawnLeastWait, StartWait;
    public bool stop;
    private Transform player;
    int randCars;
    public GameObject[] Rambu2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(WaitSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnDelay = UnityEngine.Random.Range(SpawnLeastWait, spawnMostWait);
    }
    
    IEnumerator WaitSpawn()
    {
        GameObject RambuRambu;
        Rambu2 = GameObject.FindGameObjectsWithTag("Rambu");
        yield return new WaitForSeconds(StartWait);
        if (Rambu2.Length >= 4)
        {
            Destroy(Rambu2[0].gameObject);
        }
        while (!stop)
        {
            randCars = UnityEngine.Random.Range(0, Rambu.Length);

            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-spawnVal.x, spawnVal.x), 1f, player.position.z + 50);

          _ = Instantiate(Rambu[randCars], spawnPos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation) ;
            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}

