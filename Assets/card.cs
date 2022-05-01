using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{

    private void Start()
    {
        
        DontDestroyOnLoad(this);

    }

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

    public Vector3 origPos;
    Vector3 offset = new Vector3(0, .35f, 0);

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

            selected = true;
            GameObject.Find("hand").GetComponent<player>().selectedCard = this;

            if (GameObject.Find("hand").GetComponent<player>().cameraMove != null)
            {

                StopCoroutine(GameObject.Find("hand").GetComponent<player>().cameraMove);

            }

            if (GameObject.Find("hand").GetComponent<player>().cameraRot != null)
            {

                StopCoroutine(GameObject.Find("hand").GetComponent<player>().cameraRot);

            }

            GameObject.Find("hand").GetComponent<player>().cameraMove = StartCoroutine(movingStuff.move(GameObject.Find("Main Camera"), new Vector3(0, 0.5f, -0.5f)));
            GameObject.Find("hand").GetComponent<player>().cameraRot = StartCoroutine(movingStuff.rotate(GameObject.Find("Main Camera"), Quaternion.Euler(30, 0, 0)));

        }

        else if (isReward && GameObject.Find("table").GetComponent<rewards>().cardsDrawn < GameObject.Find("table").GetComponent<rewards>().maxCards) { 
        
            GameObject.Find("deck").GetComponent<deck>().addCard(this);
            this.isReward = false;
            GameObject.Find("table").GetComponent<rewards>().cardsDrawn++;
        
        }

        

    }

}
