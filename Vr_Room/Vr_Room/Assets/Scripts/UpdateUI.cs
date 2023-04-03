using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UpdateUI : MonoBehaviour
{
    //Upgrades
    public GameObject maksUpgrade;

    public GameObject vaccineUpgrade;

    public GameObject goggles;
    private bool hasGoggles = false;

    //Health
    public GameObject health;
    private string healthAmount;

    //Coins
    public GameObject coins;
    public string coinAmount;

    //GameOver Panel
    public GameObject gameOver;
    public TextMeshProUGUI timerText;

    private int time = 200;//50 ticks per second 200 => 4 seconds

    public void addCoins(int addedCoins = 1){
        int coins_  = int.Parse(coinAmount.ToString()) + addedCoins;
        coinAmount = coins_.ToString();
        coins.GetComponent<TextMeshProUGUI>().text = coinAmount;
      
    }

    public void removeCoins(int removedCoins = 5){
        int coins_  = int.Parse(coinAmount.ToString()) - removedCoins;
        if(coins_ <0){
            coins_ = 0;
        }
        coins.GetComponent<TextMeshProUGUI>().text = coins_.ToString();
        coinAmount =  coins_.ToString();
    }

    public void takeDamage(int dmgAmount = 99){

        if(maksUpgrade.activeSelf){
            dmgAmount -= 33;
        }

        if(vaccineUpgrade.activeSelf){
            dmgAmount -=33;
        }

        int health_  = int.Parse(healthAmount.ToString()) - dmgAmount;
        healthAmount = health_.ToString();
        health.GetComponent<TextMeshProUGUI>().text = healthAmount;
    }

    public void restoreHealth(){
        healthAmount = "99";
        health.GetComponent<TextMeshProUGUI>().text = healthAmount;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        coinAmount = coins.GetComponent<TextMeshProUGUI>().text;
        healthAmount = "99";
        health.GetComponent<TextMeshProUGUI>().text = healthAmount;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        //Health <=0
        if(int.Parse(healthAmount.ToString()) <= 0 )
        {
            gameOver.SetActive(true);
            time--;
            timerText.text = Mathf.FloorToInt(time/50).ToString();

            if(time <= 0){
                gameOver.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                time = 200;
            }
            //Time.timeScale = 0;
        } else{
            time = 200;
            //Time.timeScale = 1;
        }
    }
}
