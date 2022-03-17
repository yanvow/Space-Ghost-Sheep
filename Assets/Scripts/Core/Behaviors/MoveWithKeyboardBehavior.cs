using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input Keys
public enum InputKeyboard{
    arrows = 0, 
    wasd = 1
}
public class MoveWithKeyboardBehavior : AgentBehaviour
{
    public InputKeyboard inputKeyboard; 

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        float horizontal;
        float vertical;
        if(inputKeyboard == 0){
            horizontal = Input.GetAxis("Horizontal_Arrow");
            vertical = Input.GetAxis("Vertical_Arrow");
        }else{
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
        steering.linear = new Vector3(horizontal, 0, vertical) * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear , agent.maxAccel));
        return steering;
    }
}
