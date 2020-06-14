using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public Element resistance;
    
    public enum Element
    {
        NONE, WATER, FIRE, EARTH, AIR 
    }

    public abstract void OnCollisionEnter2D(Collision2D other);
}


