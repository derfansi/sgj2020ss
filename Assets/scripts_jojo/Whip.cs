using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isHeld;
    public GameObject cursor;
    public MyCursor cursorSkript;
    public bool active=false;
    private Vector2 cursorPos;
    private Rigidbody2D _rigidbody;
    private bool dropped = false;
    private Transform whipBase;
    void Start()
    {
        whipBase = transform.GetChild(0);
        _rigidbody = whipBase.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (isHeld)
            {
                cursorPos = new Vector2(cursor.transform.position.x, cursor.transform.position.y);
                Debug.Log(cursorPos);
                transform.position = new Vector2(cursorPos.x, cursorPos.y);
            }
            else if(!dropped)
            {
                dropped = true;
                _rigidbody.gravityScale = 1;
                
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("whipSound");
    }

    public void Config(GameObject cursor, MyCursor myCursor)
    {
        active = true;
        isHeld = true;
        this.cursor = cursor;
        this.cursorSkript = myCursor;
        HingeJoint2D hinge =whipBase.GetComponent<HingeJoint2D>();
        hinge.connectedAnchor = new Vector2(cursor.transform.position.x, cursor.transform.position.y);
        hinge.anchor = new Vector2(cursor.transform.position.x, cursor.transform.position.y);
    }
}
