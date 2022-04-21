using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static bool isPlaying;
   public Button pauseButton;
   public Button resumeButton;

   private void Awake(){
      isPlaying = true;
   }

    private void OnEnable(){
      pauseButton.onClick.AddListener(PauseGame);
      resumeButton.onClick.AddListener(ResumeGame);
   }
   private void OnDisable(){
      pauseButton.onClick.RemoveListener(PauseGame);
      resumeButton.onClick.RemoveListener(ResumeGame);
   }

   private void StartGame(){
      isPlaying = true;
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
