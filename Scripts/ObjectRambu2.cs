using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ObjectRambu2 : MonoBehaviour
{
    private static ObjectRambu2 instance;
    public static ObjectRambu2 MyInst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectRambu2>();
            }
            return instance;
        }
    }
    public String namaRambu;
    [TextArea(3, 10)]
    public String deskripsi;
    [SerializeField]
    private SpriteRenderer GambarRambu;
    [SerializeField]
    private Animator PanelAnimationPOP;
   
    private void Start()
    {
        PanelAnimationPOP = GameObject.FindGameObjectWithTag("Panel").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.MyInst.RambuCollider(namaRambu, deskripsi, GambarRambu.sprite);
            StartCoroutine(SpawnAndOut());
         
        }
    }
    
    IEnumerator SpawnAndOut()
    {    while (true)
        {
            PanelAnimationPOP.SetTrigger("PopUp");
            yield return new WaitForSeconds(3f);
            PanelAnimationPOP.SetTrigger("alert");
            yield return new WaitForSeconds(2f);
            PanelAnimationPOP.SetTrigger("PopOut");
            PanelAnimationPOP.SetTrigger("Hilang");
            yield return new WaitForSeconds(0.1f);
            PanelAnimationPOP.ResetTrigger("PopUp");
            PanelAnimationPOP.ResetTrigger("alert");
            PanelAnimationPOP.ResetTrigger("PopOut");
            PanelAnimationPOP.ResetTrigger("Hilang");
            break;
        }
    }
  
}
