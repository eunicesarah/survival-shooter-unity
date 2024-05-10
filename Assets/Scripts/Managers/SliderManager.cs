using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nightmare
{
public class SliderManager : MonoBehaviour
{
    [SerializeField] public string sliderText = "Easy";
    public int sliderValue = 1;

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
    public string GetSliderText()
    {
        return sliderText;
    }
    public float GetSliderValue()
    {
        return sliderValue;
    }
    public void SetSliderValue(float value)
    {
        this.sliderValue = (int) value + 1;
            MainManager.Instance.difficulty = this.sliderValue;
    }
}
    }