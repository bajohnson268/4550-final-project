using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deck : MonoBehaviour
{

    public List<card> cards;
    public bool isSpawned;

    public void addCard(card cardToAdd) {

        cards.Add(cardToAdd);

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

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + cards.Count*.01f, gameObject.transform.position.z);

        foreach (card obj in cards) { 
        
            obj.gameObject.SetActive(true);
            obj.gameObject.transform.rotation = Quaternion.Euler(-90f, 0f, 180f);
            obj.gameObject.transform.position = this.transform.position;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - .01f, gameObject.transform.position.z);

        }
    
    }

}
