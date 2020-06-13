using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTesting : MonoBehaviour
{
    public MusicManagement musicManager;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            musicManager.AirActivated();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            musicManager.WaterActivated();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            musicManager.EarthActivated();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            musicManager.FireActivated();
        }
    }
}
