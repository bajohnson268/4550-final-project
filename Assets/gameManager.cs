using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    player player;

    float lastRedraw;
    float redrawCooldown = 1.5f;

    Coroutine redrawing;

    public card[] cards;

    private void Start()
    {

        player = GameObject.Find("hand").GetComponent<player>();
        player.deck.spawnDeck();
        player.deck.shuffleDeck();

        StartCoroutine(enemyCards());

    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.E) && lastRedraw < Time.time && redrawing == null && player.maxCards != 0 && player.cardsPlaced == 0) {

            if (player.maxCards == 6) { 
            
                StartCoroutine(drawCards(5));
                player.maxCards = 5;
            
            }

            else
            {

                redrawing = StartCoroutine(redraw());

            }

            lastRedraw = Time.time + redrawCooldown;

        }

        if (Input.GetKeyDown(KeyCode.N)) {

            foreach (card obj in player.hand) {

                player.deck.addCard(obj);
            
            }

            while (player.hand.Count > 0)
            {

                player.hand.RemoveAt(0);

            }

            StartCoroutine(delay(2, "discard"));

        }

        if (Input.GetKeyDown(KeyCode.Y)) {

            foreach (card obj in player.hand)
            {

                player.deck.addCard(obj);

            }

            while (player.hand.Count > 0) { 
                
                player.hand.RemoveAt(0);
            
            }

            StartCoroutine(delay(2, "rewards"));

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
        player.maxCards--;

        redrawing = null;

    }

    IEnumerator enemyCards() {

        yield return new WaitForSeconds(.5f);

        board table = GameObject.Find("table").GetComponent<board>();

        if (difficulty.diff == 0)
        {

            card temp = Instantiate(cards[Random.Range(0, 4)].gameObject).GetComponent<card>();

            table.enemyRow[2] = temp;
            temp.gameObject.transform.position = table.gameObject.transform.GetChild(7).gameObject.transform.position + new Vector3(0, 0.01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            temp = Instantiate(cards[Random.Range(0, 4)].gameObject).GetComponent<card>();

            table.enemyRow[1] = temp;
            temp.gameObject.transform.position = table.gameObject.transform.GetChild(6).gameObject.transform.position + new Vector3(0, 0.01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            if (Random.Range(0, 2) == 1)
            {

                temp = Instantiate(cards[Random.Range(4, 8)].gameObject).GetComponent<card>();

                table.enemyRow[3] = temp;
                temp.gameObject.transform.position = table.gameObject.transform.GetChild(8).gameObject.transform.position + new Vector3(0, 0.01f, 0);
                temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            }

        }

        else if (difficulty.diff == 1)
        {

            card temp = Instantiate(cards[Random.Range(0, 4)].gameObject).GetComponent<card>();

            table.enemyRow[2] = temp;
            temp.gameObject.transform.position = table.gameObject.transform.GetChild(7).gameObject.transform.position + new Vector3(0, 0.01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            temp = Instantiate(cards[Random.Range(0, 4)].gameObject).GetComponent<card>();

            table.enemyRow[1] = temp;
            temp.gameObject.transform.position = table.gameObject.transform.GetChild(6).gameObject.transform.position + new Vector3(0, 0.01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            temp = Instantiate(cards[Random.Range(0, 4)].gameObject).GetComponent<card>();

            table.enemyRow[3] = temp;
            temp.gameObject.transform.position = table.gameObject.transform.GetChild(8).gameObject.transform.position + new Vector3(0, 0.01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            if (Random.Range(0, 2) == 1)
            {

                temp = Instantiate(cards[Random.Range(4, 8)].gameObject).GetComponent<card>();

                table.enemyRow[4] = temp;
                temp.gameObject.transform.position = table.gameObject.transform.GetChild(9).gameObject.transform.position + new Vector3(0, 0.01f, 0);
                temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            }

        }


        else
        {

            card temp = Instantiate(cards[Random.Range(0, 4)].gameObject).GetComponent<card>();

            table.enemyRow[2] = temp;
            temp.gameObject.transform.position = table.gameObject.transform.GetChild(7).gameObject.transform.position + new Vector3(0, 0.01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            temp = Instantiate(cards[Random.Range(0, 4)].gameObject).GetComponent<card>();

            table.enemyRow[1] = temp;
            temp.gameObject.transform.position = table.gameObject.transform.GetChild(6).gameObject.transform.position + new Vector3(0, 0.01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            temp = Instantiate(cards[Random.Range(0, 4)].gameObject).GetComponent<card>();

            table.enemyRow[3] = temp;
            temp.gameObject.transform.position = table.gameObject.transform.GetChild(8).gameObject.transform.position + new Vector3(0, 0.01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            temp = Instantiate(cards[Random.Range(0, 4)].gameObject).GetComponent<card>();

            table.enemyRow[0] = temp;
            temp.gameObject.transform.position = table.gameObject.transform.GetChild(5).gameObject.transform.position + new Vector3(0, 0.01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            if (Random.Range(0, 2) == 1)
            {

                temp = Instantiate(cards[Random.Range(4, 8)].gameObject).GetComponent<card>();

                table.enemyRow[4] = temp;
                temp.gameObject.transform.position = table.gameObject.transform.GetChild(9).gameObject.transform.position + new Vector3(0, 0.01f, 0);
                temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            }

        }

    }

    IEnumerator delay(float seconds, string scene) { 
    
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(scene);
    
    }

}
