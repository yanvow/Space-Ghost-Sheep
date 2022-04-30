using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public AudioSource collectAudio;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      /* // change position of the gem
        float seconds = Mathf.FloorToInt(Time.time);
        if (seconds % 120 == 10){  
            transform.position = new Vector3(Random.Range(0,26)-13, transform.position.y, Random.Range(0,18)-9);
            gameObject.SetActive(true);
        } 
        
         if (seconds % 120 == 0){  
            gameObject.SetActive(false);
        } */
    }

    void OnTriggerEnter(Collider other){
        if(other.transform.parent.gameObject.CompareTag("CelluloDog")){
            gameObject.SetActive(false);
            other.transform.parent.gameObject.GetComponent<MoveWithKeyboardBehavior>().hasGem = true;
            collectAudio.Play();
        }
    }
}