using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button startButton;
    public Button playAgainButton;

   private void Awake()
   {
       Time.timeScale = 0f;
   }

   private void OnEnable(){
      startButton.onClick.AddListener(StartGame);

   }

   private void OnDisable(){
      startButton.onClick.RemoveListener(StartGame);
   }

   private void StartGame()
   {
      Time.timeScale = 1f;
      startButton.gameObject.SetActive(false);
   }
}
