using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameSetup : MonoBehaviour
{
    public float maxMinutes;
    public float minMinutes;
    public TMP_Dropdown movementDropdown1;
    public TMP_Dropdown movementDropdown2;
    public TextMeshProUGUI gameDurationText;
    public Slider red1Slider;
    public Slider green1Slider;
    public Slider blue1Slider;
    public Slider red2Slider;
    public Slider green2Slider;
    public Slider blue2Slider;
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public static Color color1;
    public static Color color2;
    public static string movement1;
    public static string movement2;
    public static float gameDuration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        red1Slider.value = 1;
        green1Slider.value = 0;
        blue1Slider.value = 0;
        red2Slider.value = 0;
        green2Slider.value = 0;
        blue2Slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gameDurationText.text = gameDuration.ToString();
        player1Text.color = new Color(red1Slider.value, green1Slider.value, blue1Slider.value);
        player2Text.color = new Color(red2Slider.value, green2Slider.value, blue2Slider.value);
        color1 = new Color(red1Slider.value, green1Slider.value, blue1Slider.value);
        color2 = new Color(red2Slider.value, green2Slider.value, blue2Slider.value);
        movement1 = movementDropdown1.options[movementDropdown1.value].text;
        movement2 = movementDropdown2.options[movementDropdown2.value].text;
    }

    public void incrementMaxMinutes(){
        if(gameDuration < maxMinutes){ 
            gameDuration += 1;
        }
    }

    public void decrementMaxMinutes(){
        if(gameDuration > minMinutes){ 
            gameDuration -= 1;
        }
    }
}
