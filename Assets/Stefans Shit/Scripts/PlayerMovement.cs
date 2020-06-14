using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 5f * Input.GetAxisRaw("Horizontal"));
        }
    }
}
