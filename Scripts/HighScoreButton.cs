using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighScoreButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Animator myAnim;
    public GameObject[] LoadHighScorePanel;
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
        myAnim.SetTrigger("Out");
        
         black = GetComponent<Image>();
        var tempColor = black.color;
        tempColor.a = 0.8f;
        black.color = tempColor;
        HighScoreTable.MyInstance.loadData();
        for (int i = 0; i < LoadHighScorePanel.Length; i++)
        {
            LoadHighScorePanel[i].gameObject.SetActive(true);
        }
        
    }
    
}
