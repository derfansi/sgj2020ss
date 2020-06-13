using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    //for smooth camera follow
    [SerializeField]
    private GameObject player;
    [SerializeField] 
    private float timeOffset;
    [SerializeField]
    private Vector2 posOffset;
    private Vector3 velocity;


    private float pixelToUnits = 40f;
    

    //for cmaera boundaries
    [SerializeField] 
    private float leftLimit, rightLimit, bottomLimit, topLimit;
    
    // Update is called once per frame
    void Update()
    {
        //smooth follow
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);
        
        //camera boundaries
        
    }
    
    public float RoundToNearestPixel(float unityUnits)
    {
        float valueInPixels = unityUnits * pixelToUnits;
        valueInPixels = Mathf.Round(valueInPixels);
        float roundedUnityUnits = valueInPixels * (1 / pixelToUnits);
        return roundedUnityUnits;
    }
    
    
}
