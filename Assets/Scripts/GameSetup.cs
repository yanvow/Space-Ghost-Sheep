using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameSetup : MonoBehaviour
{
    public TMP_Dropdown movementDropdown;
    public TextMeshProUGUI maxMinutesText;
    public static string movement;
    public static float maxMinutes = 2f;
    public Slider red1Slider;
    public Slider green1Slider;
    public Slider blue1Slider;
    public Slider red2Slider;
    public Slider green2Slider;
    public Slider blue2Slider;
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public static Color color;
    private int colorValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = movementDropdown.options[movementDropdown.value].text;
        maxMinutesText.text = maxMinutes.ToString();
        player1Text.color = new Color(red1Slider.value, green1Slider.value, blue1Slider.value);
        player2Text.color = new Color(red2Slider.value, green2Slider.value, blue2Slider.value);
        color = new Color(red1Slider.value, green1Slider.value, blue1Slider.value);
        //robot.SetVisualEffect(visualEffectDropdown.value, (long)(redSlider.value * 255), (long)(greenSlider.value * 255), (long) (blueSlider.value * 255), colorValue);
    }

    public void incrementMaxMinutes(){
        if(maxMinutes < 5){ 
            maxMinutes += 1;
        }
    }

     public void decrementMaxMinutes(){
        if(maxMinutes > 2){ 
            maxMinutes -= 1;
        }
    }
}
