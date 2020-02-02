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
    public Scene nextScene;

    // Start is called before the first frame update
    void Start()
    {
        heartContainer_0.sprite = containers.GetSprite("hearts_" + SaveData.global.heartLevel);
        heartContainer_1.sprite = containers.GetSprite("hearts_" + (SaveData.global.heartLevel + 1));
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
    } 
}
