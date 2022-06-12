using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BopItBehavior : AgentBehaviour
{
    public AudioSource pushAudio;
    public AudioSource liftAudio;
    public AudioSource moveAudio;

    public AudioSource incrementAudio;

    public GameObject BopItMenu;
    public GameObject MiniGameWon;
    public GameObject MiniGameLost;

    public Button liftButton;
    public Button pushButton;

    private bool isKidnapped;
    private bool isPushed;
    private bool isInMotion;

    IEnumerator co;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CelluloAgent>().SetGoalPosition(7f, -8.7f, 185f);
        isKidnapped = false;
        isPushed = false;
        isInMotion = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<CelluloAgent>().GetSteeringLinear() != Vector3.zero){
            isInMotion = true;
        }
    }

    public void GameEnter(){
        co = waiter();
        StartCoroutine(co);
    }

    IEnumerator gameLost()
    {
        yield return new WaitForSeconds(2);
        MiniGameLost.SetActive(false);
    }

    private bool isLifted(){
        if(isKidnapped){ return false;}
        if(isPushed || isInMotion){
            Debug.Log("Lost!");
            MiniGameLost.SetActive(true);
            StartCoroutine(gameLost());
            GameManager.isMiniGamefinished = true;
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    private bool isPressed(){
        if(isPushed){ return false;}
        if(isKidnapped || isInMotion){
            Debug.Log("Lost!");
            MiniGameLost.SetActive(true);
            StartCoroutine(gameLost());
            GameManager.isMiniGamefinished = true;
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    private bool isMoving(){
        if(isInMotion){ return false;}
        if(isPushed || isKidnapped){
            Debug.Log("Lost!");
            MiniGameLost.SetActive(true);
            StartCoroutine(gameLost());
            GameManager.isMiniGamefinished = true;
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    IEnumerator waiter()
    {
        BopItMenu.SetActive(true);
        yield return new WaitForSeconds(6);
        Debug.Log("Game has started");
        BopItMenu.SetActive(false);
        yield return new WaitForSeconds(4);
        Debug.Log("Game is playing");
        yield return new WaitForSeconds(2);

        isKidnapped = false;
        isPushed = false;
        isInMotion = false;

        Debug.Log("lift");
        liftAudio.Play();
        yield return new WaitWhile(isLifted);
        
        yield return new WaitForSeconds(2);
        isKidnapped = false;

        Debug.Log("move");
        moveAudio.Play();
        yield return new WaitWhile(isMoving);

        yield return new WaitForSeconds(2);
        isInMotion = false;

        Debug.Log(GetComponent<CelluloAgent>().GetSteeringLinear());
        Debug.Log("lift");
        liftAudio.Play();
        yield return new WaitWhile(isLifted);
        
        yield return new WaitForSeconds(2);
        isKidnapped = false;

        Debug.Log("push");
        pushAudio.Play();
        yield return new WaitWhile(isPressed);

        yield return new WaitForSeconds(2);
        isPushed = false;

        Debug.Log("push");
        pushAudio.Play();
        yield return new WaitWhile(isPressed);

        yield return new WaitForSeconds(2);
        isPushed = false; 

        Debug.Log("lift");
        liftAudio.Play();
        yield return new WaitWhile(isLifted);

        yield return new WaitForSeconds(2);
        isKidnapped = false;

        Debug.Log("move");
        moveAudio.Play();
        yield return new WaitWhile(isMoving);

        yield return new WaitForSeconds(2);
        isInMotion = false;

        MiniGameWon.SetActive(true);
        yield return new WaitForSeconds(2);
        GetComponent<ScoreManager>().incrementScore();
        incrementAudio.Play();
        MiniGameWon.SetActive(false);
        GameManager.isMiniGamefinished = true;
    }

    public override void OnCelluloKidnapped(){
        Debug.Log("Kidnapped !");
        isKidnapped = true;
    }

    public override void OnCelluloTouchBegan(int key){
        Debug.Log("Pressed :" + key + "!");
        isPushed = true;
    }

    private void OnEnable(){
        liftButton.onClick.AddListener(OnCelluloKidnapped);
        pushButton.onClick.AddListener(delegate{OnCelluloTouchBegan(0);});
   }
   private void OnDisable(){
        liftButton.onClick.RemoveListener(OnCelluloKidnapped);
        pushButton.onClick.RemoveListener(delegate{OnCelluloTouchBegan(0);});
   }
}
