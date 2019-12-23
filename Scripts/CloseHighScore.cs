using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CloseHighScore : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Animator myAnim;
    public GameObject[] CloseHIghscore;
    private Image black;
    public virtual void OnPointerUp(PointerEventData p)
    {
        black = GetComponent<Image>();
        var tempColor = black.color;
        tempColor.a = 1f;
        black.color = tempColor;
        
    }
    public virtual void OnPointerDown(PointerEventData p)
    {
        myAnim.SetTrigger("PopUp");
        for (int i = 0; i < CloseHIghscore.Length; i++)
        {
            CloseHIghscore[i].gameObject.SetActive(false);
        }
        black = GetComponent<Image>();
        var tempColor = black.color;
        tempColor.a = 0.8f;
        black.color = tempColor;
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }
    }
    
}
