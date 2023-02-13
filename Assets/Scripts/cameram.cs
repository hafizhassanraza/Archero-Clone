using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameram : MonoBehaviour
{
    public Transform pilayerT;
    public float SmoothSpeed = 0.125f;
    public Vector3 offset;
    bool MoveCamera = true;

    public void FixedUpdate () {
        transform.LookAt(pilayerT);

    if(MoveCamera == true){

       Vector3 desiredPosition = new Vector3(0, pilayerT.position.y + offset.y, pilayerT.position.z + offset.z);
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
        transform.position = SmoothedPosition;
    }


    /*if (transform.position.z >= 2f)
    {
        MoveCamera = false;
    }*/
    
}
}
