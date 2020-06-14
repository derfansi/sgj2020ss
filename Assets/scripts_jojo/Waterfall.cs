using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : Interactable
{
    public GameObject whip;
    public bool cmp = false;
    public GameObject current;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (active)
        {
            if (cursorScript.down && !cmp)
            {
                cmp = !cmp;
                MouseDown();
            }
        }

        if (activated)
        {
            if(!cursorScript.down && cmp)
            {
                cmp = !cmp;
                MouseUp();
            }
        }
    }


    public override void MouseDown()
    {
        if (cursorScript.element == MyCursor.Element.WATER)
        {
            current = Instantiate(whip, cursor.transform.position, Quaternion.identity);
            current.GetComponent<Whip>().Config(cursor, cursorScript);
        }
    }

    public override void MouseUp()
    {
        if (cursorScript.element == MyCursor.Element.WATER)
        {
            current.GetComponent<Whip>().isHeld = false;
            cmp = false;
        }
    }
}
