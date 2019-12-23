using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampuMerahP3 : MonoBehaviour
{

    public Renderer LMdMerah;
    public Renderer LMdKuning;
    public Renderer LMdHijuan;
    public GameObject MerahdCollider;
    public GameObject KuningCollider;
    public GameObject HijaudCollider;

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

    public float depan, seberang, kanan;
    float nyala = 1; // merah
    float nyala2 = 9; // merah mati ganti kuning
    float nyala3 = 12; // kuning mati ganti hijau
    float nyala4 = 15; // hijau mati ganti merah

    void Start()
    {
        LMsbMerah.material = merahOn;
        MerahsbCollider.SetActive(true);
        LMdMerah.material = merahOn;
        MerahdCollider.SetActive(true);
        LMkaMerah.material = merahOn;
        MerahsbCollider.SetActive(true);
        StartCoroutine(ATCS());
    }
    
    IEnumerator ATCS()
    {
        while (true)
        {
            bangjokanan();
           

            bangjoseberang();
            bangjodepan();

            yield return new WaitForSeconds(0.01f);
        }


    }
    private void bangjodepan()
    {
        depan += Time.deltaTime;

        if (depan >= nyala +6 && depan <= nyala2+6)
        {
            LMdMerah.material = merahOn;
            MerahdCollider.SetActive(true);
            HijaudCollider.SetActive(false);
            KuningCollider.SetActive(false);
        }
        else if (depan >= nyala2+6 && depan <= nyala3+6)
        {
            LMdMerah.material = merahOff;
            LMdKuning.material = kuningOn;
            MerahdCollider.SetActive(false);
            KuningCollider.SetActive(true);
            HijaudCollider.SetActive(false);

        }
        else if (depan >= nyala3+6 && depan <= nyala4+6)
        {
            LMdKuning.material = kuningOff;
            LMdHijuan.material = hijauOn;
            KuningCollider.SetActive(false);
            HijaudCollider.SetActive(true);
            MerahdCollider.SetActive(false);
        }
        else if (depan >= nyala4+6)
        {
            LMdHijuan.material = hijauOff;
            LMdMerah.material = merahOn;
            KuningCollider.SetActive(false);
            HijaudCollider.SetActive(false);
            MerahdCollider.SetActive(true);
            depan = 0;
        }

    }
    private void bangjoseberang()
    {
        seberang += Time.deltaTime;

        if (seberang >= nyala + 3 && seberang <= nyala2 +3)
        {
            LMsbMerah.material = merahOn;
            MerahsbCollider.SetActive(true);
        }
        else if (seberang >= nyala2 + 3 && seberang <= nyala3 + 3)
        {
            LMsbMerah.material = merahOff;
            LMsbKuning.material = kuningOn;
            MerahsbCollider.SetActive(false);

        }
        else if (seberang >= nyala3 + 3 && seberang <= nyala4 + 3)
        {
            LMsbKuning.material = kuningOff;
            LMsbHijuan.material = hijauOn;
        }
        else if (seberang >= nyala4 + 4)
        {
            LMsbHijuan.material = hijauOff;
            LMsbMerah.material = merahOn;
            MerahsbCollider.SetActive(true);
            seberang = 0;
        }
    }
    private void bangjokanan()
    {
        kanan += Time.deltaTime;

        if (kanan >= nyala  && kanan <= nyala2 )
        {
            LMkaMerah.material = merahOn;
            MerahkaCollider.SetActive(true);
        }
        else if (kanan >= nyala2  && kanan <= nyala3 )
        {
            LMkaMerah.material = merahOff;
            LMkaKuning.material = kuningOn;
            MerahkaCollider.SetActive(false);
        }
        else if (kanan >= nyala3  && kanan <= nyala4 )
        {
            LMkaKuning.material = kuningOff;
            LMkaHijuan.material = hijauOn;
        }
        else if (kanan >= nyala4 )
        {
            LMkaHijuan.material = hijauOff;
            LMkaMerah.material = merahOn;
            MerahkaCollider.SetActive(true);
            kanan = 0;
        }
    }
}
