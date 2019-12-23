using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinReceiver : MonoBehaviour
{
    public Animator player;
    public GameObject[] Coin;
    private void Start()
    {
        player = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        Coin = GameObject.FindGameObjectsWithTag("Coin");
        if (Coin.Length >= 10)
        {
            Destroy(Coin[0].gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.transform.tag == "Coin")
        {
           
            player.SetTrigger("Coin");
            GameManager.MyInst.score += 10;
            UiManager.MyInst.UpdateScore();
            Destroy(other.gameObject);
        }
    }
}
