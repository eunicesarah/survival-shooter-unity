using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderManager : MonoBehaviour
{
    [SerializeField] public string sliderText = "Easy";

    public void SliderChange(float value)
    {
        if (value == 0.0f)
        {
            sliderText = "Easy";
        }
        else if (value == 1.0f)
        {
            sliderText = "Medium";
        }
        else
        {
            sliderText = "Hard";
        }
        
    }
}
