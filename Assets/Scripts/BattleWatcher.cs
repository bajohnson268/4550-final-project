using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleWatcher : MonoBehaviour
{
    public List<GameObject> redTeam = new List<GameObject>();
    public List<GameObject> blueTeam = new List<GameObject>();
    
    
    
    
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
        bool allRedDead = true;
        foreach(GameObject unit in redTeam)
        {
            if (unit.GetComponent<Minion>().alive)
            {
                allRedDead = false;
                break;
            }
        }
        if (allRedDead && redTeam.Count >0)
        {
            Destroy(GameObject.Find("Spawner"));
            SceneManager.LoadScene("rewards");
        }


        bool allBlueDead = true;
        foreach(GameObject unit in blueTeam)
        {
            if (unit.GetComponent<Minion>().alive)
            {
                allBlueDead = false;
                break;
            }
        }
        if (allBlueDead && blueTeam.Count >0)
        {

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
