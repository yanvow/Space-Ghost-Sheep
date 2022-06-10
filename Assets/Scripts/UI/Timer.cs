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
    public GameObject gem;
    public AudioSource popGem;
    private float minutes;
    private float seconds;
    private float time;
    private bool tst;
    private int gemFrequency = 20;

    // Start is called before the first frame update
    public void Start() {
        time = 0f;
        timerText = GetComponent<TextMeshProUGUI>();
        timerText.text = string.Format("TIMER {0:00}:{1:00}", 0, 0);
        slider.maxValue = GameSetup.gameDuration * 60;
        slider.value = 0;
        tst = true; 
    }

    // Update is called once per frame
    public void Update() {
        
        if(GameManager.isPlaying && !GameManager.isPlayingMiniGame){
            time += Time.deltaTime;
        }

        if(time >= (GameSetup.gameDuration * 60)){
            time = 0f;
            GameManager.isPlaying = false;
            endgame.SetActive(true);
            gameWinner();
        }

        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("TIMER {0:00}:{1:00}", minutes, seconds);
        slider.value = minutes * 60 + seconds;

        if (seconds % gemFrequency == 0 && seconds != 0){
            if(tst){
                gem.transform.position = new Vector3(Random.Range(1f,26f), 0.8f, Random.Range(-19f, 0));
                gem.SetActive(true);
                tst = false;
                popGem.Play();
                GameObject[] CelluloDogs = GameObject.FindGameObjectsWithTag("CelluloDog");
                foreach (GameObject CelluloDog in CelluloDogs){
                    CelluloDog.GetComponent<MoveWithKeyboardBehavior>().hasGem = false;
                }
            }
        }else{
            tst = true;
        }
    }

    void gameWinner(){
        float rightScore = rightPlayer.getScore();
        float leftScore = leftPlayer.getScore();
        if(rightScore > leftScore){
            winnerText.color = GameSetup.color2;
            winnerText.text = string.Format("TEAM RIGHT");
        }else if(leftScore > rightScore){
            winnerText.color = GameSetup.color1;
            winnerText.text = string.Format("TEAM LEFT");
        }else{
            winnerText.color = Color.white;
            winnerText.text = string.Format("BOTH");
        }
    }
}
