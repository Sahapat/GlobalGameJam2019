using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Selector : MonoBehaviour
{
    [SerializeField] Image fadeImage = null;
    [SerializeField] GameObject optionUi = null;
    [SerializeField] float delayBeforeLoad = 0.8f;

    bool trigger = false;
    int sceneToLoad = 0;
    private AudioSource m_audioSource = null;
    void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        StartCoroutine(FadeIn());
        UpdateSave();
    }
    void Start()
    {
        /* for(int i=0;i<PlayerData.levelData.Count;i++)
        {
            print("Level"+PlayerData.levelData[i].level+": "+PlayerData.levelData[i].score+" "+PlayerData.levelData[i].isPass);
        } */
    }
    void Update()
    {
        m_audioSource.volume = PlayerData.volume;
    }
    private IEnumerator FadeIn()
    {
        fadeImage.color = new Color(0,0,0,1);
        while(fadeImage.color.a > 0.01f)
        {
            fadeImage.color = Color.Lerp(fadeImage.color,new Color(0,0,0,0),0.1f);
            yield return null;
        }
        fadeImage.color = new Color(0,0,0,0);
    }
    private IEnumerator FadeOut()
    {
        fadeImage.color = new Color(0,0,0,0);
        while(fadeImage.color.a < 0.99f)
        {
            fadeImage.color = Color.Lerp(fadeImage.color,new Color(0,0,0,1),0.1f);
            yield return null;
        }
        fadeImage.color = new Color(0,0,0,1);
    }
    public void DoFadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }
    public void DoFadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut());
    }
    public void ShowOption()
    {
        optionUi.SetActive(true);
    }
    public void CloseOption()
    {
        optionUi.SetActive(false);
    }
    public void LoadScene(int index)
    {
        if(trigger)return;

        trigger=true;
        sceneToLoad = index;
        DoFadeOut();
        Invoke("DoLoad",delayBeforeLoad);
    }
    void DoLoad()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    void UpdateSave()
    {
        var temp = PlayerPrefs.HasKey("Volume");
        if (temp)
        {
            PlayerData.volume = PlayerPrefs.GetFloat("Volume", 0f);
        }
        else
        {
            PlayerData.volume = 0.5f;
        }
        int Iterator = 1;
        while (true)
        {
            var keyName = "Level" + Iterator;
            var isHave = PlayerPrefs.HasKey(keyName);
            if (!isHave) break;
            var dataToAdd = new playerLevelData();
            dataToAdd.level = Iterator;
            dataToAdd.score = PlayerPrefs.GetInt(keyName,0);
            dataToAdd.isPass = (PlayerPrefs.GetInt(keyName+"Pass",0) == 0)?false:true;
            if (Iterator == 1)
            {
                if (PlayerData.levelData == null)
                {
                    PlayerData.levelData = new List<playerLevelData>();
                }
                else
                {
                    PlayerData.levelData.Clear();
                }
            }
            PlayerData.levelData.Add(dataToAdd);
            Iterator++;
        }
    }
}
