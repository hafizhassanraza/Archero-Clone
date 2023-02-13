using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closestenemy : MonoBehaviour
{
    public static closestenemy Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<closestenemy>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("closestenemy");
                    instance = instanceContainer.AddComponent<closestenemy>();
                }
            }
            return instance;
        }
    }

    private static closestenemy instance;
    public Transform Player;

    public List<Transform> EnemyList;

    public Transform nearestEnemy;

    public GameObject nexlevlcorridor;




    void Update()
    {
        float minimumDistance = Mathf.Infinity;
        if(nearestEnemy!=null)
        {
            //nearestEnemy.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        nearestEnemy = null;
        foreach(Transform enemy in EnemyList)
        {
            if(EnemyList != null)
            {
            float distance = Vector3.Distance(Player.position, enemy.position);
            if ( distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = enemy;
            }
            }
        }
        if(nearestEnemy == null)
        {
            nexlevlcorridor.SetActive(true);
        }
        if(nearestEnemy != null)
        {
        //nearestEnemy.GetComponent<MeshRenderer>().material.color = Color.red;
        if(JoyStickMovement.Instance.playerismoving == false && nearestEnemy.transform.position.x < 500)
        {
        Player.LookAt(nearestEnemy);
        }
        }
        
    }
}
