using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private static HealthBar instance;
    public static HealthBar MyInst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HealthBar>();
            }
            return instance;
        }
    }
    public float health;
    public float DecHealthTime;
    [SerializeField]
    private Transform bar;
    public bool mati = false;
    // Start is called before the first frame update
    void Start()
    {
         bar = transform.Find("Bar");
        StartCoroutine(kurangin());
    }
    private void Update()
    {
       
      if (health <= 0)
        {
            mati = true;
        }
        if (mati == true)
        {
            bar.localScale = new Vector3(0, 1f);
            StartCoroutine(CarController.Instance.Kalah());
        }
    }

    public void SetSize(float SizeNM)
    {
        bar.localScale = new Vector3(SizeNM, 1f);
        health = SizeNM;
        if (health != 0)
        {
            mati = false;
            
        }
        else if (health <= 0)
        {
            mati = true;
       }
       
    }

    IEnumerator kurangin()
    {
        //bool jalankan = false;
        //if (health <= 0 && health >= 1)
        //{
        //    jalankan = true;
        //}
        //else 
        //{
        //    jalankan = false;
        //}
          while (true)
            {
                yield return new WaitForSeconds(0.3f);
                CarController.Instance.DecreaseOverTime(0.01f * 100 / 1000);
            if (health <= 0)
            {
                break;
            }
        }
        
    }
}
