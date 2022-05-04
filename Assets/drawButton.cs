using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drawButton : MonoBehaviour
{

    player player;

    Text text;

    private void Start()
    {

        player = GameObject.Find("hand").GetComponent<player>();
        text = GetComponent<Text>();

    }

    private void Update()
    {
        //updates draw based on how many you would draw
        if (player.maxCards == 6)
        {

            text.text = "Draw";

        }

        else if(player.maxCards > 0){ 
        
            text.text = "Redraw " + player.maxCards;
        
        }

    }

}
