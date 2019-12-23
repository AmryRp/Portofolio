using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampuMobil : MonoBehaviour
{
    public Renderer lampuremL;
    public Renderer lampuremR;
    public Material RemHidup;
    public Material RemMati;

    public Renderer lampuSignL;
    public Renderer lampuSignR;
    public Renderer lampuSignLd;
    public Renderer lampuSignRd;
    public Material SignHidup;
    public Material SignMati;

    public Renderer LampuUtamaR;
    public Renderer LampuUtamaL;

    public Material LLhidup;
    public Material LRMati;


    
    // Start is called before the first frame update
    public void ngerem(bool nyala)
    {
        if (nyala == true)
        {
            lampuremR.material = RemHidup;
            lampuremL.material = RemHidup;
        }
        else
        {
            lampuremR.material = RemMati;
            lampuremL.material = RemMati;
        }
    }
    
    public void Hazard(bool nyala)
    {
        if (nyala == true)
        {
                lampuSignR.material = SignHidup;
                lampuSignRd.material = SignHidup;
               
                lampuSignL.material = SignHidup;
                lampuSignLd.material = SignHidup;
                
        }
        else
        {
            lampuSignR.material = SignMati;
            lampuSignRd.material = SignMati;
           
            lampuSignL.material = SignMati;
            lampuSignLd.material = SignMati;
          
        }
    }
    public void RetengKanan(bool nyala)
    {
        if (nyala == true)
        {
            lampuSignR.material = SignHidup;
            lampuSignRd.material = SignHidup;
           
        }
        else
        {
            lampuSignR.material = SignMati;
            lampuSignRd.material = SignMati;
           
        }
    }
        public void RetengKiri(bool nyala)
    {
        if (nyala == true)
        {
            lampuSignL.material = SignHidup;
            lampuSignLd.material = SignHidup;
           
        }
        else
        {
            lampuSignL.material = SignMati;
            lampuSignLd.material = SignMati;
           
        }
    }

}
