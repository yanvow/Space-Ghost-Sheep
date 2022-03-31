using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    public 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other){
        Debug.Log(other.transform.parent.gameObject.name + " triggers.");
        if(other.transform.parent.gameObject.tag == "CelluloSheep"){
            Debug.Log("trigger !");
        }
    }
}
