using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.right * (inputH * (10.0f * Time.deltaTime)), Space.World);
        
    }
}