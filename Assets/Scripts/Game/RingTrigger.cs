using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    public AudioSource incrementAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other){
        if(other.transform.parent.gameObject.CompareTag("CelluloSheep")){
            GameObject[] CelluloDogs;
            CelluloDogs = GameObject.FindGameObjectsWithTag("CelluloDog");
            Vector3 position = other.transform.parent.gameObject.transform.position;
            GameObject closest = null;
            float distance = Mathf.Infinity ;
            
            foreach (GameObject CelluloDog in CelluloDogs){
                Vector3 diff = CelluloDog.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance){
                    closest = CelluloDog;
                    distance = curDistance;
                }
            }
            closest.GetComponent<ScoreManager>().incrementScore();
            incrementAudio.Play();
        }
    }
}
