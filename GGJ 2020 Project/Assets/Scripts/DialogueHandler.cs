using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

public class DialogueHandler : MonoBehaviour
{

    public string[] dialogue;
    public int[] spriteChangePos;
    public int spriteAppear;
    public string[] spriteExpressions;
    public TextMeshProUGUI text;
    public bool makingChoice;
    public int[] choicePos;
    public SpriteRenderer character;
    public SpriteAtlas chars;
    private int currentLine;
    private int currentExpression;
    private int currentChoice;
    

    // Start is called before the first frame update
    void Start()
    {
        currentLine = 0;
        currentExpression = 0;
        currentChoice = 0;
        text.text = dialogue[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (character.color.a == 0f && currentLine == spriteAppear)
        {
            character.color = new Color(1f, 1f, 1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !makingChoice)
        {
            if (currentLine < dialogue.Length)
            {
                currentLine++;
                text.text = dialogue[currentLine];
                Debug.Log(currentExpression);
               if (currentLine == spriteChangePos[currentExpression])
               {
                    character.sprite = chars.GetSprite(spriteExpressions[currentExpression]);
                    currentExpression++;
               }
               if (currentLine == choicePos[currentChoice])
               {
                    makingChoice = true;
               }
            }
        }
        else if (makingChoice)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentLine++;
                text.text = dialogue[currentLine];
                currentChoice++;
                makingChoice = false;
                currentLine++;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentLine+= 2;
                text.text = dialogue[currentLine];
                currentChoice++;
                makingChoice = false;
            }
        }
        else
        {
            SaveData.global.heartLevel++;
            SceneManager.LoadScene("Cutscene");
        }
    }
}
