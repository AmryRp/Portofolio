using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int NomorScene;

    private Image black;
    public virtual void OnPointerUp(PointerEventData p)
    {
        black = GetComponent<Image>();
        var tempColor = black.color;
        tempColor.a = 1f;
        black.color = tempColor;

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(NomorScene);
    }

}
