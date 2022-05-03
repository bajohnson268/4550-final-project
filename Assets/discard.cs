using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class discard : MonoBehaviour
{

    deck deck;
    cardPlace[] places = new cardPlace[8];

    player player;

    public int numDiscard;

    // Start is called before the first frame update
    void Start()
    {

        GameObject.Find("hand").GetComponent<player>().deck.spawnDeck();

        if (Random.Range(0, 4) == 1)
        {

            difficulty.diff++;

        }

        player = GameObject.Find("hand").GetComponent<player>();

        numDiscard = 5 - player.cardsPlaced;
        Debug.Log(player.cardsPlaced);

        deck = GameObject.Find("deck").GetComponent<deck>();

        for (int i = 0; i < 8; i++) { 
        
            places[i] = gameObject.transform.GetChild(i).GetComponent<cardPlace>();
        
        }

        foreach (card obj in deck.cards) {

            if (obj.type == card.cardType.KNIGHT) { 
            
                obj.moving = StartCoroutine(movingStuff.move(obj.gameObject,places[0].gameObject.transform.position + new Vector3(0,0.01f,0)));
                obj.rotating = StartCoroutine(movingStuff.rotate(obj.gameObject, Quaternion.Euler(90, 0, 0)));
            
            }

            else if (obj.type == card.cardType.WIZARD)
            {

                obj.moving = StartCoroutine(movingStuff.move(obj.gameObject, places[1].gameObject.transform.position + new Vector3(0, 0.01f, 0)));
                obj.rotating = StartCoroutine(movingStuff.rotate(obj.gameObject, Quaternion.Euler(90, 0, 0)));

            }

            else if (obj.type == card.cardType.ARCHER)
            {

                obj.moving = StartCoroutine(movingStuff.move(obj.gameObject, places[2].gameObject.transform.position + new Vector3(0, 0.01f, 0)));
                obj.rotating = StartCoroutine(movingStuff.rotate(obj.gameObject, Quaternion.Euler(90, 0, 0)));

            }

            else if (obj.type == card.cardType.SWORDMAN)
            {

                obj.moving = StartCoroutine(movingStuff.move(obj.gameObject, places[3].gameObject.transform.position + new Vector3(0, 0.01f, 0)));
                obj.rotating = StartCoroutine(movingStuff.rotate(obj.gameObject, Quaternion.Euler(90, 0, 0)));

            }

            else if (obj.type == card.cardType.BUFF_ATTACK)
            {

                obj.moving = StartCoroutine(movingStuff.move(obj.gameObject, places[4].gameObject.transform.position + new Vector3(0, 0.01f, 0)));
                obj.rotating = StartCoroutine(movingStuff.rotate(obj.gameObject, Quaternion.Euler(90, 0, 0)));

            }

            else if (obj.type == card.cardType.DEBUFF_ATTACK)
            {

                obj.moving = StartCoroutine(movingStuff.move(obj.gameObject, places[5].gameObject.transform.position + new Vector3(0, 0.01f, 0)));
                obj.rotating = StartCoroutine(movingStuff.rotate(obj.gameObject, Quaternion.Euler(90, 0, 0)));

            }

            else if (obj.type == card.cardType.BUFF_HEALTH)
            {

                obj.moving = StartCoroutine(movingStuff.move(obj.gameObject, places[6].gameObject.transform.position + new Vector3(0, 0.01f, 0)));
                obj.rotating = StartCoroutine(movingStuff.rotate(obj.gameObject, Quaternion.Euler(90, 0, 0)));

            }

            else
            {

                obj.moving = StartCoroutine(movingStuff.move(obj.gameObject, places[7].gameObject.transform.position + new Vector3(0, 0.01f, 0)));
                obj.rotating = StartCoroutine(movingStuff.rotate(obj.gameObject, Quaternion.Euler(90, 0, 0)));

            }

            obj.isDiscard = true;

        }

    }

    // Update is called once per frame
    void Update()
    {

        if (deck.cards.Count <= 0) {

            StartCoroutine(delay(2, "gameOver"));

        }

        else if (numDiscard <= 0) {

            StartCoroutine(delay(2, "gameScene"));
        
        }

    }

    IEnumerator delay(float seconds, string scene) { 
    
        yield return new WaitForSeconds(2);

        GameObject.Find("hand").GetComponent<player>().resetPlayer();

        SceneManager.LoadScene(scene);

    }
}
