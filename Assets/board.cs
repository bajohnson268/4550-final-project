using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{

    public List<card> enemyRow;
    public List<card> playerRow;

    private void Start()
    {

        for (int i = 0; i < 5; i++) {

            playerRow.Add(gameObject.transform.GetChild(i).gameObject.GetComponent<card>());

        }

        for (int i = 5; i < 10; i++)
        {

            enemyRow.Add(gameObject.transform.GetChild(i).gameObject.GetComponent<card>());

        }



    }

}
