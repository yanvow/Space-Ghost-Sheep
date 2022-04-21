using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
	This class is the implementation of the timer used in the game and how it is handled in it
*/
public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    public Slider slider;
    public GameObject endgame;
    public TextMeshProUGUI winnerText;
    public ScoreManager rightPlayer;
    public ScoreManager leftPlayer;
    private float minutes;
    private float seconds;
    private float time;

    // Start is called before the first frame update
    public void Start() {
        time = 0f;
        timerText = GetComponent<TextMeshProUGUI>();
        timerText.text = string.Format("TIMER {0:00}:{1:00}", 0, 0);
        slider.maxValue = GameSetup.maxMinutes * 60;
        slider.value = 0;
    }

    // Update is called once per frame
    public void Update() {
        
        if(GameManager.isPlaying == true){
            time += Time.deltaTime;
        }

        if(time >= (GameSetup.maxMinutes * 60)){
            time = 0f;
            GameManager.isPlaying = false;
            endgame.SetActive(true);
            gameWinner();
        }

        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("TIMER {0:00}:{1:00}", minutes, seconds);
        slider.value = minutes * 60 + seconds;
    }

    void gameWinner(){
        float rightScore = rightPlayer.getScore();
        float leftScore = leftPlayer.getScore();
        if(rightScore > leftScore){
            winnerText.color = Color.blue;
            winnerText.text = string.Format("TEAM RIGHT");
        }else if(leftScore > rightScore){
            winnerText.color = Color.red;
            winnerText.text = string.Format("TEAM LEFT");
        }else{
            winnerText.color = Color.white;
            winnerText.text = string.Format("BOTH");
        }
    }
}
