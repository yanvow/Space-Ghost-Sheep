using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonBehavior : AgentBehaviour
{
    public Button led0Button;
    public Button led1Button;
    public Button led2Button;
    public Button led3Button;
    public Button led4Button;
    public Button led5Button;

    public GameObject SimonMenu;

    private Color initColor;

    private bool led0;
    private bool led1;
    private bool led2;
    private bool led3;
    private bool led4;
    private bool led5;

    IEnumerator co;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CelluloAgent>().SetGoalPosition(7f, -8.7f, 185f);
        initColor = GetComponent<CelluloAgentRigidBody>().initialColor;
        led0 = false; 
        led1 = false;
        led2 = false;
        led3 = false;
        led4 = false;
        led5 = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GameEnter(){
        co = waiter();
        StartCoroutine(co);
    }

    private bool IsLED0Pressed(){
        if(led0){ return false;}
        else if(led1 || led2 || led3 || led4 || led5){
            Debug.Log("Lost!");
            GameManager.isMiniGamefinished = true;
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    private bool IsLED1Pressed(){
        if(led1){ return false;}
        else if(led0 || led2 || led3 || led4 || led5){
            Debug.Log("Lost!");
            GameManager.isMiniGamefinished = true;
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    private bool IsLED2Pressed(){
        if(led2){ return false;}
        else if(led0 || led1 || led3 || led4 || led5){
            Debug.Log("Lost!");
            GameManager.isMiniGamefinished = true;
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    private bool IsLED3Pressed(){
       if(led3){ return false;}
        else if(led0 || led1 || led2 || led4 || led5){
            Debug.Log("Lost!");
            GameManager.isMiniGamefinished = true;
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    private bool IsLED4Pressed(){
        if(led4){ return false;}
        else if(led0 || led1 || led2 || led3 || led5){
            Debug.Log("Lost!");
            GameManager.isMiniGamefinished = true;
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    private bool IsLED5Pressed(){
        if(led5){ return false;}
        else if(led0 || led1 || led2 || led3 || led4){
            Debug.Log("Lost!");
            GameManager.isMiniGamefinished = true;
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    } 

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("Game has started");
        SimonMenu.SetActive(true);
        yield return new WaitForSeconds(4);
        Debug.Log("Game is playing");
        SimonMenu.SetActive(false);
        yield return new WaitForSeconds(2);
        int[] ledSeq1 = new int[] {1};
        int[] ledSeq2 = new int[] {1, 2};
        int[] ledSeq3 = new int[] {1, 2, 5};
        int[] ledSeq4 = new int[] {1, 2, 5, 0};
        int[] ledSeq5 = new int[] {1, 2, 5, 0, 5};
        int[] ledSeq6 = new int[] {1, 2, 5, 0, 5, 3};

        Debug.Log("Sequence 1");

        foreach (int led in ledSeq1){
            lightOneLED(led);
            yield return new WaitForSeconds(2);
        }

        GetComponent<CelluloAgent>().SetVisualEffect(0, initColor, 0);

        //yield return new WaitWhile(() => led1 == true);
        //yield return new WaitWhile(IsLED1Pressed);

        yield return new WaitWhile(IsLED1Pressed);
        led1 = false;

        yield return new WaitForSeconds(2);

        Debug.Log("Sequence 2");

        foreach (int led in ledSeq2){
            lightOneLED(led);
            yield return new WaitForSeconds(2);
        }

        GetComponent<CelluloAgent>().SetVisualEffect(0, initColor, 0);

        yield return new WaitWhile(IsLED1Pressed);
        led1 = false;

        yield return new WaitWhile(IsLED2Pressed);

        yield return new WaitWhile(IsLED2Pressed);
        led2 = false;

        yield return new WaitForSeconds(2);

        Debug.Log("Sequence 3");

        foreach (int led in ledSeq3){
            lightOneLED(led);
            yield return new WaitForSeconds(2);
        }

        GetComponent<CelluloAgent>().SetVisualEffect(0, initColor, 0);

        yield return new WaitWhile(IsLED1Pressed);
        led1 = false;

        yield return new WaitWhile(IsLED2Pressed);
        led2 = false;

        yield return new WaitWhile(IsLED5Pressed);
        yield return new WaitWhile(IsLED5Pressed);

        led5 = false;

        yield return new WaitForSeconds(2);

        Debug.Log("Sequence 4");

        foreach (int led in ledSeq4){
            lightOneLED(led);
            yield return new WaitForSeconds(2);
        }

        GetComponent<CelluloAgent>().SetVisualEffect(0, initColor, 0);

        yield return new WaitWhile(IsLED1Pressed);
        led1 = false;

        yield return new WaitWhile(IsLED2Pressed);
        led2 = false;

        yield return new WaitWhile(IsLED5Pressed);
        led5 = false;

        yield return new WaitWhile(IsLED0Pressed);
        led0 = false;

        yield return new WaitForSeconds(2);

        Debug.Log("Sequence 5");

        foreach (int led in ledSeq5){
            lightOneLED(led);
            yield return new WaitForSeconds(2);
        }

        GetComponent<CelluloAgent>().SetVisualEffect(0, initColor, 0);

        yield return new WaitWhile(IsLED1Pressed);
        led1 = false;

        yield return new WaitWhile(IsLED2Pressed);
        led2 = false;

        yield return new WaitWhile(IsLED5Pressed);

        led5 = false;

        yield return new WaitWhile(IsLED0Pressed);
        led0 = false;

        yield return new WaitWhile(IsLED5Pressed);

        led5 = false;

        yield return new WaitForSeconds(2);

        Debug.Log("Sequence 6");

        foreach (int led in ledSeq6){
            lightOneLED(led);
            yield return new WaitForSeconds(2);
        }

        GetComponent<CelluloAgent>().SetVisualEffect(0, initColor, 0);

        yield return new WaitWhile(IsLED1Pressed);
        led1 = false;

        yield return new WaitWhile(IsLED2Pressed);
        led2 = false;

        yield return new WaitWhile(IsLED5Pressed);

        led5 = false;

        yield return new WaitWhile(IsLED0Pressed);
        led0 = false;

        yield return new WaitWhile(IsLED5Pressed);
        led5 = false;


        yield return new WaitWhile(IsLED3Pressed);
        led3 = false;

        yield return new WaitForSeconds(2);

        Debug.Log("increment Score");
        GetComponent<ScoreManager>().incrementScore();

        yield return new WaitForSeconds(35);
        GameManager.isMiniGamefinished = true;
    }

    public void lightOneLED(int led){
        Debug.Log("val: " + led);
        GetComponent<CelluloAgent>().SetVisualEffect(0, Color.white, 0);
        GetComponent<CelluloAgent>().SetVisualEffect(VisualEffect.VisualEffectConstSingle, initColor, led);
    }

    //key <=> index de la led pressed
    public override void OnCelluloTouchBegan(int key){
        Debug.Log("Pressed !" + key);
        if(key == 0){
            led0 = true;
        }
        if(key == 1){
            led1 = true;
        }
        if(key == 2){
            led2 = true;
        }
        if(key == 3){
            led3 = true;
        }
        if(key == 4){
            led4 = true;
        }
        if(key == 5){
            led5 = true;
        }
    }

    private void OnEnable(){
        led0Button.onClick.AddListener(delegate{OnCelluloTouchBegan(0);});
        led1Button.onClick.AddListener(delegate{OnCelluloTouchBegan(1);});
        led2Button.onClick.AddListener(delegate{OnCelluloTouchBegan(2);});
        led3Button.onClick.AddListener(delegate{OnCelluloTouchBegan(3);});
        led4Button.onClick.AddListener(delegate{OnCelluloTouchBegan(4);});
        led5Button.onClick.AddListener(delegate{OnCelluloTouchBegan(5);});
   }
   private void OnDisable(){
        led0Button.onClick.RemoveListener(delegate{OnCelluloTouchBegan(0);});
        led1Button.onClick.RemoveListener(delegate{OnCelluloTouchBegan(1);});
        led2Button.onClick.RemoveListener(delegate{OnCelluloTouchBegan(2);});
        led3Button.onClick.RemoveListener(delegate{OnCelluloTouchBegan(3);});
        led4Button.onClick.RemoveListener(delegate{OnCelluloTouchBegan(4);});
        led5Button.onClick.RemoveListener(delegate{OnCelluloTouchBegan(5);});
   }
}
