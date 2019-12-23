using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInformasi : MonoBehaviour , IPointerDownHandler
{   [SerializeField]
    private bool Active = false;
    public GameObject[] TampilTutup;
    public Animator myAnim;
    private void OnMouseDown()
    {
        Active = true; 
        for (int i = 0; i < TampilTutup.Length; i++)
        {
            TampilTutup[i].gameObject.SetActive(true);
        }
        myAnim.SetTrigger("Out");

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnMouseDown();
    }
}
