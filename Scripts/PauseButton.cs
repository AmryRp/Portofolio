using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour, IPointerDownHandler
{
    public Animator myAnim;
    public GameObject[] Active;
    public virtual void OnPointerDown(PointerEventData p)
    {
        
        myAnim.SetTrigger("Out");

        for (int i = 0; i < Active.Length; i++)
        {
            Active[i].SetActive(true);
        }
        StartCoroutine(stops());
    }
    IEnumerator stops()
    {
        yield return new WaitForSeconds(1f);
        while (true) 
        {
            Time.timeScale = 0;
            break; }
       
    }
}
