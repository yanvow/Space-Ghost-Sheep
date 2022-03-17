using System.Linq;
using UnityEngine;

public class GhostSheepBehavior : AgentBehaviour
{    
    public void Start(){
    }
    public override Steering GetSteering()
    {
        GameObject[] CelluloDogs;
        CelluloDogs = GameObject.FindGameObjectsWithTag("CelluloDog");
        Vector3 position = transform.position;
        Vector3 diff = new Vector3(0, 0, 0);
        foreach (GameObject CelluloDog in CelluloDogs){
            diff -= CelluloDog.transform.position - position;
        }

        Steering steering = new Steering();
        steering.linear = diff * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear , agent.maxAccel));
        return steering;
    }
}
