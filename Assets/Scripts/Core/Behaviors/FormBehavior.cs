using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormBehavior : AgentBehaviour
{
    public GameObject ring;
    public GameObject square;
    public GameObject star;
    public GameObject magic_ring;

    public GameObject FormsMenu;

    private bool ringMode;
    private bool starMode;
    private bool squareMode;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CelluloAgent>().SetGoalPosition(7f, -8.7f, 185f);
        starMode = false;
        ringMode = false;
        squareMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(starMode){

        }
    }

    public void GameEnter(){
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("Game has started");
        FormsMenu.SetActive(true);
        yield return new WaitForSeconds(4);
        Debug.Log("Game is playing");
        FormsMenu.SetActive(false);
        magic_ring.SetActive(false);
        
        yield return new WaitForSeconds(2);

        Debug.Log("Ring");
        ring.SetActive(true);
        ringMode = true;
        yield return new WaitForSeconds(20);
        GetComponent<CelluloAgent>().SetGoalPosition(7f, -8.7f, 185f);
        if(ringMode){
            ring.SetActive(false);
        }
        Debug.Log("Square");
        square.SetActive(true);
        squareMode = true;
        yield return new WaitForSeconds(20);
        GetComponent<CelluloAgent>().SetGoalPosition(7f, -8.7f, 185f);
        if(squareMode){
            square.SetActive(false);
        }
        Debug.Log("Star");
        star.SetActive(true);
        starMode = true;
        yield return new WaitForSeconds(20);
        if(starMode){
            star.SetActive(false);
        }
        GetComponent<ScoreManager>().incrementScore();
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
        //other.attachedRigidbody.GetComponent<CelluloAgent>().SetVisualEffect(0, color, 0);
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
        }
    }
}
