using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getDiscardNum : MonoBehaviour
{

    Text text;
    discard table;
    public bool isDone = false;

    private void OnEnable()
    {
        
        text = GetComponent<Text>();
        table = GameObject.Find("table").GetComponent<discard>();

        StartCoroutine(dialog(table.numDiscard != 0));

    }

    private void Update()
    {
        if (isDone)
        {

            text.text = "Discard " + table.numDiscard + " cards";

        }


    }

    //types text several times
    IEnumerator dialog(bool check) {

        yield return typingText("What a shame");
        yield return new WaitForSeconds(1);
        yield return typingText("you lost");
        yield return new WaitForSeconds(1);

        if (!check)
        {

            yield return typingText("discard more cards");
            yield return new WaitForSeconds(1);

        }

        else {

            yield return typingText("You've lost Enough cards");
            yield return new WaitForSeconds(1);

        }


        isDone = true;


    }

    //types current text
    IEnumerator typingText(string message) {

        for (int i = 1; i <= message.Length; i++) { 
        
            text.text = message.Substring(0,i);

            yield return new WaitForSeconds(.05f);
        
        }
    
    }

}
