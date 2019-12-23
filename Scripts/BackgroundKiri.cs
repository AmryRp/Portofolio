using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundKiri : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    public void Move()
    {
        transform.Translate(Vector3.forward * Speed * Time.smoothDeltaTime);
    }
}
