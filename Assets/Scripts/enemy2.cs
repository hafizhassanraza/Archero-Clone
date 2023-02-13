using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public GameObject itself;
    
 private Transform  target;
 public float lichhealth = 100f ;
 private float range = 35f;
 public GameObject crystal;
private Vector3 direction;
 public Transform mytransform;
 public bool islichalive = true;
 public Animator lichanim;
 public GameObject coin;
 public float deathtimer = 3;
 public float timeRemaining = 2;
 public Transform coinref;

  public static enemy2 Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<enemy2>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("enemy2");
                    instance = instanceContainer.AddComponent<enemy2>();
                }
            }
            return instance;
        }
    }
    private static enemy2 instance;

    private void Awake()
 {
     target = GameObject.FindWithTag("Player").transform; //target the player
     mytransform = transform; //cache transform data for easy access/preformance
 }
    void Update()
    {
        if(deathtimer <= 0)
        {
            Destroy(itself);
        }
        if(lichhealth <= 0)
      {
          if(islichalive == true)
          {
          GameObject coins = Instantiate(coin, coinref.position , Quaternion.identity) as GameObject;
          lichanim.SetTrigger("isdead");
          islichalive = false;
          closestenemy.Instance.EnemyList.Remove(closestenemy.Instance.nearestEnemy);
          }
          else
          {
              deathtimer -= Time.deltaTime;
          }
          
      }

     var distance = Vector3.Distance(mytransform.position, target.position);
 
     if (distance<=range && playermovement.Instance.isplayeralive == true)
     {
         lichanim.SetTrigger("isattacking");
         timeRemaining -= Time.deltaTime;
         if(islichalive==true)
         {
        mytransform.LookAt(target);
        if(timeRemaining <= 0)
        {
        GameObject crystals = Instantiate(crystal, mytransform.position, Quaternion.identity) as GameObject;
        crystals.transform.LookAt(target);
        direction = target.position - mytransform.position;
        crystals.GetComponent<Rigidbody>().AddRelativeForce(direction.normalized * 700, ForceMode.Force);
        timeRemaining = 2;
        }
        }
     }
     else
     {
         lichanim.SetTrigger("isidle");
     }
    }

    
    void OnTriggerEnter(Collider arrow)
    {
      if(arrow.gameObject.CompareTag("arrow"))
      {
        lichhealth -= 20f  ;
      }
    }

}


