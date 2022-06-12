using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
   public static bool isPlaying;
   public static bool isPlayingMiniGame;

   public static bool isMiniGamefinished;

   public GameObject CelluloImage;
   public GameObject BopItButtons;

   public Button startButton;
   public Button pauseButton;
   public Button resumeButton;
   public GameObject player1;
   public GameObject player2;
   public GameObject ghostSheep;
   public GameObject gem;
   public TextMeshProUGUI scoreText1;
   public TextMeshProUGUI scoreText2;
   public bool longPress1;
   public bool longPress2;
   private bool bopItMode;
   private bool formMode;
   private bool simonMode;

   private Vector3 player1Position;
   private Vector3 player2Position;
   private Vector3 ghostSheepPosition;

   private void Awake(){
      isPlaying = false;
      isPlayingMiniGame = false;
   }

   void Start()
   {
      player1.GetComponent<CelluloAgentRigidBody>().initialColor = GameSetup.color1;
      player2.GetComponent<CelluloAgentRigidBody>().initialColor = GameSetup.color2;
      player1.GetComponent<MoveWithKeyboardBehavior>().color = GameSetup.color1;
      player2.GetComponent<MoveWithKeyboardBehavior>().color = GameSetup.color2;
      player1.GetComponent<MoveWithKeyboardBehavior>().inputKeyboardString = GameSetup.movement1;
      player2.GetComponent<MoveWithKeyboardBehavior>().inputKeyboardString = GameSetup.movement2;
      scoreText1.color = GameSetup.color1;
      scoreText2.color = GameSetup.color2;
      bopItMode = false;
      formMode = false;
      simonMode = false;
      isPlayingMiniGame = false;
      isMiniGamefinished = false;
      player1.GetComponent<BopItBehavior>().enabled = false;
      player2.GetComponent<BopItBehavior>().enabled = false;
      player1.GetComponent<FormBehavior>().enabled = false;
      player2.GetComponent<FormBehavior>().enabled = false;
      player1.GetComponent<SimonBehavior>().enabled = false;
      player2.GetComponent<SimonBehavior>().enabled = false;
   }

   void Update()
   {
      if(scoreText1.text == "15" && simonMode == false){
         startSimon(player1, player2);
         PauseGameForMiniGame();
      }
      if(scoreText2.text == "15" && simonMode == false){
         startSimon(player2, player1);
         PauseGameForMiniGame();
      }
      if(scoreText1.text == "05" && bopItMode == false){
         startBopIt(player1, player2);
         PauseGameForMiniGame();
      }
      if(scoreText2.text == "05" && bopItMode == false){
         startBopIt(player2, player1);
         PauseGameForMiniGame();
      }
      if(scoreText1.text == "10" && formMode == false){
         startForms(player1, player2);
         PauseGameForMiniGame();
      }
      if(scoreText2.text == "10" && formMode == false){
         startForms(player2, player1);
         PauseGameForMiniGame();
      }

      if(isMiniGamefinished){
         if(CelluloImage.activeSelf){
            CelluloImage.SetActive(false);
         }
         if(BopItButtons.activeSelf){
            BopItButtons.SetActive(false);
         }
         ResumeGameFromMiniGame();
         isMiniGamefinished = false;
      }
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
      Debug.Log("start game");
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

   public void PauseGameForMiniGame(){
      isPlayingMiniGame = true;
      player1Position = player1.transform.position;
      player2Position = player2.transform.position;
      ghostSheepPosition = ghostSheep.transform.position;
   }

   private void ResumeGameFromMiniGame(){
      isPlayingMiniGame = false;
      player1.GetComponent<CelluloAgent>().SetGoalPosition(4.33f, -8f, 185f);
      player2.GetComponent<CelluloAgent>().SetGoalPosition(9.89f, -8f, 185f);
      ghostSheep.GetComponent<CelluloAgent>().SetGoalPosition(7f, -8f, 185f);
      ghostSheep.GetComponent<GhostSheepBehavior>().enabled = true;
      gem.GetComponent<Gem>().enabled = true;
   }
   
   private void startBopIt(GameObject bopItPlayer, GameObject idlePlayer){
      Debug.Log("startBopIt");
      bopItPlayer.GetComponent<BopItBehavior>().enabled = true;
      ghostSheep.GetComponent<CelluloAgent>().SetGoalPosition(13f, -5f, 185f);
      idlePlayer.GetComponent<CelluloAgent>().SetGoalPosition(1f, -5f, 185f);
      gem.GetComponent<Gem>().enabled = false;
      bopItMode = true;
      BopItButtons.SetActive(true);
      Debug.Log("Game Enter");
      bopItPlayer.GetComponent<BopItBehavior>().GameEnter();
   }

   private void startForms(GameObject formPlayer, GameObject idlePlayer){
      Debug.Log("startForms");
      formPlayer.GetComponent<FormBehavior>().enabled = true;
      ghostSheep.GetComponent<CelluloAgent>().SetGoalPosition(13f, -5f, 185f);
      idlePlayer.GetComponent<CelluloAgent>().SetGoalPosition(1f, -5f, 185f);
      gem.GetComponent<Gem>().enabled = false;
      formMode = true;
      Debug.Log("Game Enter");
      formPlayer.GetComponent<FormBehavior>().GameEnter();
   }

   private void startSimon(GameObject simonPlayer, GameObject idlePlayer){
      Debug.Log("startSimon");
      simonPlayer.GetComponent<SimonBehavior>().enabled = true;
      ghostSheep.GetComponent<CelluloAgent>().SetGoalPosition(13f, -5f, 185f);
      idlePlayer.GetComponent<CelluloAgent>().SetGoalPosition(1f, -5f, 185f);
      gem.GetComponent<Gem>().enabled = false;
      simonMode = true;
      CelluloImage.SetActive(true);
      Debug.Log("Game Enter");
      simonPlayer.GetComponent<SimonBehavior>().GameEnter();
   }
}
