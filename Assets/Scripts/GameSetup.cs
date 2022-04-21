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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = movementDropdown.options[movementDropdown.value].text;
        maxMinutesText.text = maxMinutes.ToString();
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
