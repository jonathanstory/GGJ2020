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
    public Dictionary<int, bool> achievements = new Dictionary<int, bool>();
    public int heartLevel = 0;
    public bool kylie_clear = false;
    public bool dog_clear = false;
    public bool mike_clear = false;
    public bool dom_clear = false;
    public bool pants_clear = false;


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

        for (int i = 1; i <= 8; i++)
        {
            if (!achievements.ContainsKey(i))
            {
                achievements.Add(i, true);
            }
        }
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
