using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signsSys : MonoBehaviour
{
    private static signsSys instance;
    public static signsSys MyInst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<signsSys>();
            }
            return instance;
        }
    }
    public GameObject SignKanan;
    public GameObject SignKiri;
    public Vector3 spawnVal;
    public float SpawnDelay, spawnMostWait, SpawnLeastWait, StartWait;
    public bool stop = false,kanan=false,kiri=false;
    private Transform player;
    int randCars;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    string jalankanan = "";
    public void KananOn(bool kanan)
    {
     SignKanan.SetActive(kanan);
        SignKiri.SetActive(false);
        jalankanan = "jalankanan";
    }
    public void KiriOn(bool kiri)
    {
     SignKiri.SetActive(kiri);
        SignKanan.SetActive(false);
       jalankanan = "jalankiri";
    }
    public float timeL,maxtime=10f;
    public string pelanggaranReteng;
    public Text Notif;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(jalankanan))
        {
            GameManager.MyInst.score += 10;
            StartCoroutine(Waktu());
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("perbaikan"))
        {
            GameManager.MyInst.score += 2;
            Kelamaan();
        }
        if (other.CompareTag(jalankanan))
        {
            GameManager.MyInst.score += 1;
            Kelamaan();
        }
    }
    private void Update()
    {
        Kelamaan();
    }
    public void Kelamaan()
    {
        
        if (timeL == maxtime)
        {
            int tilang = GameManager.MyInst.score -= 5;
            pelanggaranReteng = "Lampu Sign Masih Menyala Score: -" + tilang.ToString();
            GameManager.MyInst.score -= tilang;
            Notif.text = pelanggaranReteng;
            StartCoroutine(CarController.Instance.Clear()) ;
            timeL = 0;
            DaftarPelanggaran.MyInstance.TilangPelanggaran(pelanggaranReteng, tilang);
        }
    }

    IEnumerator Waktu()
    {   while (true)
        {
            timeL += Time.deltaTime;
            if (timeL == maxtime)
            {
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
       
    }
}
