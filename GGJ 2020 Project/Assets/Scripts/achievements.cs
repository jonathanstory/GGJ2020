using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class achievements : MonoBehaviour
{
    public int index;
    public TextMeshProUGUI display;
    public string flavorText;
    public Sprite colorPicture;
    private Image achievement;

    // Start is called before the first frame update
    void Start()
    {
        achievement = GetComponent<Image>();
        if (SaveData.global.achievements[index])
        {
            achievement.sprite = colorPicture;
            achievement.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayText()
    {
        if (SaveData.global.achievements[index])
        {
            display.text = flavorText;
        }
        else
        {
            display.text = "??????";
        }
    }
}
