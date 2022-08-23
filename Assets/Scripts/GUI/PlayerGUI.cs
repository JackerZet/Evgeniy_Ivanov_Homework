using MyGame.SO;
using UnityEngine;

namespace MyGame
{
    public class PlayerGUI : MonoBehaviour
    {
        [SerializeField] private IntVariable curHealth;
        [SerializeField] private IntVariable maxHealth;
        public Color myColor;

        private void OnGUI()
        {
            GUI.HorizontalSlider(new Rect(20, 20, 150, 100), curHealth.value / (float)maxHealth.value, 0.0f, 1.0f);
            GUI.Label(new Rect(20, 40, 50, 100), $"{curHealth.value}/{maxHealth.value}");
            myColor = RGBSlider(new Rect(Screen.width - 210, Screen.height - 80, 150, 20), myColor);
        }
        Color RGBSlider(Rect screenRect, Color rgb)
        {
            rgb.r = LabelSlider(screenRect, rgb.r, 0.0f, 1.0f, "Red");
            screenRect.y += 20;
            rgb.g = LabelSlider(screenRect, rgb.g, 0.0f, 1.0f, "Green");
            screenRect.y += 20;
            rgb.b = LabelSlider(screenRect, rgb.b, 0.0f, 1.0f, "Blue");
            screenRect.y += 20;
            rgb.a = LabelSlider(screenRect, rgb.a, 0.0f, 1.0f, "Alpha");
            return rgb;
        }
        float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText)
        {
            GUI.Label(screenRect, labelText);
            screenRect.x += 40;
            sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, sliderMinValue, sliderMaxValue);
            return sliderValue;
        }
    }
}
