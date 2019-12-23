using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DaftarPelanggaran : MonoBehaviour
{
    private static DaftarPelanggaran instance;
    public static DaftarPelanggaran MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DaftarPelanggaran>();
            }
            return instance;
        }
    }
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> TempatPelanggaran;
    private List<EntryPelanggaran> DaftarPelanggaranPlayer;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Pelanggaran"))
        {
            PlayerPrefs.DeleteKey("Pelanggaran");
            DefaultData();
            loadData();
            
        }
       
        else
        {
            DefaultData();

        }
    }
    public void DefaultData()
    {
        entryContainer = transform.Find("Isi");
        entryTemplate = entryContainer.Find("ListPelanggaran");
        DaftarPelanggaranPlayer = new List<EntryPelanggaran>(){
            new EntryPelanggaran{ Pelanggaran = "tidak ada", Score = 0 },  };
        for (int i = 0; i < DaftarPelanggaranPlayer.Count; i++)
        {
            for (int j = i + 1; j < DaftarPelanggaranPlayer.Count; j++)
            {
                if (DaftarPelanggaranPlayer[j].Score > DaftarPelanggaranPlayer[i].Score)
                {
                    EntryPelanggaran tmp = DaftarPelanggaranPlayer[i];
                    DaftarPelanggaranPlayer[i] = DaftarPelanggaranPlayer[j];
                    DaftarPelanggaranPlayer[j] = tmp;
                }
            }
        }
        TempatPelanggaran = new List<Transform>();
        foreach (EntryPelanggaran highscoreEntry in DaftarPelanggaranPlayer)
        {
            CreateHighscoreEntryTr(highscoreEntry, entryContainer, TempatPelanggaran);
        }
        string json = JsonUtility.ToJson(DaftarPelanggaranPlayer);
        PlayerPrefs.SetString("Pelanggaran", json);
        PlayerPrefs.Save();
    }
    public void loadData()
    {

        entryContainer = transform.Find("Isi");
        entryTemplate = entryContainer.Find("ListPelanggaran");

        string jsonstring = PlayerPrefs.GetString("Pelanggaran");
        Pelanggaran highscores = JsonUtility.FromJson<Pelanggaran>(jsonstring);
        
            entryTemplate.gameObject.SetActive(false);
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].Score > highscores.highscoreEntryList[i].Score)
                {
                    EntryPelanggaran tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        TempatPelanggaran = new List<Transform>();
            foreach (EntryPelanggaran highscoreEntry in highscores.highscoreEntryList)
            {
                CreateHighscoreEntryTr(highscoreEntry, entryContainer, TempatPelanggaran);
            }
    }
    private void CreateHighscoreEntryTr(EntryPelanggaran hsE, Transform Container, List<Transform> TL)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, Container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * TL.Count);
        entryTransform.gameObject.SetActive(true);
        
        int score = hsE.Score;
        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();
        string name = hsE.Pelanggaran;
        entryTransform.Find("Pelanggaran").GetComponent<Text>().text = name;
        TL.Add(entryTransform);
    }

    public void TilangPelanggaran(string score, int NM) 
    {
        EntryPelanggaran highscoreEntry = new EntryPelanggaran { Pelanggaran = score, Score = NM };

            string jsonString = PlayerPrefs.GetString("Pelanggaran");
            Pelanggaran highscores = JsonUtility.FromJson<Pelanggaran>(jsonString);

            highscores.highscoreEntryList.Add(highscoreEntry);

            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("Pelanggaran", json);
            PlayerPrefs.Save();
        loadData();
    }

    private class Pelanggaran
    {
        public List<EntryPelanggaran> highscoreEntryList;
    }
    [System.Serializable]
    private class EntryPelanggaran
    {
        public int Score;
        public string Pelanggaran;
        
    }
    
}
