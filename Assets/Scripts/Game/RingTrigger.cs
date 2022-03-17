using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other){
        if (other.transform.parent.gameObject.CompareTag("CelluloDog"))
        {
            Debug.Log("CelluloDog triggers.");
        }else{
            Debug.Log(other.transform.parent.gameObject.name + " triggers.");
        }
    }
}
