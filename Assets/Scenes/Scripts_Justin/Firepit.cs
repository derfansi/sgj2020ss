using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class Firepit : Interactable
{
    public GameObject fireball;
    private GameObject fireballInstance;

    private Rigidbody2D _rigidbody;
    private Vector2 cursorPos;
    private Vector2 lastPosition;
    private bool isHeld;
    private bool cmp = false;

    
    // Update is called once per frame
    void Update()
    {
        //update position if held
        if (isHeld)
        {
            lastPosition = fireballInstance.transform.position;
            cursorPos = new Vector2(cursor.transform.position.x, cursor.transform.position.y);
            fireballInstance.transform.localPosition = new Vector2(cursorPos.x, cursorPos.y);
        }
        
        //check for cursor input and invoke functions accordingly
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
            
            if (cursorScript.down || !cmp) return;
            cmp = !cmp; 
            MouseUp();
        }
    }

    public override void MouseDown()
    {
        if (cursorScript.element != MyCursor.Element.FIRE) return;
        
        isHeld = true;
        fireballInstance = Instantiate(fireball);
        _rigidbody = fireballInstance.GetComponent<Rigidbody2D>();
    }

    public override void MouseUp()
    {
        if (cursorScript.element != MyCursor.Element.FIRE) return;
        
        isHeld = false;
        Vector2 throwVector = new Vector2(fireballInstance.transform.position.x, fireballInstance.transform.position.y) - lastPosition;
        float speed = 0.5f * throwVector.magnitude / (Time.deltaTime * _rigidbody.mass);
        Vector2 throwVelocity = speed * throwVector.normalized;
        _rigidbody.velocity = throwVelocity;
        _rigidbody = null;
        StartCoroutine(KillTheOld(fireballInstance));
    }

    IEnumerator KillTheOld(GameObject fb)
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(fb);
    }
}
