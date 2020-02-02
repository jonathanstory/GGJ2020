using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{

    public SpriteRenderer heartContainer_0;
    public SpriteRenderer heartContainer_1;
    public SpriteAtlas containers;

    // Start is called before the first frame update
    void Start()
    {
        heartContainer_0.sprite = containers.GetSprite("hearts_" + (SaveData.global.heartLevel));
        heartContainer_1.sprite = containers.GetSprite("hearts_" + (SaveData.global.heartLevel + 1));
        SaveData.global.heartLevel++;
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeIn()
    {
        while (heartContainer_0.color.a > 0f)
        {
            heartContainer_0.color -= new Color(0.0f, 0.0f, 0.0f, 0.025f);
            heartContainer_1.color += new Color(0.0f, 0.0f, 0.0f, 0.025f);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2f);
        while (heartContainer_1.color.a > 0f)
        {
            heartContainer_1.color -= new Color(0.0f, 0.0f, 0.0f, 0.025f);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(GetScene());
    } 

    string GetScene()
    {
        switch (SaveData.global.heartLevel)
        {
            case 1:
                SaveData.global.achievements[1] = true;
                return "ScromplesScene1";
            case 2:
                SaveData.global.achievements[2] = true;
                return "MikeScene1";
            case 3:
                SaveData.global.achievements[3] = true;
                return "DominiqueScene1";
            case 4:
                SaveData.global.achievements[4] = true;
                return "DadScene1";
            case 5:
                SaveData.global.achievements[5] = true;
                return "MainMenu";
            default:
                return "MainMenu";
        }
    }
}
