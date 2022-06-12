using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormBehavior : AgentBehaviour
{
    public GameObject ring;
    public GameObject square;
    public GameObject star;
    public GameObject magic_ring;

    public AudioSource incrementAudio;

    public GameObject FormsMenu;
    public GameObject MiniGameWon;
    public GameObject MiniGameLost;

    private int checkpointCount;

    private bool ringMode;
    private bool starMode;
    private bool squareMode;

    IEnumerator co;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CelluloAgent>().SetGoalPosition(7f, -8.7f, 185f);
        starMode = false;
        ringMode = false;
        squareMode = false;
        checkpointCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameEnter(){
        co = waiter();
        StartCoroutine(co);
    }

    private bool isRing(){
        if(ringMode && checkpointCount == 4){ return false;}
        if(!ringMode){
            Debug.Log("Lost!");
            MiniGameLost.SetActive(true);
            StartCoroutine(gameLost());
            GameManager.isMiniGamefinished = true;
            magic_ring.SetActive(true);
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    private bool isStar(){
        if(starMode && checkpointCount == 4){ return false;}
        if(!starMode){
            Debug.Log("Lost!");
            MiniGameLost.SetActive(true);
            StartCoroutine(gameLost());
            GameManager.isMiniGamefinished = true;
            magic_ring.SetActive(true);
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    private bool isSquare(){
        if(squareMode && checkpointCount == 4){ return false;}
        if(!squareMode){
            Debug.Log("Lost!");
            MiniGameLost.SetActive(true);
            StartCoroutine(gameLost());
            GameManager.isMiniGamefinished = true;
            magic_ring.SetActive(true);
            StopCoroutine(co);
            return false;
        }
        else { return true;}
    }

    IEnumerator gameLost()
    {
        yield return new WaitForSeconds(2);
        MiniGameLost.SetActive(false);
    }

    IEnumerator waiter()
    {
        FormsMenu.SetActive(true);
        yield return new WaitForSeconds(6);
        Debug.Log("Game has started");
        FormsMenu.SetActive(false);
        yield return new WaitForSeconds(4);
        Debug.Log("Game is playing");
        magic_ring.SetActive(false);
        yield return new WaitForSeconds(2);

        Debug.Log("Ring");
        ring.SetActive(true);
        ringMode = true;
        GetComponent<CelluloAgent>().SetGoalPosition(7f, -8.7f, 185f);
        yield return new WaitWhile(isRing);
        ring.SetActive(false);
        checkpointCount = 0;

        Debug.Log("Square");
        square.SetActive(true);
        squareMode = true;
        GetComponent<CelluloAgent>().SetGoalPosition(7f, -8.7f, 185f);
        yield return new WaitWhile(isSquare);
        square.SetActive(false);
        checkpointCount = 0;

        Debug.Log("Star");
        star.SetActive(true);
        starMode = true;
        GetComponent<CelluloAgent>().SetGoalPosition(7f, -8.7f, 185f);
        yield return new WaitWhile(isSquare);
        star.SetActive(false);
        checkpointCount = 0;

        yield return new WaitForSeconds(2);

        MiniGameWon.SetActive(true);
        yield return new WaitForSeconds(2);
        GetComponent<ScoreManager>().incrementScore();
        incrementAudio.Play();
        MiniGameWon.SetActive(false);
        magic_ring.SetActive(true);
        GameManager.isMiniGamefinished = true;
    }

    void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name + " trigger.");
        if(other.gameObject.name == "InnerCylinder" && ringMode){
            Debug.Log("Destroy");
            Destroy(other.transform.parent.gameObject);
            ringMode = false;
        }
        if(other.gameObject.name == "InnerCube" && squareMode){
            Debug.Log("Destroy");
            Destroy(other.transform.parent.gameObject);
            squareMode = false;
        }
        if(other.gameObject.name == "InnerStar" && starMode){
            Debug.Log("Destroy");
            Destroy(other.transform.parent.gameObject);
            starMode = false;
        }
    }

   void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + " trigger exit.");
        if(other.gameObject.name == "OuterCylinder" && ringMode){
            Debug.Log("Destroy");
            Destroy(other.transform.parent.gameObject);
            ringMode = false;
        }
        if(other.gameObject.name == "OuterCube" && squareMode){
            Debug.Log("Destroy");
            Destroy(other.transform.parent.gameObject);
            squareMode = false;
        }
        if(other.gameObject.name == "OuterStar" && starMode){
            Debug.Log("Destroy");
            Destroy(other.transform.parent.gameObject);
            starMode = false;
        }
        if((other.gameObject.name == "Checkpoint1" || other.gameObject.name == "Checkpoint2"
            || other.gameObject.name == "Checkpoint3" || other.gameObject.name == "Checkpoint4")){
            Debug.Log("Destroy");
            Destroy(other.gameObject);
            checkpointCount++;
        }
    }
}
