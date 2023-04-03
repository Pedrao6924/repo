using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public UpdateUI UI;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Coin"){
            UI.addCoins(1);
            StartCoroutine(respawnObject(other, 5f));
        }

        if(other.tag == "Covid"){
            UI.takeDamage();
            Destroy(other.gameObject);
        }
   }

    IEnumerator respawnObject(Collider other, float seconds)
    {
        other.gameObject.SetActive(false);
        yield return new WaitForSeconds(seconds);
        other.gameObject.SetActive(true);
    }

}
