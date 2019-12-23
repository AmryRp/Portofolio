using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTROYSCRIPT : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cars"))
        {
            Destroy(other.gameObject);
        }
    }
   
}
