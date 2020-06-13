using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Fire : MonoBehaviour
{
    private float ttl;
    
    private void Start()
    {
        ttl = 3f;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        transform.localScale = new Vector3(0.2f + ttl / 10, 0.2f + ttl / 10, 0.2f + ttl / 10);
    }
}