using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCursor : MonoBehaviour
{
    private Vector2 movement;
    private Vector3 viewport;
    public float speed = 1;
    private Camera _camera;
    public bool down;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _camera = Camera.main;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Mouse X");
        movement.y = Input.GetAxisRaw("Mouse Y");

        if (Input.GetMouseButtonDown(0))
        {
            down = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            down = false;
        }

        transform.position += new Vector3(movement.x, movement.y, 0) * speed/10;
        
        //constraints
        viewport = Camera.main.WorldToViewportPoint(transform.position);
        //Top
        if (viewport.y > 1)
        {
            transform.position = _camera.ViewportToWorldPoint(new Vector3(viewport.x, 1, viewport.z));
        }
        //Bottom
        else if (viewport.y < 0)
        {
            transform.position =_camera.ViewportToWorldPoint(new Vector3(viewport.x, 0, viewport.z));
        }
        //Right
        if (viewport.x > 1)
        {
            transform.position = _camera.ViewportToWorldPoint(new Vector3(1, viewport.y, viewport.z));
        }
        //Left
        if (viewport.x < 0)
        {
            transform.position = _camera.ViewportToWorldPoint(new Vector3(0, viewport.y, viewport.z));
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        if (other.CompareTag("Interactable"))
        {
            other.GetComponent<Interactable>().CursorEnter(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            other.GetComponent<Interactable>().CursorExit();
        }
    }
}

