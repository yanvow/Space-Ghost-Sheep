using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonBehavior : AgentBehaviour
{
    private int val;

    // Start is called before the first frame update
    void Start()
    {
        val = 0;
    }

    // Update is called once per frame
    void Update()
    {

        float time = Time.timeSinceLevelLoad;
        //if(time % 10 == 0){   
        val += 1;//index de la led a allumer
        StartCoroutine(Fade());
        //}
       /*  for(int i = 0; i < 6; i++){
            if(i != val){
                GetComponent<CelluloAgent>().SetVisualEffect(VisualEffect.VisualEffectConstSingle, Color.white, i);
            }
        } */
       
    }

    //key <=> index de la led pressed
    public override void OnCelluloTouchBegan(int key){
        Debug.Log("Pressed !" + key);
    }

    IEnumerator Fade(){
        
        val = val % 5;
        Color color = Color.red;
        
        GetComponent<CelluloAgent>().SetVisualEffect(VisualEffect.VisualEffectConstSingle, color, val);
        
        yield return new WaitForSeconds(.1f);
    }
}
