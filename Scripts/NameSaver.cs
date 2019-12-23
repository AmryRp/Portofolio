using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameSaver : MonoBehaviour
{
    public static NameSaver Instance;
    public InputField NamaUser;
    public Text mySelf;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        mySelf = GetComponent<Text>();
    }
    public void LoadName()
    {
        mySelf.text = NamaUser.text ;
    }
}
