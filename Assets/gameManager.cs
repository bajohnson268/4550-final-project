using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    player player;

    float lastRedraw;
    float redrawCooldown = 1.5f;

    Coroutine redrawing;

    private void Start()
    {

        player = GameObject.Find("hand").GetComponent<player>();
        player.deck.spawnDeck();
        player.deck.shuffleDeck();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)) {

            StartCoroutine(drawCards(5));
        
        }

        if (Input.GetKeyDown(KeyCode.R) && lastRedraw < Time.time && redrawing == null && player.maxCards != 1) {

            ////send all cards back to deck

            //foreach (card obj in player.hand) { 

            //    player.deck.addCard(obj);
            //    player.cardsInHand--;

            //}

            //while (player.hand.Count > 0) { 

            //    player.hand.RemoveAt(0);

            //}

            ////shuffle

            //player.deck.shuffleDeck();
            //player.deck.spawnDeck();

            ////redraw

            //StartCoroutine(drawCards(5));
            //player.deck.spawnDeck();

            redrawing = StartCoroutine(redraw());
            player.maxCards--;

            lastRedraw = Time.time + redrawCooldown;

        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            player.deck.spawnDeck();
        
        }

    }

    IEnumerator drawCards(int x) {

        for (int i = 0; i < x; i++) {

            Debug.Log(player.deck.cards.Count);

            player.drawCard();

            yield return new WaitForSeconds(.25f);
        
        }
    
    }

    IEnumerator redraw() {

        //send all cards back to deck

        foreach (card obj in player.hand)
        {

            player.deck.addCard(obj);
            player.cardsInHand--;

        }

        while (player.hand.Count > 0)
        {

            player.hand.RemoveAt(0);

        }

        yield return new WaitForSeconds(1.5f);

        player.deck.shuffleDeck();
        player.deck.spawnDeck();

        //redraw

        yield return StartCoroutine(drawCards(5));
        player.deck.spawnDeck();

        redrawing = null;

    }

}
