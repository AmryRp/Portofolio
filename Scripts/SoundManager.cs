using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }
            return instance;
        }
    }

    [SerializeField]
    private Slider VolumeBGM;
    [SerializeField]
    private Toggle ToggleBGM;
    [SerializeField]
    private Slider VolumeSFX;
    [SerializeField]
    private Toggle ToggleSFX;
    [Header("LIST ")]
    [SerializeField]
    public GameObject[] BGM;
    [SerializeField]
    public GameObject[] SFX;

    public GameObject[] BGM1 { get => BGM; set => BGM = value; }
    public GameObject[] SFX1 { get => SFX; set => SFX = value; }
    public int interval = 6;

    private void Start()
    {
        VolumeBGM.onValueChanged.AddListener(BGMValue);
        VolumeSFX.onValueChanged.AddListener(SFXValue);
        ToggleBGM.onValueChanged.AddListener(BGMToggle);
        ToggleSFX.onValueChanged.AddListener(SFXToggle);

    }
    public void Update()
    {
        updateList();
        UpdateSetting();
        if (Time.frameCount % interval == 0)
        {

        }

    }
    public void UpdateSetting()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            VolumeBGM.value = PlayerPrefs.GetFloat("MusicVolume");
            VolumeSFX.value = PlayerPrefs.GetFloat("SFXVolume");
            if (PlayerPrefs.HasKey("BGM"))
            {
                ToggleBGM.isOn = PlayerPrefs.GetInt("BGM") == 1 ? true : false; ;
                
            }
            else
            {
                ToggleBGM.isOn = true;
            }
            if (PlayerPrefs.HasKey("SFX"))
            {
                ToggleSFX.isOn = PlayerPrefs.GetInt("SFX") == 1 ? true : false; ;
            }
            else
            {
                ToggleSFX.isOn = true;
            }
        }
    }
    public void updateList()
    {
        BGM = GameObject.FindGameObjectsWithTag("BGM");
        SFX = GameObject.FindGameObjectsWithTag("SFX");
        if (BGM1.Length != 0)
        {
            if (BGM1 != null)
            {

                for (int i = 0; i < BGM1.Length; i++)
                {
                    BGM1[i].GetComponent<AudioSource>();
                    BGM1[i].GetComponent<AudioSource>().volume = VolumeBGM.value;

                }
                ToggleBGM.isOn = PlayerPrefs.GetInt("BGM") == 1 ? true : false;
            }
        }
        if (SFX1.Length != 0)
        {
            if (SFX1 != null)
            {
                for (int i = 0; i < SFX1.Length; i++)
                {
                    SFX1[i].GetComponent<AudioSource>();
                    SFX1[i].GetComponent<AudioSource>().volume = VolumeSFX.value;
                }
                ToggleBGM.isOn = PlayerPrefs.GetInt("BGM") == 1 ? true : false;
            }
        }

    }

    public void BGMValue(float value)
    {

        for (int i = 0; i < BGM1.Length; i++)
        {

            BGM1[i].GetComponent<AudioSource>().volume = VolumeBGM.value;

        }
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }
    public void SFXValue(float value)
    {
        for (int i = 0; i < SFX1.Length; i++)
        {
            SFX1[i].GetComponent<AudioSource>().volume = VolumeSFX.value;
        }
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();

    }

    public void BGMToggle(bool value)
    {
        value = ToggleBGM.isOn;
        if (value ? false : true)
        {
            for (int i = 0; i < BGM1.Length; i++)
            {
                BGM1[i].GetComponent<AudioSource>().Stop();
            }

        }
        else
        {
            for (int i = 0; i < BGM1.Length; i++)
            {
                BGM1[i].GetComponent<AudioSource>().Play();
            }

        }
        PlayerPrefs.SetInt("BGM", value ? 1 : 0);
        PlayerPrefs.Save();

    }
    public void SFXToggle(bool value)
    {
        value = ToggleSFX.isOn;
        if (value ? false : true)
        {
            for (int i = 0; i < SFX1.Length; i++)
            {
                SFX1[i].GetComponent<AudioSource>().Stop();
            }

        }
        else
        {
            for (int i = 0; i < SFX1.Length; i++)
            {
                SFX1[i].GetComponent<AudioSource>().Play();
            }
            //PlayerPrefs.SetInt("SFX", ToggleSFX.isOn ? 1 : 0);
            //PlayerPrefs.Save();
        }
        PlayerPrefs.SetInt("SFX", value ? 1 : 0);
        PlayerPrefs.Save();
    }
}
