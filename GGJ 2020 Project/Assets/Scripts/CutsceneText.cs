using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CutsceneText : MonoBehaviour
{
    public string[] cutscene;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = cutscene[0];
        StartCoroutine(ShowText(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowText(int i)
    {
        while (i < cutscene.Length)
        {
            while (text.color.a < 1f)
            {
                text.color += new Color(0.0f, 0.0f, 0.0f, 0.025f);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(2f);
            while (text.color.a > 0f)
            {
                text.color -= new Color(0.0f, 0.0f, 0.0f, 0.025f);
                yield return new WaitForSeconds(0.01f);
            }
            i++;
            text.text = cutscene[i];
            yield return new WaitForSeconds(2f);
        }
    }

}
