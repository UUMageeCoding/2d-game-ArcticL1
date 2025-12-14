using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void updatehealthbar(float currentValue, float maxvalue)
    {
        slider.value = currentValue / maxvalue;
    }
}
