using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptforprefs : MonoBehaviour
{
    public GameObject[] skins;
    public GameObject[] weapons;
    private int skinindex = 0;
    private int weaponindex = 0;
    public bool isskin2 = false;
    public bool isskin3 = false;
    public bool iscrossbow = false;
    public Button skinb1;
    public Button skinb2;
    public Button croosbb;

    private void Start()
    {

    }
    private void Update() 
    {
        PlayerPrefs.SetInt("skin", skinindex);
        PlayerPrefs.SetInt("weapon",weaponindex);        
    }
    public void nextskin()
    {
        if(skinindex < 1 && isskin2 == true)
        {
        skinindex += 1;
        skins[skinindex].SetActive(true);
        skins[skinindex-1].SetActive(false);
        }
        if(skinindex < 2 && isskin3 == true)
        {
            skinindex += 1;
            skins[skinindex].SetActive(true);
            skins[skinindex-1].SetActive(false);
        }
    }
    public void prevskin()
    {
        if(skinindex > 0)
        {
        skinindex -=1;
        skins[skinindex].SetActive(true);
        skins[skinindex+1].SetActive(false);
        }
    }
    public void nextweapon()
    {
        if(weaponindex < 1 && iscrossbow == true)
        {
        weaponindex += 1;
        weapons[weaponindex].SetActive(true);
        weapons[weaponindex-1].SetActive(false);
        }      
    }
    public void prevweapon()
    {
        if(weaponindex > 0)
        {
        weaponindex -= 1;
        weapons[weaponindex].SetActive(true);
        weapons[weaponindex+1].SetActive(false);
        }   
    }
    public void skin2()
    {
        if(coinuiscript.Instance.coinss >= 50 && isskin2 == false)
        {
        isskin2 = true;
        coinuiscript.Instance.coinss -= 50;
        }
    }
    public void skin3()
    {
        if(isskin2 == true && coinuiscript.Instance.coinss >=100 && isskin3 == false)
        {
        isskin3 = true;
        }
    }
    public void crossbow()
    {
        if(coinuiscript.Instance.coinss >= 50 && iscrossbow == false)
        {
        iscrossbow = true;
        coinuiscript.Instance.coinss -= 50;
        }
    }
}
