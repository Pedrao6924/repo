using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastPowers : MonoBehaviour
{

    public GameObject player;
    public UpdateUI UI;

    public void destroyObject(GameObject obj){
        UI.addCoins(10);
        obj.SetActive(false);
        StartCoroutine(respawnObjInSeconds(obj,10f));
    }

    public void teleportToAnchor(GameObject obj){
        player.transform.position = obj.transform.position;
    }

    IEnumerator respawnObjInSeconds(GameObject obj_,float sec){
        yield return new WaitForSecondsRealtime(sec);
        obj_.SetActive(true);
    }
}
