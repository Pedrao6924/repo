using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRayCast : MonoBehaviour
{

    private int tally = 0;
    private int seconds;
    private string tag = "Untagged";
    private string propId = "NULL";

    public RayCastPowers powers;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("Hits:" + tally);
        Debug.Log("Seconds" + tally/50);
        seconds = tally/50;

        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit)) {
            
            Transform objectHit = hit.transform;
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
            Debug.DrawRay(transform.position, forward, Color.green);

            if(hit.transform.tag == "Anchor"){
                string id = hit.transform.GetComponentInChildren<PropIdentifier>().id;
                if(propId != id){
                    propId = id;
                    tally = 0;
                }
                //Debug.Log("Anchor" + id);
                tally++;

                if(seconds > 0.5f){   
                    powers.teleportToAnchor(hit.transform.gameObject);
                    tally = 0;
                }
            }

            if(hit.transform.tag == "Covid"){
                string id = hit.transform.GetComponentInChildren<PropIdentifier>().id;
                if(propId != id){
                    propId = id;
                    tally = 0;
                }
                Debug.Log("Covid");
                tally++;

                if(seconds > 0.5f){   
                    powers.destroyObject(hit.transform.gameObject);
                    tally = 0;

                }
            }
        } 
    }
}
