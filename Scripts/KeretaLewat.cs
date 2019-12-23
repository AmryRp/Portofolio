using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeretaLewat : MonoBehaviour
{
    public Animator palang,palang2;
    public Animator kereta;
    public AudioSource SuaraKereta;
   
    //Tambahin Lampu Rambu Kereta Lewat
    private void OnTriggerEnter(Collider cl)
    {
        if (cl.gameObject.tag == "Player")
        {
            StartCoroutine(KeretaJalan());
               
        }
      
    }
    IEnumerator KeretaJalan()
    {
        while (true)
        {
            
            kereta.SetTrigger("jalan");
            SuaraKereta.Play();
            yield return new WaitForSeconds(6f);
            palang.SetTrigger("buka");
            palang2.SetTrigger("buka");

            SuaraKereta.Stop();
            break;
        }
    }
}
