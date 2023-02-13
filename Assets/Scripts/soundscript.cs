using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundscript : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    public AudioSource sound;
    public int sidx;
    // Start is called before the first frame update
    void Start()
    {
        sidx = PlayerPrefs.GetInt("sound");
        if(sidx == 0)
        {
            sound.Play();
        }
        else
        {
            sound.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void offsound()
    {
        sound.Stop();
        on.SetActive(true);
        off.SetActive(false);
        PlayerPrefs.SetInt("sound",1);
    }
    public void onsound()
    {
        sound.Play();
        off.SetActive(true);
        on.SetActive(false);
        PlayerPrefs.SetInt("sound" , 0); 
    }
}
