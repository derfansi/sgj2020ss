using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{


    public abstract void OnCollisionEnter2D(Collision2D other);
}


