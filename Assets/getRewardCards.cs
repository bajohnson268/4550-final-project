using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getRewardCards : MonoBehaviour
{
    Text text;
    rewards table;
    bool isDone = false;

    private void Start()
    {

        text = GetComponent<Text>();
        table = GameObject.Find("table").GetComponent<rewards>();

        StartCoroutine(dialog());

    }

    private void Update()
    {
        if (isDone)
        {

            text.text = "Draw " + (table.maxCards - table.cardsDrawn) + " cards";

        }


    }

    IEnumerator dialog()
    {

        yield return typingText("Congrats");
        yield return new WaitForSeconds(1);
        yield return typingText("you won");
        yield return new WaitForSeconds(1);
        yield return typingText("draw some cards");
        yield return new WaitForSeconds(1);
        isDone = true;


    }

    IEnumerator typingText(string message)
    {

        for (int i = 1; i <= message.Length; i++)
        {

            text.text = message.Substring(0, i);

            yield return new WaitForSeconds(.05f);

        }

    }
}
