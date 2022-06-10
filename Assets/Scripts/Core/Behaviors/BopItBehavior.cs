using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BopItBehavior : AgentBehaviour
{
    public AudioSource pushAudio;
    public AudioSource liftAudio;
    public AudioSource moveAudio;

    public GameObject BopItMenu;

    public Button liftButton;
    public Button pushButton;

    private bool isKidnapped;
    private bool isPushed;

    IEnumerator co;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CelluloAgent>().SetGoalPosition(7f, -8.7f, 185f);
        isKidnapped = false;
        isPushed = false;
    }

    // Update is called once per frame
    void Update()
    {
       //float previous_angle = transform.localEulerAngles.y;
       //float current_angle = transform.localEulerAngles.y;
       //GetComponent<CelluloAgent>().SetGoalPosition();

    }

    public void GameEnter(){
        co = waiter();
        StartCoroutine(co);
    }

    private bool isLifted(Vector3 t){
        if(isKidnapped){ return false;}
        if(isPushed || transform.position != t){
            Debug.Log("Lost!");
            GameManager.isMiniGamefinished = true;
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    private bool isPressed(Vector3 t){
        if(isPushed){ return false;}
        if(isKidnapped || transform.position != t){
            Debug.Log("Lost!");
            GameManager.isMiniGamefinished = true;
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    private bool isMoving(Vector3 t){
        if(transform.position != t){ return false;}
        if(isPushed || isKidnapped){
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
        BopItMenu.SetActive(true);
        yield return new WaitForSeconds(4);
        Debug.Log("Game is playing");
        BopItMenu.SetActive(false);

        yield return new WaitForSeconds(2);

        Debug.Log("lift");
        liftAudio.Play();
        Vector3 t = transform.position;
        yield return new WaitWhile(() => isLifted(t));
        isKidnapped = false;

        yield return new WaitForSeconds(2);

        Debug.Log("push");
        pushAudio.Play();
        t = transform.position;
        yield return new WaitWhile(() => isPressed(t));
        isPushed = false; 

        yield return new WaitForSeconds(2);

        Debug.Log("move");
        moveAudio.Play();
        t = transform.position;
        yield return new WaitWhile(() => isMoving(t));

        yield return new WaitForSeconds(4);
        GameManager.isMiniGamefinished = true;

        /* for (int i = 0; i < 10; i++){
            int j = Random.Range(0, 2);
            long s = 10;
            if (j == 0){
                liftAudio.Play();
                while(!kidnapped && s > 0){
                    s =- time % 10;
                }
                Debug.Log(s);
                kidnapped = false; 
            }else if (j == 1){
                pushAudio.Play();
                while(!touch && s > 0){
                    s =- time % 10;
                }
                Debug.Log(touch);
                touch = false; 
            }else if (j == 2){
                Debug.Log("move");
                moveAudio.Play();
                var t = transform.position;
                while(transform.position == t){
                    s =- time % 10;
                }
            }else{
                Debug.Log("error");
            }
        

         Debug.Log("Game has ended");
        //Beginaudio.Stop();
        }*/
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
