using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : AgentBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CelluloAgent>().SetGoalPosition(0.49f, -5.22f, 185f);
    }
}
