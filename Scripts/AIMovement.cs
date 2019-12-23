using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform path;
    private List<Transform> nodes;
    private int curNodes = 0;
    private static AIMovement _instance;
    private float _horizontal;
    public float _vertical;
    private float _Setir;
    public WheelCollider frontLW, FrontRW;
    public WheelCollider rearLW, rearRW;
    public Transform frontLT, frontRT;
    public Transform rearLT, rearRT;
    public float maksimalarahsetir = 23f;
    public float motorForce = 10f;

    public float cakramrem = 500f;
    public float maxMotor = 50f;
    public float currentSpeed = 30f;
    public float maxSpeed = 80f;
    public Vector3 centerPoint;
    public bool Ngerem = false ;
    public LampuMobil LM;
    private void Start()
    {
        LM = GetComponent<LampuMobil>();

        GetComponent<Rigidbody>().centerOfMass = centerPoint;
        Transform[] pathT = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathT.Length; i++)
        {
            if (pathT[i] != path.transform)
            {
                nodes.Add(pathT[i]);
            }
        }
    }
    void applySteer()
    {   if (BelokSendiri) return;
        Vector3 relativevector = transform.InverseTransformPoint(nodes[curNodes].position);
        float maxsteer = (relativevector.x / relativevector.magnitude) * maksimalarahsetir;
        
        frontLW.steerAngle = maxsteer;
        FrontRW.steerAngle = maxsteer;
    }
       public void checkedPoint()
    {
        if (Vector3.Distance(transform.position, nodes[curNodes].position) < 8f)
        {
            if (curNodes == nodes.Count - 1)
            {
                curNodes = 0;
            }
            else 
            { curNodes++; }
        }
    }
    public void GAS()
    {
        currentSpeed = 6 * Mathf.PI * frontLW.radius * frontLW.rpm * 60 / 100;
        if (currentSpeed < maxSpeed && Ngerem != true)
        {
           // _vertical = gasssss.gas(); //untuk raycast 
            frontLW.motorTorque = maxMotor;
            FrontRW.motorTorque = maxMotor;
            ENgineSound();
        }
        else 
        {
            frontLW.motorTorque = 0;
            FrontRW.motorTorque = 0;
        }
    }
   
    public void REM(bool stop)
    {//bikin raycast 
        if (stop == true)
        {
            rearLW.brakeTorque = cakramrem;
            rearRW.brakeTorque = cakramrem;
            rearLW.motorTorque = 0;
            rearRW.motorTorque = 0;
        }
        else
        {
            rearLW.brakeTorque = 0;
            rearRW.brakeTorque = 0;
        }
    }
    private void Rodaputar()
    {
        putaranROda(frontLW, frontLT);
        putaranROda(FrontRW, frontRT);
        putaranROda(rearLW, rearLT);
        putaranROda(rearRW, rearRT);
    }

    private void putaranROda(WheelCollider coll, Transform _tr)
    {
        Vector3 _pos = _tr.position;
        Quaternion _quat = _tr.rotation;
        coll.GetWorldPose(out _pos, out _quat);
        _tr.position = _pos;
        _tr.rotation = _quat;
    }

    private void Update()
    {
        
        GAS(); 
        checkedPoint();
        applySteer();
        sensors();
        if (Ngerem == true)
        {
            REM(true);
            LM.ngerem(true);
        }
        else
        {
            REM(false);
            LM.ngerem(false);
        }
        //Rodaputar();

    }
    [Header("Sensors")]
    public float sensorsLength = 10f;
    public Vector3 frontpos = new Vector3(1.64f,0f,0f);
    public float sidePos = 0.6f;
    public float SensorAngle = -30f;
    public bool BelokSendiri = false;
    
    public void sensors()
    {
        int layer_mask = LayerMask.GetMask("boundary", "cars", "player");
        RaycastHit hit;
        Vector3 SensorStartPos = transform.position;
        SensorStartPos += transform.forward * frontpos.x;
        float belokMultiplier = 0;
        BelokSendiri = false;
       
        SensorStartPos += transform.up * frontpos.y;
        
        //depan
        if (Physics.Raycast(SensorStartPos, transform.forward, out hit, sensorsLength, layer_mask))
        {
            if (hit.collider.CompareTag("Boundary") ||  hit.collider.CompareTag("Player"))
            {
                BelokSendiri = true;

                Debug.DrawLine(SensorStartPos, hit.point);

            }
           
            if (hit.collider.CompareTag("Lampumerah")|| hit.collider.CompareTag("Cars") || hit.collider.CompareTag("Palang"))
            {
                Ngerem = true;

                Debug.DrawLine(SensorStartPos, hit.point);

            }  

        }
        else
        {
            BelokSendiri = false;
            Ngerem = false; 
            Debug.DrawLine(SensorStartPos, hit.point);
        }
        SensorStartPos += transform.right * sidePos;
            //kanan
            if (Physics.Raycast(SensorStartPos, transform.forward, out hit, sensorsLength, layer_mask))
            {
            if (hit.collider.CompareTag("Boundary") || hit.collider.CompareTag("Cars") || hit.collider.CompareTag("Player"))
            {
                    BelokSendiri = true;
                    belokMultiplier -= 1f;
                    Debug.DrawLine(SensorStartPos, hit.point);

            }
            else
            {
                BelokSendiri = false;

                Debug.DrawLine(SensorStartPos, hit.point);
            }

        }
            //serongkanan
            else if (Physics.Raycast(SensorStartPos, Quaternion.AngleAxis(SensorAngle, transform.up) * transform.forward, out hit, sensorsLength, layer_mask))
            {
            if (hit.collider.CompareTag("Boundary") || hit.collider.CompareTag("Cars") || hit.collider.CompareTag("Player"))
            {
                    BelokSendiri = true;
                    Debug.DrawLine(SensorStartPos, hit.point);
                    belokMultiplier -= 0.5f;
            }
            else
            {
                BelokSendiri = false;

                Debug.DrawLine(SensorStartPos, hit.point);
            }

        }
            //kiri
            SensorStartPos -= transform.right * sidePos * 2;
            if (Physics.Raycast(SensorStartPos, transform.forward, out hit, sensorsLength, layer_mask))
            {
            if (hit.collider.CompareTag("Boundary") || hit.collider.CompareTag("Cars") || hit.collider.CompareTag("Player"))
            {
                    BelokSendiri = true;
                    Debug.DrawLine(SensorStartPos, hit.point);
                    belokMultiplier += 1f;
            }
            else
            {
                BelokSendiri = false;

                Debug.DrawLine(SensorStartPos, hit.point);
            }


        }
            //serongkiri
            else if (Physics.Raycast(SensorStartPos, Quaternion.AngleAxis(-SensorAngle, transform.up) * transform.forward, out hit, sensorsLength, layer_mask))
            {
            if (hit.collider.CompareTag("Boundary") || hit.collider.CompareTag("Cars") || hit.collider.CompareTag("Player"))
            {
                    BelokSendiri = true;
                    Debug.DrawLine(SensorStartPos, hit.point);
                    belokMultiplier += 0.5f;
            }
            else
            {
                BelokSendiri = false;

                Debug.DrawLine(SensorStartPos, hit.point);
            }


        }
            if (belokMultiplier == 0)
            {
                if (Physics.Raycast(SensorStartPos, transform.forward, out hit, sensorsLength, layer_mask))
                {
                if (hit.collider.CompareTag("Boundary") || hit.collider.CompareTag("Cars") || hit.collider.CompareTag("Player"))
                {
                        BelokSendiri = true;

                        Debug.DrawLine(SensorStartPos, hit.point);
                        if (hit.normal.x < 0)
                        {
                            belokMultiplier = -1;
                        }
                        else
                        {
                            belokMultiplier = 1;
                        }
                }
                else
                {
                    BelokSendiri = false;

                    Debug.DrawLine(SensorStartPos, hit.point);
                }
            }
            }
            if (BelokSendiri)
            {
                frontLW.steerAngle = maksimalarahsetir * belokMultiplier;
                FrontRW.steerAngle = maksimalarahsetir * belokMultiplier;
            }
            if (belokMultiplier < 0)
            {
                LM.RetengKiri(true);
                LM.RetengKanan(false);
            }
            else if (belokMultiplier > 0)
            {
                LM.RetengKiri(false);
                LM.RetengKanan(true);
            }
            else
            {
                LM.RetengKiri(false);
                LM.RetengKanan(false);
            }
            
        }

    public void ENgineSound()
    {
        currentSpeed = transform.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        
        Pitch = currentSpeed / maxSpeed;

        transform.GetComponent<AudioSource>().pitch = Pitch;
    }
   
    public float Pitch;

}
