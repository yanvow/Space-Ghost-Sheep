using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "00";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("{0:00}", score);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "CelluloGhost"){
            score -= 1;
        }
    }
}
