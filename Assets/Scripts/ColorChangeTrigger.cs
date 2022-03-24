using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeTrigger : MonoBehaviour
{
    public Color color = Color.green;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        Debug.Log(other.transform.parent.gameObject.name + "cube triggers.");
        other.attachedRigidbody.GetComponent<CelluloAgent>().SetVisualEffect(0, color, 0);
    }

}
