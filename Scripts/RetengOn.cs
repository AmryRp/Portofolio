using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RetengOn : MonoBehaviour, IPointerDownHandler
{
    private static RetengOn instance;
    public static RetengOn MyInst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RetengOn>();
            }
            return instance;
        }
    }
    public LampuMobil reteng;
    public bool onoff;
    public bool pressbutton;
    public bool kanan;
    public bool kiri;
    public void Kanan()
    {
        kanan = kanan == true ? false : true;
        kiri = false;
        signsSys.MyInst.KananOn(kanan);
        HazardOn.MyInst.onoff = false;
    }

    public void Kiri()
    {
        kiri = kiri == true ? false : true;
        kanan =  false;
        signsSys.MyInst.KiriOn(kiri);
        HazardOn.MyInst.onoff = false;
    }
    public void OnPointerDown(PointerEventData pd)
    {
        pressbutton = pressbutton == true ? false : true;
        if (pressbutton == true )
        {
            StartCoroutine(flash());
        }
        else
        {
            StopCoroutine(flash());
        }
    }
   
    IEnumerator flash()
    {

        while (pressbutton)
        {
            yield return new WaitForSeconds(0.3f);
            onoff = onoff == true ? false : true;
            if (onoff == true)
            {
                if (kanan == true)
                {
                    reteng.RetengKiri(false);
                    reteng.RetengKanan(true);
                   
                }
                else if (kiri == true)
                {
                    reteng.RetengKanan(false);
                    reteng.RetengKiri(true);
                  
                }
            }

            else if (onoff == false)
            {
                if (kanan == true)
                {
                    reteng.RetengKanan(false);
                }
                else if (kiri == true)
                {
                    reteng.RetengKiri(false);
                }
            }
        }
     }
       
    
}
