using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject pmenu;
    public void pause()
    {
        Time.timeScale = 0;
        pmenu.SetActive(true);
    }
    public void play()
    {
        Time.timeScale = 1;
        pmenu.SetActive(false);
    }
    public void restart()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
