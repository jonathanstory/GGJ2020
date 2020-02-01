using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{

    /*
     * Handler for data that we need to keep track of throughout the game
     * e.g. name, choices made.
     * Will also handle saving
     */

    public static SaveData global;
    
    public string charName;
    public Dictionary<int, bool> achievements;

    private void Awake()
    {
        //enforce singleton
        if (global == null)
        {
            DontDestroyOnLoad(gameObject);
            global = this;
        }
        else if (global != this)
        {
            Destroy(gameObject);
        }

        achievements = new Dictionary<int, bool>();
        achievements.Add(1, false);
        achievements.Add(2, true);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
