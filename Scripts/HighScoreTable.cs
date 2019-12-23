using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private static HighScoreTable instance;
    public static HighScoreTable MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HighScoreTable>();
            }
            return instance;
        }
    }
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    private List<HighscoreEntry> HighscoreEntryList;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighscoreTable"))
        {
            loadData();
        }
        else 
        {
            entryContainer = transform.Find("Isi");
            entryTemplate = entryContainer.Find("ListHighScore");
            HighscoreEntryList = new List<HighscoreEntry>(){
            new HighscoreEntry{ score = 1000, name = "Amry" },
            new HighscoreEntry{ score = 999, name = "Athok" },
            new HighscoreEntry{ score = 998, name = "Dimas" },
                           };

            for (int i = 0; i < HighscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < HighscoreEntryList.Count; j++)
                {
                    if (HighscoreEntryList[j].score > HighscoreEntryList[i].score)
                    {
                        HighscoreEntry tmp = HighscoreEntryList[i];
                        HighscoreEntryList[i] = HighscoreEntryList[j];
                        HighscoreEntryList[j] = tmp;
                    }
                }
            }
            highscoreEntryTransformList = new List<Transform>();
            foreach (HighscoreEntry highscoreEntry in HighscoreEntryList)
            {
                CreateHighscoreEntryTr(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
            string json = JsonUtility.ToJson(HighscoreEntryList);
            PlayerPrefs.SetString("HighscoreTable", json);
            PlayerPrefs.Save();
            
        }
    }

    public void loadData()
    {

        entryContainer = transform.Find("Isi");
        entryTemplate = entryContainer.Find("ListHighScore");

        string jsonstring = PlayerPrefs.GetString("HighscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonstring);
        
            entryTemplate.gameObject.SetActive(false);

            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
                {
                    if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                    {
                        HighscoreEntry tmp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = tmp;
                    }
                }
            }
            highscoreEntryTransformList = new List<Transform>();
            foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
            {
                CreateHighscoreEntryTr(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
        

    }
    private void CreateHighscoreEntryTr(HighscoreEntry hsE, Transform Container, List<Transform> TL)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, Container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * TL.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = TL.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        entryTransform.Find("Urutan").GetComponent<Text>().text = rankString;
        int score = hsE.score;
        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();
        string name = hsE.name;
        entryTransform.Find("Nama").GetComponent<Text>().text = name;

        entryTransform.Find("BG").gameObject.SetActive(rank % 2 ==1);
        if (rank == 1)
        {
            entryTransform.Find("Urutan").GetComponent<Text>().color = Color.green;
            entryTransform.Find("Score").GetComponent<Text>().color = Color.green;
            entryTransform.Find("Nama").GetComponent<Text>().color = Color.green;
        }
        TL.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string NM) 
    {
            HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = NM };

            string jsonString = PlayerPrefs.GetString("HighscoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            highscores.highscoreEntryList.Add(highscoreEntry);

            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("HighscoreTable", json);
            PlayerPrefs.Save();
      
    }
    private class Highscores 
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
