using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticFeedbackTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public float simpleXIntensity = 10f;
    public float simpleYIntensity = 10f;
    public float simpleThetaIntensity = 10f;
    public long simplePeriod = 2;
    public long simpleDuration = 20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        Debug.Log(other.transform.parent.gameObject.name + "star triggers.");
        other.attachedRigidbody.GetComponent<Cellulo>().SimpleVibrate(simpleXIntensity, simpleYIntensity, simpleThetaIntensity, simplePeriod, simpleDuration);
    }
}
