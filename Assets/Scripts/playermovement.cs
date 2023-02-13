using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class playermovement : MonoBehaviour
{
    public float playerhealth = 100f;
    public bool isplayeralive = true ;
    
    public float movespeed = 20.0f;
    public GameObject[] skins;
    private int skidx;
    public GameObject[] weapons;
    private int wpxidx;
    public GameObject pmenu;
    public float deathtimer = 1f;

    public static playermovement Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<playermovement>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("playermovement");
                    instance = instanceContainer.AddComponent<playermovement>();
                }
            }
            return instance;
        }
    }
    private static playermovement instance;

    Rigidbody rb;

    void Start() 
    {
        Time.timeScale = 1;
        skidx = PlayerPrefs.GetInt("skin");
        skins[skidx].SetActive(true);
        wpxidx = PlayerPrefs.GetInt("weapon");
        weapons[wpxidx].SetActive(true);
        rb = GetComponent<Rigidbody>();       
    }
    void FixedUpdate() 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if(isplayeralive == true)

        {

        rb.velocity = new Vector3(moveHorizontal * movespeed *Time.deltaTime, rb.velocity.y , moveVertical * movespeed * Time.deltaTime);

        if(JoyStickMovement.Instance.joyVec.x != 0 || JoyStickMovement.Instance.joyVec.z != 0)
        {
        rb.velocity = new Vector3(JoyStickMovement.Instance.joyVec.x *movespeed , rb.velocity.y , JoyStickMovement.Instance.joyVec.y * movespeed);
        rb.rotation = Quaternion.LookRotation(new Vector3(JoyStickMovement.Instance.joyVec.x ,0, JoyStickMovement.Instance.joyVec.y));
        }
        if(playerhealth <= 0f)
        {
            if(isplayeralive == true)
            {
            JoyStickMovement.Instance.anim.SetTrigger("Death");
            isplayeralive = false;
            }

            {
                deathtimer -= Time.deltaTime;
                if(deathtimer <= 0)
                {
                    pmenu.SetActive(true);
                }
            }
            
        }
        
        }
        else
        {
            deathtimer-= Time.deltaTime;
            if(deathtimer <= 0){
                pmenu.SetActive(true);
            }
        }
    }
    void OnTriggerEnter(Collider Enemy)
    {
      /*if(Enemy.gameObject.CompareTag("enemy"))
      {
        enemyai.Instance.animzombo.SetTrigger("isattacking");
      }*/
      if(Enemy.gameObject.CompareTag("weapon"))
      {
          playerhealth -= 20f  ;
      }
    }
}
