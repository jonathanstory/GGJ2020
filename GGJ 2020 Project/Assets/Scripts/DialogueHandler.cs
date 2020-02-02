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
            
            else
            {
                switch (SceneManager.GetActiveScene().name)
                {
                    case "KylieScene1":
                        SaveData.global.achievements[1] = true;
                        SceneManager.LoadScene("ScromplesScene1");
                        break;
                    case "ScromplesScene1":
                        SaveData.global.achievements[2] = true;
                        SceneManager.LoadScene("MikeScene1");
                        break;
                    case "MikeScene1":
                        SaveData.global.achievements[3] = true;
                        SceneManager.LoadScene("DominiqueScene1");
                        break;
                    case "DominiqueScene1":
                        SaveData.global.achievements[4] = true;
                        SceneManager.LoadScene("DadScene1");
                        break;
                    case "DadScene1":
                        SaveData.global.achievements[5] = true;
                        SceneManager.LoadScene("MainMenu");
                        break;
                    default:
                        SceneManager.LoadScene("MainMenu");
                        break;
                }
            }
            Debug.Log(currentExpression);
        }
        else if (makingChoice)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentLine++;
                if (currentLine == spriteChangePos[currentExpression])
                {
                    character.sprite = chars.GetSprite(spriteExpressions[currentExpression]);
                    currentExpression++;
                }
                text.text = dialogue[currentLine];
                currentChoice++;
                makingChoice = false;
                currentLine++;
                if (currentLine == spriteChangePos[currentExpression])
                {
                    character.sprite = chars.GetSprite(spriteExpressions[currentExpression]);
                    currentExpression++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentLine++;
                if (currentLine == spriteChangePos[currentExpression])
                {
                    character.sprite = chars.GetSprite(spriteExpressions[currentExpression]);
                    currentExpression++;
                }
                currentLine++;
                if (currentLine == spriteChangePos[currentExpression])
                {
                    character.sprite = chars.GetSprite(spriteExpressions[currentExpression]);
                    currentExpression++;
                }
                currentChoice++;
                text.text = dialogue[currentLine];
                makingChoice = false;
            }
        }
        
    }
}
