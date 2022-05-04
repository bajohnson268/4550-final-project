using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleWatcher : MonoBehaviour
{
    public List<GameObject> redTeam = new List<GameObject>();
    public List<GameObject> blueTeam = new List<GameObject>();
    float time = 0;
    public GameObject timer;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Sorting Teams");
        StartCoroutine(assembleTeams());
        GameObject.Find("Spawner").GetComponent<UnitSpawner>().spawn();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(checkWinner());
        time += Time.deltaTime;
        timer.GetComponent<TextMeshProUGUI>().text = "Time: " + Mathf.Round(time);
        if(time >= 30f)
        {
            SceneManager.LoadScene("discard");
        }
    }

    IEnumerator checkWinner()
    {
        bool allRedDead = true;
        foreach (GameObject unit in redTeam)
        {
            if (unit.GetComponent<Minion>().alive)
            {
                allRedDead = false;
                break;
            }
        }
        if (allRedDead && redTeam.Count > 0)
        {
            yield return new WaitForSeconds(5);
            Destroy(GameObject.Find("Spawner"));
            SceneManager.LoadScene("rewards");
        }


        bool allBlueDead = true;
        foreach (GameObject unit in blueTeam)
        {
            if (unit.GetComponent<Minion>().alive)
            {
                allBlueDead = false;
                break;
            }
        }
        if (allBlueDead && blueTeam.Count > 0 || (time >= 7 && blueTeam.Count == 0))
        {
            yield return new WaitForSeconds(5);
            Destroy(GameObject.Find("Spawner"));
            SceneManager.LoadScene("discard");
        }
        
    }

    IEnumerator assembleTeams()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Teams Sorted");
        GameObject[] redTemp = GameObject.FindGameObjectsWithTag("RedTeam");
        GameObject[] blueTemp = GameObject.FindGameObjectsWithTag("BlueTeam");
        foreach(GameObject unit in redTemp)
        {
            redTeam.Add(unit);
            unit.transform.SetParent(gameObject.transform.GetChild(0).transform);
            unit.GetComponent<Minion>().health += GameObject.Find("Spawner").GetComponent<UnitSpawner>().enemyHealth;
            unit.GetComponent<Minion>().attack += GameObject.Find("Spawner").GetComponent<UnitSpawner>().enemyDamage;
        }
        foreach(GameObject unit in blueTemp)
        {
            blueTeam.Add(unit);
            unit.transform.SetParent(gameObject.transform.GetChild(1).transform);
            unit.GetComponent<Minion>().health += GameObject.Find("Spawner").GetComponent<UnitSpawner>().healthMod;
            unit.GetComponent<Minion>().attack += GameObject.Find("Spawner").GetComponent<UnitSpawner>().damageMod;
        }
    }
}
