using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cryscript : MonoBehaviour
{
    public GameObject itself;
    public Transform crystal;
    public Transform target;
    private void Start() 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update() 
    {
        var distance = Vector3.Distance(crystal.position, target.position);
        if(distance <= 2)
        {
            playermovement.Instance.playerhealth -= 25;
            Destroy(itself);
        }

    }
}
