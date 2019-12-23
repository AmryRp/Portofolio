using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TombolStart : MonoBehaviour, IPointerDownHandler
{
    public Animator gameplayAnim;
    public Animator myAnim;
    public GameObject MainMenuCAm;
    public GameObject[] Active;
    public virtual void OnPointerDown(PointerEventData p)
    {

        StartCoroutine(OutAndSpawn());
        Destroy(MainMenuCAm);
    }
    IEnumerator OutAndSpawn()
    {
        while (true)
        {
            myAnim.SetTrigger("Out");
            yield return new WaitForSeconds(1f);
            gameplayAnim.SetTrigger("PopUp");
            for (int i = 0; i < Active.Length; i++)
            {
                Active[i].gameObject.SetActive(true);
            }
            break;
        }

    }
}
