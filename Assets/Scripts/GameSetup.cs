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
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public TextMeshProUGUI playerText;
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
        playerText.color = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        color = new Color(redSlider.value, greenSlider.value, blueSlider.value);
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
