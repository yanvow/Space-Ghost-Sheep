using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static bool isPlaying;
   public Button startButton;
   public Button pauseButton;
   public Button resumeButton;
   public GameObject player1;
   public GameObject player2;
   public bool longPress1;
   public bool longPress2;

   private void Awake(){
      isPlaying = false;
   }

   void Start()
   {
      player1.GetComponent<CelluloAgentRigidBody>().initialColor = GameSetup.color1;
      player2.GetComponent<CelluloAgentRigidBody>().initialColor = GameSetup.color2;
      player1.GetComponent<MoveWithKeyboardBehavior>().color = GameSetup.color1;
      player2.GetComponent<MoveWithKeyboardBehavior>().color = GameSetup.color2;
      player1.GetComponent<MoveWithKeyboardBehavior>().inputKeyboardString = GameSetup.movement1;
      player2.GetComponent<MoveWithKeyboardBehavior>().inputKeyboardString = GameSetup.movement2;
   }

   private void OnEnable(){
      startButton.onClick.AddListener(StartGame);
      pauseButton.onClick.AddListener(PauseGame);
      resumeButton.onClick.AddListener(ResumeGame);
   }
   private void OnDisable(){
      startButton.onClick.RemoveListener(StartGame);
      pauseButton.onClick.RemoveListener(PauseGame);
      resumeButton.onClick.RemoveListener(ResumeGame);
   }

   public void StartGame(){
      isPlaying = true;
      startButton.gameObject.SetActive(false);
      pauseButton.gameObject.SetActive(true);
   }

   public void StartGamewithCellulo(){
      longPress1 = player1.GetComponent<MoveWithKeyboardBehavior>().longPress;
      longPress2 = player2.GetComponent<MoveWithKeyboardBehavior>().longPress;
      if(longPress1 == true && longPress2 == true){
         StartGame();
      }
   }

   private void PauseGame(){
      isPlaying = false;
   }

   private void ResumeGame(){
      isPlaying = true;
   }

   public void ChangeMuteAudio(){
      if(AudioListener.volume == 0){
         AudioListener.volume = 1f;
      }else{
         AudioListener.volume = 0f;
      }
   }
}
