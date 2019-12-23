using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampuMerah : MonoBehaviour
{

    public Renderer LMdMerah;
    public Renderer LMdKuning;
    public Renderer LMdHijuan;
    public GameObject MerahdCollider;
    public GameObject KuningCollider;
    public GameObject HijaudCollider;
    
    public Renderer LMkiMerah;
    public Renderer LMkiKuning;
    public Renderer LMkiHijuan;
    public GameObject MerahkiCollider;
    public Renderer LMsbMerah;
    public Renderer LMsbKuning;
    public Renderer LMsbHijuan;
    public GameObject MerahsbCollider;
    public Renderer LMkaMerah;
    public Renderer LMkaKuning;
    public Renderer LMkaHijuan;
    public GameObject MerahkaCollider;

    public Material hijauOn, hijauOff;
    public Material merahOn, merahOff;
    public Material kuningOn, kuningOff;

   public float depan, kiri, seberang, kanan;
    float nyala = 1; // merah
    float nyala2 = 15; // merah mati ganti kuning
    float nyala3 = 18; // kuning mati ganti hijau
    float nyala4 = 23; // hijau mati ganti merah


    void Start()
    {
        LMsbMerah.material = merahOn;
        MerahsbCollider.SetActive(true);
        LMdMerah.material = merahOn;
        MerahdCollider.SetActive(true);
        LMkaMerah.material = merahOn;
        MerahkaCollider.SetActive(true);
        LMkiMerah.material = merahOn;
        MerahkiCollider.SetActive(true);
        StartCoroutine(ATCS());
    }
  
    IEnumerator ATCS()
    {
        
        while (true)
        {
            // yield return new WaitForSeconds(10f);
            bangjodepan();
  
            bangjokiri();
         
            bangjoseberang();
        
            bangjokanan();
            yield return new WaitForSeconds(0.01f);
        }
        

    }
    private void bangjodepan()
    {
        depan += Time.deltaTime;
        
        if (depan >= nyala && depan <= nyala2)
        {
            LMdMerah.material = merahOn;
            MerahdCollider.SetActive(true);
            HijaudCollider.SetActive(false);
            KuningCollider.SetActive(false);
        }
        else if (depan >= nyala2 && depan <= nyala3)
        {
            LMdMerah.material = merahOff;
            LMdKuning.material = kuningOn;
            MerahdCollider.SetActive(false);
            KuningCollider.SetActive(true);
            HijaudCollider.SetActive(false);
        }
        else if (depan >= nyala3 && depan <= nyala4)
        {
            LMdKuning.material = kuningOff;
            LMdHijuan.material = hijauOn;
            KuningCollider.SetActive(false);
            HijaudCollider.SetActive(true);
            MerahdCollider.SetActive(false);
        }
        else if (depan >= nyala4)
        {
            LMdHijuan.material = hijauOff;
            LMdMerah.material = merahOn;
            KuningCollider.SetActive(false);
            HijaudCollider.SetActive(false);
            MerahdCollider.SetActive(true);
            depan = 0;
        }

    }
    private void bangjokiri()
    {
        kiri += Time.deltaTime;

        if (kiri >= nyala+5 && kiri <= nyala2+5)
        {
            LMkiMerah.material = merahOn;
            MerahkiCollider.SetActive(true);
        }
        else if (kiri >= nyala2+5 && kiri <= nyala3+5)
        {
            LMkiMerah.material = merahOff;
            LMkiKuning.material = kuningOn;
            MerahkiCollider.SetActive(false);
        }
        else if (kiri >= nyala3+5 && kiri <= nyala4+5)
        {
            LMkiKuning.material = kuningOff;
            LMkiHijuan.material = hijauOn;
        }
        else if (kiri >= nyala4+5)
        {
            LMkiHijuan.material = hijauOff;
            LMkiMerah.material = merahOn;
            kiri = 0;
        }
    }
    private void bangjoseberang()
    {
        seberang += Time.deltaTime;

        if (seberang >= nyala+10 && seberang <= nyala2+10)
        {
            LMsbMerah.material = merahOn;
            MerahsbCollider.SetActive(true);
        }
        else if (seberang >= nyala2+10 && seberang <= nyala3+10)
        {
            LMsbMerah.material = merahOff;
            LMsbKuning.material = kuningOn;
            MerahsbCollider.SetActive(false);

        }
        else if (seberang >= nyala3+10 && seberang <= nyala4+10)
        {
            LMsbKuning.material = kuningOff;
            LMsbHijuan.material = hijauOn;
        }
        else if (seberang >= nyala4+10)
        {
            LMsbHijuan.material = hijauOff;
            LMsbMerah.material = merahOn;
            seberang = 0;
        }
    }
    private void bangjokanan()
    {
        kanan += Time.deltaTime;

        if (kanan >= nyala+15 && kanan <= nyala2+15)
        {
            LMkaMerah.material = merahOn;
            MerahkaCollider.SetActive(true);
        }
        else if (kanan >= nyala2+15 && kanan <= nyala3+15)
        {
            LMkaMerah.material = merahOff;
            LMkaKuning.material = kuningOn;
            MerahkaCollider.SetActive(false);
        }
        else if (kanan >= nyala3+15 && kanan <= nyala4+15)
        {
            LMkaKuning.material = kuningOff;
            LMkaHijuan.material = hijauOn;
        }
        else if (kanan >= nyala4+15)
        {
            LMkaHijuan.material = hijauOff;
            LMkaMerah.material = merahOn;
            kanan = 0;
        }
    }
}
