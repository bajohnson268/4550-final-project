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
    public bool inHand = false;
    public bool selected = false;
    public bool isReward = false;
    public bool isDiscard = false;

    public Vector3 origPos;
    Vector3 offset = new Vector3(0, .35f, 0);
    public AudioClip draw;

    public Coroutine moving;
    public Coroutine rotating;

    private void OnMouseEnter()
    {

        if (inHand) {

            if (moving != null) { 
            
                StopCoroutine(moving);

            }

            moving = StartCoroutine(movingStuff.move(this.gameObject, origPos + offset));

        }

    }

    private void OnMouseExit()
    {

        if (inHand){

            if (moving != null){

                StopCoroutine(moving);

            }

            moving = StartCoroutine(movingStuff.move(this.gameObject, origPos));

        }

    }

    private void OnMouseDown()
    {

        if (inHand)
        {
            player player = GameObject.Find("hand").GetComponent<player>();
            selected = true;
            GameObject.Find("hand").GetComponent<player>().selectedCard = this;

            if (player.cameraMove != null)
            {

                StopCoroutine(player.cameraMove);

            }

            if (player.cameraRot != null)
            {

                StopCoroutine(player.cameraRot);

            }

            player.cameraMove = StartCoroutine(movingStuff.move(GameObject.Find("Main Camera"), new Vector3(0, 0.5f, -0.5f)));
            player.cameraRot = StartCoroutine(movingStuff.rotate(GameObject.Find("Main Camera"), Quaternion.Euler(30, 0, 0)));

        }

        else if (isReward && GameObject.Find("table").GetComponent<rewards>().cardsDrawn < GameObject.Find("table").GetComponent<rewards>().maxCards)
        {

            GameObject.Find("deck").GetComponent<deck>().addCard(this);
            this.isReward = false;
            GameObject.Find("table").GetComponent<rewards>().cardsDrawn++;
            gameObject.transform.SetParent(GameObject.Find("deck").transform);
            GetComponent<AudioSource>().PlayOneShot(draw);

        }

        else if (isDiscard && GameObject.Find("table").GetComponent<discard>().numDiscard > 0) {

            GameObject.Find("deck").GetComponent<deck>().cards.Remove(this);
            GetComponent<AudioSource>().PlayOneShot(draw);

            if (moving != null) {

                StopCoroutine(moving);
            
            }

            moving = StartCoroutine(movingStuff.move(gameObject, new Vector3(5, gameObject.transform.position.y, gameObject.transform.position.z)));

            StartCoroutine(delayDestroy());
            GameObject.Find("table").GetComponent<discard>().numDiscard--;

        }

    }

    IEnumerator delayDestroy() { 
    
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    
    }

}
