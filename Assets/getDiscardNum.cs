using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getDiscardNum : MonoBehaviour
{

    Text text;
    discard table;

    private void Start()
    {
        
        text = GetComponent<Text>();
        table = GameObject.Find("table").GetComponent<discard>();

    }

    private void Update()
    {

        text.text = "Discard " + table.numDiscard + " cards";

    }

}
