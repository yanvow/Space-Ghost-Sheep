using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int playerScore;
    public TextMeshProUGUI playerScoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        playerScoreText.text = "00";
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = string.Format("{0:00}", playerScore);
    }

    public int getScore(){
        return playerScore;
    }

    public void incrementScore(){
        playerScore += 1;
    }
    
    public void decrementScore(){
        playerScore -= 1;
    }
}
