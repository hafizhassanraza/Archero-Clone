using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class corridorscript : MonoBehaviour
{
    public GameObject pilayer;
    public GameObject torch;

    // Start is called before the first frame update

    // Update is called once per frame

    /*void Update()
    {
        float distance = Vector3.Distance(pilayer.transform.position , torch.transform.position);
        if(distance < 1)
        {
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            if (sceneName == "level1") 
            {
                SceneManager.LoadScene("level2");
            }
            if(sceneName == "level2")
            {
                SceneManager.LoadScene("level3");
            }
            if(sceneName == "level3")
            {
                SceneManager.LoadScene("level4");
            }
            if(sceneName == "level4")
            {
                SceneManager.LoadScene("mainmenu");
            }
            
        
        }
    }*/
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.transform.tag == "Player")
        {
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            if (sceneName == "level1") 
            {
                SceneManager.LoadScene("level2");
            }
            if(sceneName == "level2")
            {
                SceneManager.LoadScene("level3");
            }
            if(sceneName == "level3")
            {
                SceneManager.LoadScene("level4");
            }
            if(sceneName == "level4")
            {
                SceneManager.LoadScene("level5");
            }
            if(sceneName == "level5")
            {
                SceneManager.LoadScene("mainmenu");
            }
        }        
    }
}
