using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ButtonCredits : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private int sceneindex;
    private void OnMouseDown()
    {

        SceneManager.LoadScene(sceneindex);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnMouseDown();
    }
}
