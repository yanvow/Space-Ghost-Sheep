using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
	This class is the implementation of the timer used in the game and how it is handled in it
*/
public class Timer : MonoBehaviour
{
    private float initTimerValue;
    private TextMeshProUGUI timerText;
    public Slider slider;
    public float maxMinutes;
    public GameManager gameManager;
    public GameObject endgame;

    public void Awake() {
        initTimerValue = Time.timeSinceLevelLoad;
    }

    // Start is called before the first frame update
    public void Start() {
        timerText = GetComponent<TextMeshProUGUI>();
        timerText.text = string.Format("TIMER {0:00}:{1:00}", 0, 0);
        slider.maxValue = maxMinutes * 60;
        slider.value = 0;
    }

    // Update is called once per frame
    public void Update() {
        
        float minutes = Mathf.FloorToInt(Time.timeSinceLevelLoad / 60);
        float seconds = Mathf.FloorToInt(Time.timeSinceLevelLoad % 60);

        if(Time.timeSinceLevelLoad >= (maxMinutes * 60) + initTimerValue){
            minutes = 0f;
            seconds = 0f;
            endgame.SetActive(true);
        }

        timerText.text = string.Format("TIMER {0:00}:{1:00}", minutes, seconds);

        slider.value = minutes * 60 + seconds;
        
    }
}
