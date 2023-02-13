using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyai : MonoBehaviour
{
    public GameObject itself;
    
 private Transform  target; //the enemy's target means player here
 public float zombihealth = 100f ;
 private int moveSpeed = 5; //move speed
 private int rotationSpeed = 3; //speed of turning
 private float range = 35f; //Range within target will be detected
 private float stop = 3.5f;

 public GameObject coin;
 public Animator animzombo;
 public bool isdogoalive = true;
 private float deathtimer = 3;
 public Transform coinref;
 public Transform mytransform;

     public static enemyai Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<enemyai>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("enemyai");
                    instance = instanceContainer.AddComponent<enemyai>();
                }
            }
            return instance;
        }
    }
    private static enemyai instance;

    private void Awake()
 {
     target = GameObject.FindWithTag("Player").transform; //target the player
     mytransform = transform; //cache transform data for easy access/preformance
 }
 void Update ()
  {
      if(deathtimer <= 0)
      {
          Destroy(itself);
      }
      if(zombihealth <= 0)
      {
          if(isdogoalive == true)
          {
          GameObject coins = Instantiate(coin, coinref.position , Quaternion.identity) as GameObject;
          animzombo.SetTrigger("isdead");
          isdogoalive = false;
          closestenemy.Instance.EnemyList.Remove(closestenemy.Instance.nearestEnemy);
          }
          else
          {
              deathtimer -= Time.deltaTime;
          }
      }
     var distance = Vector3.Distance(mytransform.position, target.position);
     if(isdogoalive == true && playermovement.Instance.isplayeralive == true)
     {
     if (distance<=range){
         //look
         mytransform.rotation = Quaternion.Slerp(mytransform.rotation,
         Quaternion.LookRotation(target.position - mytransform.position), rotationSpeed*Time.deltaTime);
         //move
         if(distance > stop )
         {
             mytransform.position += mytransform.forward * moveSpeed * Time.deltaTime;
             animzombo.SetTrigger("isfollowing");
         }
         else
         {
             animzombo.SetTrigger("isattacking");
             playermovement.Instance.playerhealth -= 0.3f;
         }
     }
     else
     {
        animzombo.SetTrigger("isidle");
     }
     }

  }
  void OnTriggerEnter(Collider arrow)
    {
      if(arrow.gameObject.CompareTag("arrow"))
      {
        zombihealth -= 20f  ;
      }
    }

}