using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopUp : MonoBehaviour
{ 
    public GameObject canvas;

    private void Start()
    {
        canvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ExampleText());
        }
    }

    IEnumerator ExampleText()
    {
        canvas.SetActive(true);
        
        yield return new WaitForSeconds(15);
        
        canvas.SetActive(false);
        Destroy(canvas);
        Destroy(gameObject);
    }
}