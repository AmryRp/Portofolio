using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KalahState : MonoBehaviour
{
    public Text name;
    private static KalahState instance;
    public static KalahState MyInst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<KalahState>();
            }
            return instance;
        }
    }
    public Text MyHighScore;
    public Text MyName;
    public GameObject[] Active;
    private void Start()
    {
        name = GameObject.FindGameObjectWithTag("saver").GetComponentInParent<Text>();
        MyHighScore.text = GameManager.MyInst.score.ToString();
        MyName.text = GameManager.MyInst.PlayerName;
        for (int i = 0; i < Active.Length; i++)

        {
            Active[i].gameObject.SetActive(false);
        }
    }

  
  
}
