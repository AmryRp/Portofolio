using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Steering : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{   [SerializeField]
    public bool kiri = false;
    [SerializeField]
    public bool kanan =  false;
    bool isPointerDn = false;
    float arahbelok = 0;

    public void OnPointerUp(PointerEventData eventData)
    {
       isPointerDn = false;
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDn = true;
        
    }
    public void Kanan()
    {
        kanan = true;
        
    }
    public void KananUp()
    {
        kanan = false;
        
    }
    public void Kiri()
    {
        kiri = true;
        
    }
    public void KiriUp()
    {
        kiri = false;
        
    }

    public float belok()
    {
        if (kanan == true)
        {
            if (arahbelok == 0 || arahbelok <= 20)
            { arahbelok += 0.09f; }
            else
            { arahbelok = 0f; }
        }
        else if (kiri == true)
        {
            if (arahbelok == 0 || arahbelok >= -20)
            { arahbelok -= 0.09f; }
            else
            { arahbelok = 0f; }
        }
        
        else
        { arahbelok = 0f; }

        return arahbelok;
    }
}
