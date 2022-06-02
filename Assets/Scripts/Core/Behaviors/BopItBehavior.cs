using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BopItBehavior : AgentBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float previous_angle = transform.localEulerAngles.y;
       float current_angle = transform.localEulerAngles.y;

    }

    public override void OnCelluloKidnapped(){
        Debug.Log("Kidnapped !");
    }

    public override void OnCelluloTouchBegan(int key){
        Debug.Log("Pressed :" + key + "!");
    }


}
