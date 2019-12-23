using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public int levelToLoad;
    // Use this for initialization
    public GameObject LoadingScreen;
    public Slider loadingBar;
    public Text loadtext;
    [SerializeField]
    private float lerpSpeed;
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAstnchronously(sceneIndex));
    }
    IEnumerator LoadAstnchronously(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.value = progress;
            loadtext.text = progress * 100f + "%";
            yield return null;

        }
    }
}
