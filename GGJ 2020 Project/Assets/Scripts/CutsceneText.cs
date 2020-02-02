using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CutsceneText : MonoBehaviour
{
    public string[] cutscene;
    private TextMeshProUGUI text;
    public TextMeshProUGUI promptText;
    private TMP_InputField input;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = cutscene[0];
        input = promptText.GetComponentInChildren<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("KylieScene1");
        }
    }

    public void StartCutscene()
    {
        cutscene[0] = "Hello, " + SaveData.global.charName + ". ";
        if (SaveData.global.charName.ToLower() == "asshole")
        {
            cutscene[1] = "You know what this is about already.";
        }
        StartCoroutine(ShowText(0));
        
    }

    public void GetName(string str)
    {
        SaveData.global.charName = input.text;
        if (SaveData.global.charName.ToLower() == "asshole")
        {
            SaveData.global.achievements[6] = true;
        }
        StartCoroutine(Fade());
        StartCutscene();
    }

    IEnumerator Fade()
    {
        while (promptText.color.a > 0f)
        {
            promptText.color -= new Color(0.0f, 0.0f, 0.0f, 0.05f);
            input.image.color -= new Color(0.0f, 0.0f, 0.0f, 0.05f);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
    }

    IEnumerator ShowText(int i)
    {
        yield return new WaitForSeconds(3f);
        while (i < cutscene.Length)
        {
            text.text = cutscene[i];
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
            yield return new WaitForSeconds(2f);
            if (i == 2 && SaveData.global.charName.ToLower().Equals("asshole"))
            {
                break;
            }
        }
        SceneManager.LoadScene("KylieScene1");
    }



}
