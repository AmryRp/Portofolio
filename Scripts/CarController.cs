using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    private static CarController _instance;

    public static CarController Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private bool ngerem;
    public float cakramrem = 500f;
    public GasButton gasssss;
    public Steering belok;
    public Steering belok2;
    public void GetInput()
    {
        
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
        
    }
    public ParticleSystem kanan;
    public ParticleSystem kiri;
    public void Belok()
    {
       
            _horizontal = belok.belok();
        _Setir = (TurnSpeed/maksimalarahsetir) * _horizontal * 1.85f;
        _Setir2 = (TurnSpeed/maksimalarahsetir) * _horizontal * 1.85f;
        frontLW.steerAngle = _Setir;
         FrontRW.steerAngle = _Setir2;
        if (_horizontal < 0)
        {

            kiri.Emit(1);
        }
        else if (_horizontal > 0)
        {
            kanan.Emit(1);
        }


    }
    public void GAS()
    {
        if (_vertical <= maxGas)
        {
            
            _vertical = gasssss.gas();
            rearLW.motorTorque = _vertical * motorForce;
            rearRW.motorTorque = _vertical * motorForce;
            ENgineSound();
            
        }
        else
        {
            _vertical = 0;
        }
    }

    public ParticleSystem Kebuls;
    public IEnumerator Kebul()
    {
        while (true)
        {
            Kebuls.Emit(10);
            yield return new WaitForSeconds(7f);
            
            break;
        }
    }

        public void REM(bool stop)
    {
        if ( stop == true)
        {
            ngerem = true;
        }
        else
        {
            ngerem = false;
        }
        if (ngerem == true)
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
            //rearLW.motorTorque = 0;
            //rearRW.motorTorque = 0;
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
    public void KalahNow()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            HealthBar.MyInst.health = 0;
        }
    }
    private void FixedUpdate()
    {
        GetInput();
        Belok();
        GAS();
        Rodaputar();
        thisOBject = GetComponent<Transform>().rotation;
        ResetSpawner();
    }
    public void ENgineSound()
    {
        currentSpeed = transform.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        //sourcesnd.Play();
        Pitch = currentSpeed / maxGas;

        transform.GetComponentInChildren<AudioSource>().pitch = Pitch;
    }
    public float currentSpeed = 0;
   
    public float Pitch;
    private float _horizontal;
    public float _vertical;
    private float _Setir;
    private float _Setir2;
    public float TurnSpeed;

    public WheelCollider frontLW, FrontRW;
    public WheelCollider rearLW, rearRW;
    public Transform frontLT, frontRT;
    public Transform rearLT, rearRT;
    public float maksimalarahsetir = 23;
    public float motorForce = 10;
    public float maxGas = 20f;

    public SpriteRenderer HealthBarBlink;
    public string PelanggaranLM;
    public Text Notif;
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.CompareTag("Cars"))
        {
            if (HealthBar.MyInst.health >= 0)
            {
                while (true)
                {
                    Decrease(0.2f);
                    StartCoroutine(Blink());
                    int tilang = 5;
                    GameManager.MyInst.score -= tilang;
                    Notif.text = "menabrak Mobil Lain Score: -" + tilang.ToString();
                    DaftarPelanggaran.MyInstance.TilangPelanggaran(Notif.text, tilang);
                    StartCoroutine(Clear());
                    break;
                }
            }
        }
        if (hit.collider.CompareTag("Palang"))
        {
            if (HealthBar.MyInst.health >= 0)
            {
                while (true)
                {
                    Decrease(0.15f);
                    StartCoroutine(Blink());
                    int tilang = 5;
                    GameManager.MyInst.score -= tilang;
                    Notif.text = "menabrak Palang Kereta APi Score: -" + tilang.ToString();
                    DaftarPelanggaran.MyInstance.TilangPelanggaran(Notif.text, tilang);
                    StartCoroutine(Clear());
                    break;
                }
            }
        }
        if (hit.collider.CompareTag("Boundary"))
        {
            ResetButton.SetActive(true);
        }
        }
    int LampumerahT = 10;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Lampumerah"))
        {
            while (true)
            {
                GameManager.MyInst.score -= LampumerahT;
                PelanggaranLM = "melanggar Lampu Merah Score: -" + LampumerahT.ToString();
                Notif.text = PelanggaranLM;
                DaftarPelanggaran.MyInstance.TilangPelanggaran(Notif.text, LampumerahT);
                StartCoroutine(Clear());
                break;
            }      
        }

    }
    public IEnumerator Clear()
    { 
        yield return new WaitForSeconds(1f);
        while (true)
        {
            Notif.text = "";
            break;
        } 
    }
    IEnumerator Blink()
    {
        int waktu = 0;
        while (true)
        {
            Color myColor = new Color();
            HealthBarBlink.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            ColorUtility.TryParseHtmlString( "#40B939", out myColor);
            HealthBarBlink.color = myColor;
            yield return new WaitForSeconds(0.1f);
            HealthBarBlink.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            ColorUtility.TryParseHtmlString("#40B939", out myColor);
            HealthBarBlink.color = myColor;
            yield return new WaitForSeconds(0.02f);
            HealthBarBlink.color = Color.white;
            yield return new WaitForSeconds(0.02f);
            ColorUtility.TryParseHtmlString("#40B939", out myColor);
            HealthBarBlink.color = myColor;
            waktu++;
            if (waktu == 3)
            {
                waktu = 0;
                break;
            }
        }
    }

    public GameObject[] KalahScreen;
    int count;
    public IEnumerator Kalah()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
           
            GameManager.MyInst.calculateScore();
            for (int i = 0; i < KalahScreen.Length; i++)
            {
                KalahScreen[i].SetActive(true);
                count += i;
            }
            Time.timeScale = 0;
            if (count == KalahScreen.Length)
            { break; }
        }
    }
    public HealthBar HP;
    public void Decrease(float damage)
    {
        float tmp;
        
        tmp = HP.health - damage;
        HP.SetSize(tmp);
    }
    public void DecreaseOverTime(float Rate)
    {
        float tmp;

        tmp = HP.health - Rate;
        HP.SetSize(tmp);
    }

    public Vector3 Replace;
    public Quaternion change(float x, float y, float z)
    {
        return new Quaternion(x, y, z, 1);
    }
    public void ResPos()
    {
        Replace = new Vector3(0f, 0.5f, transform.position.z);
        transform.position = Replace;

        transform.rotation = change(0, 0, 0);
    }
    public GameObject ResetButton;
    public Quaternion thisOBject;
    public void ResetSpawner()
    {
       
        if (thisOBject.x >= 0.3f|| thisOBject.y >= 0.3f|| thisOBject.z >= 0.3f)
        {
            ResetButton.SetActive(true);
        }
    }
}
