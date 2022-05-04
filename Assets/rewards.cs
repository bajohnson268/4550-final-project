using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rewards : MonoBehaviour
{

    public List<card> units;
    public List<card> buffs;

    public List<cardPlace> places;

    public List<card> unitRewards;
    public List<card> buffRewards;

    public int cardsDrawn = 0;
    public int maxCards = 3;

    private void Start()
    {

        GameObject.Find("hand").GetComponent<player>().deck.spawnDeck();

        //random chance to increment diff
        if (Random.Range(0, 2) == 1) {

            difficulty.diff++;
        
        }

        //gets cardplaces
        for (int i = 0; i < 8; i++) {

            places.Add(transform.GetChild(i).GetComponent<cardPlace>());
        
        }
        //spawns units cards randomly
        for (int i = 0; i < 4; i++) {

            card temp = Instantiate(units[Random.Range(0, 4)].gameObject).GetComponent<card>();

            unitRewards.Add(temp);

            temp.gameObject.transform.position = places[i].gameObject.transform.position + new Vector3(0, .01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            temp.isReward = true;

        }

        //spawns buff cards randomly
        for (int i = 4; i < 8; i++) {

            card temp = Instantiate(buffs[Random.Range(0, 4)].gameObject).GetComponent<card>();

            buffRewards.Add(temp);

            temp.gameObject.transform.position = places[i].gameObject.transform.position + new Vector3(0, .01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            temp.isReward = true;

        }

    }

    private void Update()
    {
        //if they have added all cards then move scenes
        if (cardsDrawn == maxCards) {

            StartCoroutine(delay());
        
        }

    }

    IEnumerator delay() {

        yield return new WaitForSeconds(2);

        GameObject.Find("hand").GetComponent<player>().resetPlayer();

        SceneManager.LoadScene("gameScene");

    }

}
