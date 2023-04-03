using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeLoadBar : MonoBehaviour
{
    public MainMenu menu;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value +=0.0002f;

        if(slider.value >= 1){
            menu.loadGame();
        }
    }
}
