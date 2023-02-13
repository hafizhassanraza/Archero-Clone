using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coinuiscript : MonoBehaviour
{
    public static coinuiscript Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<coinuiscript>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("coinsuiscriptt");
                    instance = instanceContainer.AddComponent<coinuiscript>();
                }
            }
            return instance;
        }
    }
    private static coinuiscript instance;
    public Text nocoins;
    public int coinss;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        coinss = PlayerPrefs.GetInt("coins");
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        nocoins.text = ((int)coinss).ToString();
        PlayerPrefs.SetInt("coins", coinss);
    }
}
