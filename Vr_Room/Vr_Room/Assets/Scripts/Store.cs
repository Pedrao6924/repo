using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{

    public int cost;
    public GameObject uiObject;
    public UpdateUI UI;

    private string playerCoins;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            if(int.Parse(playerCoins.ToString())>= cost){
                transaction();
            }
        }
    }

    private void transaction(){
        if(uiObject.activeSelf){
            return;
        }

        UI.removeCoins(cost);
        uiObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
       playerCoins =  UI.coinAmount;
    }

    // Update is called once per frame
    void Update()
    {
        playerCoins =  UI.coinAmount;
    }
}
