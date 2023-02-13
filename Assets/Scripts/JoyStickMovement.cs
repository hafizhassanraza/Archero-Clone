using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStickMovement : MonoBehaviour
{
    public static JoyStickMovement Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<JoyStickMovement>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("JoyStickMovement");
                    instance = instanceContainer.AddComponent<JoyStickMovement>();
                }
            }
            return instance;
        }
    }

    private static JoyStickMovement instance;
    public GameObject handle;
    
    public GameObject handlecontainer;
    Vector3 stickFirstPosition;
    public Vector3 joyVec;
    public Vector3 joyStickFirstPosition;
    float stickRdius;
    public Animator anim;
    public bool playerismoving = false;
    public Transform ptrans;
    public GameObject arrow;
    public GameObject arrowref;
    private Vector3 direction;
    public float attacktime = 1.3f;
    public bool attacking = false;

    private void Start() 
    {
        stickRdius = handlecontainer.gameObject.GetComponent<RectTransform>().sizeDelta.y/2;
        joyStickFirstPosition = handlecontainer.transform.position;
        
    }
    public void pointDown()
    {
        handlecontainer.transform.position = Input.mousePosition;
        handle.transform.position = Input.mousePosition;
        stickFirstPosition = Input.mousePosition;
        playerismoving = true;
        //anim.SetTrigger("iswalking");
        attacking = false;
    }
    public void drag (BaseEventData baseEventData)
    {
        attacking = false;
        anim.SetTrigger("iswalking");
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 DragPosition = pointerEventData.position;
        joyVec = (DragPosition - stickFirstPosition).normalized;

        float stickDistance = Vector3.Distance(DragPosition , stickFirstPosition);

        if(stickDistance < stickRdius)
        {
            handle.transform.position = stickFirstPosition + joyVec * stickDistance;
        }
        else
        {
            handle.transform.position = stickFirstPosition + joyVec * stickRdius;
        }
    }
    public void drop()
    {
        joyVec = Vector3.zero;
        handlecontainer.transform.position = joyStickFirstPosition;
        handle.transform.position = joyStickFirstPosition;
        playerismoving = false;
        attacking = true;
        
    }
    private void Update() 
    {
        if(attacking == true)
        {
            if(closestenemy.Instance.nearestEnemy != null)
        {
            anim.SetTrigger("isattacking");
            if(attacktime <= 0)
            {
            GameObject arrows = Instantiate(arrow, arrowref.transform.position, Quaternion.identity) as GameObject;
            arrows.transform.LookAt(closestenemy.Instance.nearestEnemy);
            direction = closestenemy.Instance.nearestEnemy.position - ptrans.position;
            arrows.GetComponent<Rigidbody>().AddRelativeForce(direction.normalized * 500, ForceMode.Force);
            attacktime = 1.3f;
            }
        }
        else
        {
            if(playerismoving == false)
            {
            anim.SetTrigger("isidle");
            }
        }
        attacktime -= Time.deltaTime;   
        }
        else
        {
            if(playerismoving == false)
            {
            anim.SetTrigger("isidle");
            }
        }   
    }
}
