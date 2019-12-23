using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{   
    [SerializeField]
    float HealthIncrease;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (HealthBar.MyInst.health <= 1)
            {
                Decrease(HealthIncrease);
                Destroy(gameObject);
            }
        
        }
    }
    
    public void Decrease(float damage)
    {
        float tmp;

        tmp = HealthBar.MyInst.health + damage;
        HealthBar.MyInst.SetSize(tmp);
    }
}
