using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupText : MonoBehaviour
{
    public GameObject canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //canvas.SetActive(true);
            StartCoroutine(ExampleText());
        }
    }

    IEnumerator ExampleText()
    {
        canvas.SetActive(true);
        
        yield return new WaitForSeconds(5);
        
        canvas.SetActive(false);
        Destroy(canvas);
        Destroy(gameObject);
    }
    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(canvas);
            Destroy(gameObject);
        }
    }*/
}
