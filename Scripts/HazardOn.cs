using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HazardOn : MonoBehaviour, IPointerDownHandler
{
    private static HazardOn instance;
    public static HazardOn MyInst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HazardOn>();
            }
            return instance;
        }
    }
    public LampuMobil hazard;
  
    public bool onoff;
    public bool pressbutton;
   
    public void OnPointerDown(PointerEventData pd)
    {
        pressbutton = pressbutton == true ? false : true;
        if (pressbutton == true)
        {
            StartCoroutine(flash());
            ColliderHazard.gameObject.SetActive(true);
            RetengOn.MyInst.kanan = false;
            RetengOn.MyInst.kiri = false;
           
        }
        else 
        {
            StopCoroutine(flash());
            ColliderHazard.gameObject.SetActive(false);
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
                hazard.Hazard(true);
                signsSys.MyInst.KananOn(onoff);
                signsSys.MyInst.KiriOn(onoff);
            }
            else if (onoff == false)
            {
                hazard.Hazard(false);
                signsSys.MyInst.KananOn(onoff);
                signsSys.MyInst.KiriOn(onoff);
            }
        }
    }

    public GameObject ColliderHazard;

}

