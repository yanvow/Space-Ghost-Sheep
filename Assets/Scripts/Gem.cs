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
        
    }

    void OnTriggerEnter(Collider other){
        if(other.transform.parent.gameObject.CompareTag("CelluloDog") && !GameManager.isPlayingMiniGame){
            gameObject.SetActive(false);
            other.transform.parent.gameObject.GetComponent<MoveWithKeyboardBehavior>().hasGem = true;
            collectAudio.Play();
        }
    }
}