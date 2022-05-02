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

        if (Random.Range(0, 2) == 1) {

            difficulty.diff++;
        
        }

        for (int i = 0; i < 8; i++) {

            places.Add(transform.GetChild(i).GetComponent<cardPlace>());
        
        }

        for (int i = 0; i < 4; i++) {

            card temp = Instantiate(units[Random.Range(0, 4)].gameObject).GetComponent<card>();

            unitRewards.Add(temp);

            temp.gameObject.transform.position = places[i].gameObject.transform.position + new Vector3(0, .01f, 0);
            temp.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            temp.isReward = true;

        }

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

        if (cardsDrawn == maxCards) {

            StartCoroutine(delay());
        
        }

    }

    IEnumerator delay() {

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("gameScene");

    }

}
