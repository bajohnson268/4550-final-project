using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainTalking : MonoBehaviour
{

    Text text;

    private void Start()
    {
        
        text = GetComponent<Text>();
        StartCoroutine(typing("Choose wisely"));

    }

    public void noCardsText() {

        StartCoroutine(dialog());
    
    }

    IEnumerator dialog() {

        yield return StartCoroutine(typing("play a card..."));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(typing("Choose wisely"));

    }

    IEnumerator typing(string message) {

        for (int i = 1; i <= message.Length; i++)
        {

            text.text = message.Substring(0, i);

            yield return new WaitForSeconds(.05f);

        }
    }

}
