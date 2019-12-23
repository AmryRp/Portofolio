using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   [SerializeField]
    private HealthBar Health;
    public Animator myAnim;
    private static GameManager instance;
    public static GameManager MyInst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    public string PlayerName;
    private void Start()
    {
        if (PlayerName != null)
        {
            PlayerName = NameSaver.Instance.mySelf.text;
        }
        else 
        {
            SceneManager.LoadScene(0);
        }
        myAnim.SetTrigger("PopUp");
        Health.SetSize(1f);
        Sambutan.text = "Selamat Datang: " + PlayerName + "  " +
            "Klik Roda Untuk Bermain";
        ScorePause.text = score.ToString();
    }
    private void Awake()
    {
        instance = this;
        score = 0;
        bestScore = PlayerPrefs.GetInt("HighScore",0);
    }
    public int score;
    public int bestScore;
    public void calculateScore()
    {
        bestScore = score;
        PlayerPrefs.SetInt("HighScore", bestScore);
    }

    public void Reset()
    {
        HighScoreTable.MyInstance.AddHighscoreEntry(score, PlayerName);
        HealthBar.MyInst.health = 1;
        HealthBar.MyInst.mati = false;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        PlayerPrefs.DeleteKey("Pelanggaran");
        DaftarPelanggaran.MyInstance.DefaultData();
    }

    public Text NamaRambu, Deskripsi;
    public Image Lambang;
    public void RambuCollider(string NR, string DS,Sprite GB )
    {
        NamaRambu.text = NR;
        Deskripsi.text = DS;
        Lambang.sprite = GB;
    }
    [SerializeField]
    private Text Sambutan;
    [SerializeField]
    private Text ScorePause;

    [SerializeField]
    private BackgroundKiri[] backgroundsElement;
    private void Update()
    {
        if (true)
        {
            foreach (BackgroundKiri element in backgroundsElement)
            {
                element.Move();
            }
        }
    }
}
