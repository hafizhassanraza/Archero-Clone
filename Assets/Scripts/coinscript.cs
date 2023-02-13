using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinscript : MonoBehaviour
{
    public GameObject coin;
    public GameObject player;
    private float distance;
    
    private void Start() 
    {
        distance = Vector3.Distance(player.transform.position, coin.transform.position);
    }

    private void Update() 
    {
        coin.transform.Rotate(0, 50 * Time.deltaTime, 0);    
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.transform.tag == "Player")
        {
            Destroy(coin);
            coinuiscript.Instance.coinss += 1;
        }        
    }
}
