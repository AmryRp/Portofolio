using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetsButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject ResButton;
    public virtual void OnPointerDown(PointerEventData p)
    {
        CarController.Instance.ResPos();
        ResButton.SetActive(false);
    }
}
