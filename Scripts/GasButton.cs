using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GasButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public ParticleSystem kanan;
    public ParticleSystem kiri;
    bool isPointerDn = false;
    public float carspeed = 0;
    public virtual void OnPointerUp(PointerEventData p)
    {
        isPointerDn = false;
    }
    public virtual void OnPointerDown(PointerEventData p)
    {
        isPointerDn = true;
        StartCoroutine(CarController.Instance.Kebul());
    }
    public float gas()
    {
        if (isPointerDn == true)
        {
            
            if (carspeed == 0 || carspeed <= 20) 
            { carspeed += 1f; 
            }
            else 
            { carspeed = 0f; }

        }
        else
        {
            carspeed = 0;
        }
        return carspeed;
    }

}
