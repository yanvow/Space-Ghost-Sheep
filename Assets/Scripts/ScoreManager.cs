using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int redScore;
    private int blueScore;
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

    void OnCollisionEnter(Collision collisionInfo)
    {
        string name = collisionInfo.gameObject.name;
        if(name == "CelluloAgent_3"){
            blueScore -= 1;
        }else if(name == "CelluloAgent_2"){
            redScore -= 1;
        }
    }
}
