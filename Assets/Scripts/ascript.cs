using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascript : MonoBehaviour
{
    public GameObject arrow;
     void OnTriggerEnter(Collider enemy)
    {
      if(enemy.gameObject.CompareTag("enemy"))
      {
        Destroy(arrow);
      }
    }
}
