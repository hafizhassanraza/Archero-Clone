using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject levelselector;
    public void startgame()
    {
        levelselector.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void l1()
    {
        SceneManager.LoadScene("level1");
    }
    public void l2()
    {
        SceneManager.LoadScene("level2");
    }
    public void l3()
    {
        SceneManager.LoadScene("level3");
    }
    public void l4()
    {
        SceneManager.LoadScene("level4");
    }
    public void l5()
    {
        SceneManager.LoadScene("level5");
    }
}
