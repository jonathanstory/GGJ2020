﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (File.Exists(Application.persistentDataPath + "/globalVars.dat") && SaveData.global.scene != "MainMenu")
        {
            SceneManager.LoadScene(SaveData.global.scene);
        }
        else
        {
            SceneManager.LoadScene("OpeningScene");
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
