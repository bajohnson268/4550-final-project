using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deck : MonoBehaviour
{

    public List<card> cards;
    public bool isSpawned;

    private void Start()
    {

        if (FindObjectsOfType<deck>().Length > 1) { 
        
            Destroy(gameObject);
        
        }

        DontDestroyOnLoad(this);

    }

    public void addCard(card cardToAdd) {

        cards.Add(cardToAdd);
        cardToAdd.GetComponent<AudioSource>().PlayOneShot(cardToAdd.draw);
        cardToAdd.inHand = false;
        cardToAdd.moving = StartCoroutine(movingStuff.move(cardToAdd.gameObject, this.transform.position));
        cardToAdd.rotating = StartCoroutine(movingStuff.rotate(cardToAdd.gameObject, Quaternion.Euler(-90,0,180)));

    }

    public card removeCard() {

        if (cards.Count > 0) {

            card returnCard = cards[0];
            cards.RemoveAt(0);
            return returnCard;
        
        }

        return null;
    
    }

    public void spawnDeck() {

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, -.5f + cards.Count*.001f, gameObject.transform.position.z);
        int count = 0;

        foreach (card obj in cards) { 
        
            obj.gameObject.SetActive(true);
            if (obj.moving != null) {

                StopCoroutine(obj.moving);
            
            }

            if (obj.rotating != null)
            {

                StopCoroutine(obj.rotating);

            }
            obj.gameObject.transform.rotation = Quaternion.Euler(-90f, Random.Range(-10f, 10f), 180f);
            obj.gameObject.transform.position = this.transform.position + new Vector3(0,-count++ * .001f,0);
            //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - .001f, gameObject.transform.position.z);

        }
    
    }

    public void despawnDeck() {

        foreach (card obj in cards)
        {

            obj.gameObject.SetActive(false);

        }
    }

    public void shuffleDeck() {

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
