using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dashbar : MonoBehaviour
{
    public Slider dashbar;

    public void SetDashes(int dash)
    {
        dashbar.value = dash;
    }

    public void SetMaxDashes(int dashes)
    {
        dashbar.maxValue = dashes;
    }
}
