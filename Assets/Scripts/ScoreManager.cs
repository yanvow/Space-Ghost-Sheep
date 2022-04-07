using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int redScore;
    public static int blueScore;
    public TextMeshProUGUI blueScoreText;
    public TextMeshProUGUI redScoreText;

    // Start is called before the first frame update
    void Start()
    {
        redScore = 0;
        blueScore = 0;
        redScoreText.text = "00";
        blueScoreText.text = "00";
    }

    // Update is called once per frame
    void Update()
    {
        redScoreText.text = string.Format("{0:00}", redScore);
        blueScoreText.text = string.Format("{0:00}", blueScore);
    }

    public static void incrementScore(string player){
        if(player == "CelluloAgent_2"){
            redScore += 1;
        }else if(player == "CelluloAgent_3"){
            blueScore += 1;
        }else{
            Debug.Log("player doesn't exist");
        }
    }
    
    public static void decrementScore(string player){
        if(player == "CelluloAgent_2"){
            redScore -= 1;
            //decrementAudio.Play();
        }else if(player == "CelluloAgent_3"){
            blueScore -= 1;
            //decrementAudio.Play();
        }else{
            Debug.Log("player doesn't exist");
        }
    }
}
