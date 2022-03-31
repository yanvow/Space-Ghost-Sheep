using System.Linq;
using UnityEngine;

public class GhostSheepBehavior : AgentBehaviour
{    
    public void Start(){
    }

    void Update()
    {
        tag = GetComponent<CelluloAgent>().tag;
        if(tag == "CelluloGhost"){
            GetComponent<CelluloAgent>().SetVisualEffect(0, Color.yellow, 0);
        }else if(tag == "CelluloSheep"){
            GetComponent<CelluloAgent>().SetVisualEffect(0, Color.green, 0);
        }
    }

    public override Steering GetSteering()
    {
        GameObject[] CelluloDogs;
        CelluloDogs = GameObject.FindGameObjectsWithTag("CelluloDog");


        Steering steering = new Steering();
        
        Vector3 position = transform.position;
        GameObject closest = null;
        float distance = Mathf.Infinity ;
        foreach (GameObject CelluloDog in CelluloDogs){
            Vector3 diff = CelluloDog.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance<20){    
                closest = CelluloDog;
                distance = curDistance;
            }
        }
        steering.linear = new  Vector3 (0,0,0);
        if (distance!= Mathf.Infinity){
        steering.linear = -(closest.transform.position - position) * agent.maxAccel;
        }
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear , agent.maxAccel));

       return steering;
    }
}