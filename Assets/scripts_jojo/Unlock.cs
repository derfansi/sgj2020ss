using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{

    public MyCursor cursorScript;
    public PressurePlate plate;

    public MyCursor.Element element;
    // Start is called before the first frame update
    void Start()
    {
        cursorScript = GameObject.Find("Cursor").GetComponent<MyCursor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("here");
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown("f"))
        {
            if (plate != null && !plate.activated)
                return;
            cursorScript.UnlockElement(element);
        }
    }
}
