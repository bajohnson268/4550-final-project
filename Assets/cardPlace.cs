using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cardPlace : MonoBehaviour
{
    board board;
    public card card;
    player player;

    public bool isPlayerPlace;

    private void Start()
    {

        player = GameObject.Find("hand").GetComponent<player>();
        board = GameObject.Find("table").GetComponent<board>();
    }

    private void OnMouseDown()
    {

        if (player.selectedCard != null && card == null && isPlayerPlace) { 
        
            //sets the card to the place
            card = player.selectedCard;

            //plays the darwing sound effect
            card.GetComponent<AudioSource>().PlayOneShot(card.draw);

            //puts the card in then active scene to be destroyed 
            card.gameObject.transform.SetParent(null, false);
            SceneManager.MoveGameObjectToScene(card.gameObject, SceneManager.GetActiveScene());

            //moves and rotates card
            StartCoroutine(movingStuff.move(player.selectedCard.gameObject, gameObject.transform.position + new Vector3(0, 0.01f, 0)));
            StartCoroutine(movingStuff.rotate(player.selectedCard.gameObject, Quaternion.Euler(90,0,0),24));

            //removes card from hand
            player.hand.Remove(card);
            board.playerRow[transform.GetSiblingIndex()] = card;
            card.inHand = false;

            //updates cardsplaced and makes selected card null
            player.cardsPlaced++;
            player.selectedCard = null;

        }

    }

}
