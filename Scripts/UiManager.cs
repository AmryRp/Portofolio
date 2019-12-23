using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text CurrScore; 
    private static UiManager instance;
    public static UiManager MyInst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UiManager>();
            }
            return instance;
        }
    }
   
    public void UpdateScore()
    {
        CurrScore.text = GameManager.MyInst.score.ToString();
    }

    public Text PopUpNama, PopUpDeskripsi;
    public Image PopUpRambu;

}
