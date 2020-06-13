using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected bool activated=false;
    [SerializeField]
    protected bool active = false;
    [SerializeReference]
    protected GameObject cursor;
    protected MyCursor cursorScript;
    
    public abstract void MouseDown();

    public abstract void MouseUp();

    public void CursorEnter(GameObject cursor)
    {
        if (!activated)
        {
            activated = true;
            this.cursor = cursor;
            cursorScript = cursor.GetComponent<MyCursor>();
        }

        active = true;
    }

    public void CursorExit()
    {
        active = false;
    }



}
