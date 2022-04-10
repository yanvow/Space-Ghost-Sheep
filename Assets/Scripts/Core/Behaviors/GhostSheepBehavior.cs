using System.Linq;
using UnityEngine;


public class GhostSheepBehavior : AgentBehaviour
{    
    public AudioSource sheepAudio;
    public AudioSource ghostAudio;
    public AudioSource decrementAudio;
    public void Start(){
        
    }

    void Update()
    {
        float seconds = Mathf.FloorToInt(Time.timeSinceLevelLoad);
        int m1 = Random.Range(0,100);
        int m2 = Random.Range(0,100);
        int m3 = Random.Range(0,100);
        if (m1==m2 && m2==m3) {
            changeMode();
        }
        tag = GetComponent<CelluloAgent>().tag;
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
        if (GetComponent<CelluloAgent>().tag == "CelluloSheep"){
            GetComponent<CelluloAgent>().tag = "CelluloGhost";
            ghostAudio.Play();
            GetComponent<CelluloAgent>().SetVisualEffect(0, Color.yellow, 0);
        }else {
            GetComponent<CelluloAgent>().tag = "CelluloSheep";
            sheepAudio.Play();
            GetComponent<CelluloAgent>().SetVisualEffect(0, Color.green, 0);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(tag == "CelluloGhost"){
            collisionInfo.gameObject.GetComponent<ScoreManager>().decrementScore();
            decrementAudio.Play();
        }
    }
}