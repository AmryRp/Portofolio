using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Transform lihatke;
    public Vector3 startOffset;
    public float followS = 10;
    public float lookS = 10;
    public void LookT()
    {
        Vector3 _lookdirection = lihatke.position - transform.position;
        Quaternion _r = Quaternion.LookRotation(_lookdirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _r, lookS * Time.deltaTime);
    }
    public void MoveTT() 
    {
        Vector3 _TPos = lihatke.position +
                        lihatke.forward * startOffset.z +
                        lihatke.right * startOffset.x +
                        lihatke.up * startOffset.y;
        transform.position = Vector3.Lerp(transform.position, _TPos, followS * Time.deltaTime);
    }

    void FixedUpdate()
    {
        LookT();
        MoveTT();
    }
}
