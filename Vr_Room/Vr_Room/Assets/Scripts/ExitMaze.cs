using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMaze : MonoBehaviour
{

    public TeleportPlayer tpPlayer;
    public UpdateUI UI;

    public GameObject player;

    private void OnTriggerEnter(Collider other) {
        if(other.tag =="Player"){
            tpPlayer.teleport(player);
            UI.restoreHealth();
        }
    }
}
