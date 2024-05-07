using UnityEngine;
using UnityEngine.UI;

public class MushroomHealth : MonoBehaviour
{
    public int startingHealth = 40;
    public int currentHealth;
    public Slider healthSlider;

    void OnEnable()
    {
        currentHealth = startingHealth;
        UpdateSlider();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateSlider();
    }

    void UpdateSlider()
    {
        if (healthSlider != null)
        {
            float sliderValue = (float)currentHealth / startingHealth;
            healthSlider.value = sliderValue;
        }
    }
}
