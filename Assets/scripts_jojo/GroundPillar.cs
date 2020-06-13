using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPillar : Interactable
{

    public Vector2 startPos;
    public Vector2 cursorPos;
    public Vector2 direction;
    public float maxDistance;
    public bool cmp = false;
    public GameObject pillar;
    public bool dragging = false;

    public GameObject current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active && activated)
        {
            
            if (cursorScript.down && !cmp)
            {
                cmp = !cmp;
                MouseDown();
            }
        }
        else if (activated)
        {
            if (!cursorScript.down && cmp)
            { 
                cmp = !cmp;
                MouseUp();
            }
        }
        

        if (dragging)
        {
            cursorPos = new Vector2(cursor.transform.position.x, cursor.transform.position.y);
            direction = cursorPos - startPos;
            if (direction.magnitude < maxDistance)
            {
                Vector2 dir = direction.normalized;
                float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                current.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            }
            current.transform.localScale = new Vector3(1, direction.magnitude, 1);
        }
        
        
        
    }


    public override void MouseDown()
    {
        if (cursorScript.element == MyCursor.Element.EARTH)
        {
            startPos = cursor.transform.position;
            current = Instantiate(pillar, new Vector3(startPos.x, startPos.y, 1), Quaternion.identity);
            dragging = true;
        }
       

    }

    public override void MouseUp()
    {
        if (cursorScript.element == MyCursor.Element.EARTH)
        {
            dragging = false;
        }
       
    }

   
}
