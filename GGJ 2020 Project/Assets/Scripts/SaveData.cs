using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{

    /*
     * Handler for data that we need to keep track of throughout the game
     * e.g. name, choices made.
     * Will also handle saving
     */

    public static SaveData global;
    
    public Dictionary<int, bool> achievements = new Dictionary<int, bool>();
    public int heartLevel = 0;
    public string scene;


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

        if (!File.Exists(Application.persistentDataPath + "/globalVars.dat"))
        {
            for (int i = 1; i <= 7; i++)
            {
                if (!achievements.ContainsKey(i))
                {
                    achievements.Add(i, false);
                }
            }
        }
        else
        {
            Load();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Save();
            SceneManager.LoadScene("MainMenu");
        }

        if (!SceneManager.GetActiveScene().name.Equals("MainMenu") && !SceneManager.GetActiveScene().name.Equals(scene))
        {
            scene = SceneManager.GetActiveScene().name;
            Save();
        }
    }

    public void Load()
    {
        //Loads file, duh

        //If the game stuff exists, then it will be loaded
        if (File.Exists(Application.persistentDataPath + "/globalVars.dat"))
        {
            //We need a binary formatter to read the binary text
            //Then we create a reference to the global variables file
            //Next we create a reference to PersistentData and write the file contents to it
            //Finally, we close the file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/globalVars.dat", FileMode.Open);
            PersistentData data = (PersistentData)bf.Deserialize(file);
            file.Close();

            achievements = data.achievements;
            heartLevel = data.heartLevel;
            scene = data.scene;
            Debug.Log("Load successful");
        }
    }

    public void Save()
    {
        //Creates a binary formatter object so we can write our data in binary
        //Then creates the file we'll save stuff in
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/globalVars.dat");

        //Creates a new reference to the PersistentData class
        //Writes the data to the file, then closes it
        PersistentData data = new PersistentData();
        data.achievements = achievements;
        data.heartLevel = heartLevel;
        if (!scene.Equals("MainMenu"))
        {
            data.scene = scene;
        }
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Save successful");
    }

    public void ResetGame()
    {
        if (File.Exists(Application.persistentDataPath + "/globalVars.dat"))
        {
            File.Delete(Application.persistentDataPath + "/globalVars.dat");
            for (int i = 0; i < achievements.Count; i++)
            {
                achievements[i] = false;
            }
            heartLevel = 0;
            scene = "MainMenu";
            
            Debug.Log("Delete successful");
        }
        else
        {
            Debug.Log("File doesn't exist");
        }

    }

}
[System.Serializable]
//Creates a new, clean class that is used simply to hold the variables we need to save.
//It's done this way because if you do it in a class w/ methods and such, weird things happen
class PersistentData : System.Object
{
    public string charName;
    public Dictionary<int, bool> achievements = new Dictionary<int, bool>();
    public int heartLevel = 0;
    public string scene;
}
