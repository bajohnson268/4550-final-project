using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deck : MonoBehaviour
{

    public List<card> cards;
    public bool isSpawned;

    private void Start()
    {
        //checks if other deck exists and if so destroies itself
        if (FindObjectsOfType<deck>().Length > 1) { 
        
            Destroy(gameObject);
        
        }

        //dont destroy on load
        DontDestroyOnLoad(this);

    }

    public void addCard(card cardToAdd) {

        //adds card to deck
        cards.Add(cardToAdd);

        //plays audio
        cardToAdd.GetComponent<AudioSource>().PlayOneShot(cardToAdd.draw);

        //no longer in hand
        cardToAdd.inHand = false;

        //moves card
        cardToAdd.moving = StartCoroutine(movingStuff.move(cardToAdd.gameObject, this.transform.position));
        cardToAdd.rotating = StartCoroutine(movingStuff.rotate(cardToAdd.gameObject, Quaternion.Euler(-90,0,180)));

    }

    public card removeCard() {

        //checks if cards in deck
        if (cards.Count > 0) {

            //removes the top card
            card returnCard = cards[0];
            cards.RemoveAt(0);
            return returnCard;
        
        }

        //returns null if no card
        return null;
    
    }

    public void spawnDeck() {

        //sets height of deck
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, -.5f + cards.Count*.001f, gameObject.transform.position.z);
        //count to move cards
        int count = 0;

        //for al cards
        foreach (card obj in cards) { 
        
            //set active to true
            obj.gameObject.SetActive(true);

            //stops moving and rotating
            if (obj.moving != null) {

                StopCoroutine(obj.moving);
            
            }

            if (obj.rotating != null)
            {

                StopCoroutine(obj.rotating);

            }

            //sets position and rotation
            obj.gameObject.transform.rotation = Quaternion.Euler(-90f, Random.Range(-10f, 10f), 180f);
            obj.gameObject.transform.position = this.transform.position + new Vector3(0,-count++ * .001f,0);
           

        }
    
    }

    public void despawnDeck() {

        //sets all cards to inactive
        foreach (card obj in cards)
        {

            obj.gameObject.SetActive(false);

        }
    }

    public void shuffleDeck() {

        //shuffles card order in deck
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, cards.Count);
            card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }

    }

}
