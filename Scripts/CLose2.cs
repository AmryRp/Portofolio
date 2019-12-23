using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CLose2 : MonoBehaviour, IPointerDownHandler
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
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }
        StartCoroutine(Back());
    }
    IEnumerator Back()
    {
        while (true)
        {
            myAnim.SetTrigger("PopUp");
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < CloseHIghscore.Length; i++)
            {
                CloseHIghscore[i].gameObject.SetActive(false);
            }
            black = GetComponent<Image>();
            var tempColor = black.color;
            tempColor.a = 0.8f;
            black.color = tempColor;
            
            break;
        }
    }
}
