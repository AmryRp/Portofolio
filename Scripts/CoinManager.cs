using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject[] coins;
    public float CoinTime;
    public float HealthTime = 5f;
    private Transform player;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnCoins());
        StartCoroutine(SpawnHealths());
    }
    IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(CoinTime);
        Spawn();
    }
    IEnumerator SpawnHealths()
    {
        yield return new WaitForSeconds(HealthTime);
        Spawn2();
    }
    void Spawn()
    {  
        int RandCoind = UnityEngine.Random.Range(0, 1);
        float[] xpos = new float[3];
        xpos[0] = 0f;
        xpos[1] = 2.17f;
        xpos[2] = -2.17f;

        int randomXpos = UnityEngine.Random.Range(0, xpos.Length);

        Vector3 hpos = new Vector3(xpos[randomXpos], 1f, player.position.z + 40);
        Instantiate(coins[RandCoind], hpos, coins[RandCoind].transform.rotation);

        StartCoroutine(SpawnCoins());
    }
    void Spawn2()
    {
        int RandCoind = UnityEngine.Random.Range(1, 2);
        float[] xpos = new float[3];
        xpos[0] = 0f;
        xpos[1] = 2.17f;
        xpos[2] = -2.17f;

        int randomXpos = UnityEngine.Random.Range(0, xpos.Length);

        Vector3 hpos = new Vector3(xpos[randomXpos], 1f, player.position.z + 40);
        Instantiate(coins[RandCoind], hpos, coins[RandCoind].transform.rotation);

        StartCoroutine(SpawnHealths());
    }
    // Update is called once per frame

}
