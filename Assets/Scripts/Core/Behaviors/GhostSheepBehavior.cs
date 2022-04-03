using System.Linq;
using UnityEngine;

public class GhostSheepBehavior : AgentBehaviour
{    
    public AudioSource sheepAudio;
    public AudioSource ghostAudio; 
    
    void Start()
    {
    
    }

    void Update()
    {
        changeMode();
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
            if (curDistance < distance){
                if ((tag == "CelluloSheep" && curDistance < 20) || tag == "CelluloGhost"){    
                    closest = CelluloDog;
                    distance = curDistance;
                }
            } 
        }
        steering.linear = new  Vector3 (0,0,0);

        if (distance != Mathf.Infinity){
            if(tag == "CelluloSheep"){
                steering.linear = -(closest.transform.position - position) * agent.maxAccel;
            }else {
                steering.linear = (closest.transform.position - position) * (agent.maxAccel-10);
            }
        }
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear , agent.maxAccel));

       return steering;
    }
    public void changeMode(){
        float seconds = Mathf.FloorToInt(Time.timeSinceLevelLoad );
        if (seconds % 56 < 28){
            GetComponent<CelluloAgent>().tag = "CelluloSheep";
        }else{
            GetComponent<CelluloAgent>().tag = "CelluloGhost";
        }
        if(Time.timeScale != 0){
            if(seconds % 56 == 0){
                sheepAudio.Play();
            }else if(seconds % 56 == 27){
                ghostAudio.Play();
            }
        } 
    }
}