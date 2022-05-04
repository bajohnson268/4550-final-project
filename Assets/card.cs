using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{

    public enum cardType {

        KNIGHT,
        SWORDMAN,
        ARCHER,
        WIZARD,
        BUFF_HEALTH,
        BUFF_ATTACK,
        DEBUFF_HEALTH, 
        DEBUFF_ATTACK

    }

    public cardType type;

    //bools to check where card is and what it;s for
    public bool inHand = false;
    public bool selected = false;
    public bool isReward = false;
    public bool isDiscard = false;

    //positions to move card when hovered over
    public Vector3 origPos;
    Vector3 offset = new Vector3(0, .35f, 0);

    //audio clip to play when drawed
    public AudioClip draw;

    //coroutines to move and rotate
    public Coroutine moving;
    public Coroutine rotating;

    private void OnMouseEnter()
    {

        //if hovered over and in hand move it up
        if (inHand) {

            if (moving != null) { 
            
                StopCoroutine(moving);

            }

            moving = StartCoroutine(movingStuff.move(this.gameObject, origPos + offset));

        }

    }

    private void OnMouseExit()
    {

        //if not hovered over and in hand move it up
        if (inHand){

            if (moving != null){

                StopCoroutine(moving);

            }

            moving = StartCoroutine(movingStuff.move(this.gameObject, origPos));

        }

    }

    private void OnMouseDown()
    {

        //if clicked in hand 
        if (inHand)
        {
            //gets player
            player player = GameObject.Find("hand").GetComponent<player>();

            //makes this card selected
            selected = true;
            GameObject.Find("hand").GetComponent<player>().selectedCard = this;

            //checks camera movement
            if (player.cameraMove != null)
            {

                StopCoroutine(player.cameraMove);

            }

            if (player.cameraRot != null)
            {

                StopCoroutine(player.cameraRot);

            }

            //moves camera to get better view of board
            player.cameraMove = StartCoroutine(movingStuff.move(GameObject.Find("Main Camera"), new Vector3(0, 0.5f, -0.5f)));
            player.cameraRot = StartCoroutine(movingStuff.rotate(GameObject.Find("Main Camera"), Quaternion.Euler(30, 0, 0)));

        }

        //if its a reward card
        else if (isReward && GameObject.Find("table").GetComponent<rewards>().cardsDrawn < GameObject.Find("table").GetComponent<rewards>().maxCards)
        {

            //adds to deck
            GameObject.Find("deck").GetComponent<deck>().addCard(this);
            gameObject.transform.SetParent(GameObject.Find("deck").transform);

            //no longer reward
            this.isReward = false;

            //updates cardsdrawn
            GameObject.Find("table").GetComponent<rewards>().cardsDrawn++;

            //plays audio
            GetComponent<AudioSource>().PlayOneShot(draw);

        }

        //if it's a discard
        else if (isDiscard && GameObject.Find("table").GetComponent<discard>().numDiscard > 0) {

            //remove from deck
            GameObject.Find("deck").GetComponent<deck>().cards.Remove(this);

            //play audio
            GetComponent<AudioSource>().PlayOneShot(draw);

            //checks if moving
            if (moving != null) {

                StopCoroutine(moving);
            
            }

            //moves card
            moving = StartCoroutine(movingStuff.move(gameObject, new Vector3(5, gameObject.transform.position.y, gameObject.transform.position.z)));

            //delays destroy
            StartCoroutine(delayDestroy());

            //updates number to discard
            GameObject.Find("table").GetComponent<discard>().numDiscard--;

        }

    }

    IEnumerator delayDestroy() { 
    
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    
    }

}
