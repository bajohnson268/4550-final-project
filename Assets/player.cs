using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public List<card> hand;
    public List<Vector3> handPos;

    public deck deck;

    [HideInInspector]
    public card selectedCard;

    [HideInInspector]
    public Coroutine cameraMove;
    [HideInInspector]
    public Coroutine cameraRot;

    [HideInInspector]
    public int cardsInHand = 0;
    [HideInInspector]
    public int maxCards = 6;
    [HideInInspector]
    public int cardsPlaced = 0;

    private void Start()
    {

        if (FindObjectsOfType<player>().Length > 1)
        {

            Destroy(gameObject);

        }

        hand = new List<card>();
        DontDestroyOnLoad(this);

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.P)) {

            deck.shuffleDeck();
        
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetAxis("Mouse ScrollWheel") > 0) {

            if (cameraMove != null)
            {

                StopCoroutine(cameraMove);

            }

            if (cameraRot != null)
            {

                StopCoroutine(cameraRot);

            }

            cameraMove = StartCoroutine(movingStuff.move(GameObject.Find("Main Camera"), new Vector3(0, 0.5f, -0.5f)));
            cameraRot = StartCoroutine(movingStuff.rotate(GameObject.Find("Main Camera"), Quaternion.Euler(30,0,0)));

        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            //Debug.Log("move Cam");
            if (cameraMove != null)
            {

                StopCoroutine(cameraMove);

            }

            if (cameraRot != null)
            {

                StopCoroutine(cameraRot);

            }

            cameraMove = StartCoroutine(movingStuff.move(GameObject.Find("Main Camera"), new Vector3(0, 0, -1)));
            cameraRot = StartCoroutine(movingStuff.rotate(GameObject.Find("Main Camera"), Quaternion.Euler(0, 0, 0)));

            selectedCard = null;

        }

    }

    public bool drawCard() {

        if (deck.cards.Count > 0 && cardsInHand < maxCards) {

            deck.cards[0].inHand = true;
            cardsInHand++;
            hand.Add(deck.cards[0]);
            deck.cards.RemoveAt(0);
            hand[hand.Count - 1].origPos = transform.position + handPos[hand.Count - 1];
            StartCoroutine(movingStuff.move(hand[hand.Count - 1].gameObject, transform.position + handPos[hand.Count - 1]));
            StartCoroutine(movingStuff.rotate(hand[hand.Count - 1].gameObject, Quaternion.identity));
            return true;
        
        }

        return false;
    
    }

    public void resetPlayer() { 

        cardsInHand = 0;
        maxCards = 6;
        cardsPlaced = 0;
    
    }

}
