using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UnitSpawner : MonoBehaviour
{

    public List<string> enemyCards = new List<string>();
    public List<string> playerCards = new List<string>();
    public int healthMod = 0;
    public int enemyHealth = 0;
    public int damageMod = 0;
    public int enemyDamage = 0;

    public List<GameObject> enemySpaces = new List<GameObject>();





    public GameObject blueArcher;
    public GameObject redArcher;
    public GameObject blueKnight;
    public GameObject redKnight;
    public GameObject blueSword;
    public GameObject redSword;
    public GameObject blueWizard;
    public GameObject redWizard;



    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }






    public void spawn()
    {
        
                
        int index = 0;
        Debug.Log("Starting to Parse Enemy Cards");
        foreach(string card in enemyCards)
        {
            switch (card){

                case string n when n.Contains("Archer"):
                    int location = 7 * index;
                    GameObject unit = Instantiate(redArcher, new Vector3(index * 7, 0, 14), new Quaternion(0, 180, 0, 0));
                    index++;
                    break;
                case string n when n.Contains("Knight"):
                    Instantiate(redKnight,new Vector3((7*index),-3,14), new Quaternion(0, 180, 0, 0), transform);
                    index++;

                    break;
                case string n when n.Contains("Sword"):
                    Instantiate(redSword,new Vector3((7*index),-3,14), new Quaternion(0, 180, 0, 0), transform);

                    index++;
                    break;
                case string n when n.Contains("Wizard"):
                    Instantiate(redWizard,new Vector3((7*index),-3,14),new Quaternion(0,180,0,0),transform);
                    index++;

                    break;
                case string n when n.Contains("healthBuff"):
                    enemyHealth += 2;
                    index++;
                    break;
                case string n when n.Contains("healthDebuff"):
                    healthMod -= 2;
                    index++;
                    break;
                case string n when n.Contains("strengthBuff"):
                    enemyDamage += 2;
                    index++;
                    break;
                case string n when n.Contains("strengthDebuff"):
                    damageMod -= 2;
                    index++;
                    break;
                case "Space":
                    index++;
                    break;
                
            }
            
        }
        index = 0;
        foreach (string card in playerCards)
        {
            switch (card)
            {

                case string n when n.Contains("Archer"):
                    int location = 7 * index;
                    GameObject unit = Instantiate(blueArcher, new Vector3(index * 7, 0, -14), new Quaternion(0, 0, 0, 0));
                    index++;
                    break;
                case string n when n.Contains("Knight"):
                    Instantiate(blueKnight, new Vector3((7 * index), -3, -14), new Quaternion(0, 0, 0, 0), transform);
                    index++;

                    break;
                case string n when n.Contains("Sword"):
                    Instantiate(blueSword, new Vector3((7 * index), -3, -14), new Quaternion(0, 0, 0, 0), transform);

                    index++;
                    break;
                case string n when n.Contains("Wizard"):
                    Instantiate(blueWizard, new Vector3((7 * index), -3, -14), new Quaternion(0, 0, 0, 0), transform);
                    index++;

                    break;
                case string n when n.Contains("healthBuff"):
                    healthMod += 2;
                    index++;
                    break;
                case string n when n.Contains("healthDebuff"):
                    enemyHealth -= 2;
                    index++;
                    break;
                case string n when n.Contains("strengthBuff"):
                    damageMod += 2;
                    index++;
                    break;
                case string n when n.Contains("strengthDebuff"):
                    enemyDamage -= 2;
                    index++;
                    break;
                case "Space":
                    index++;
                    break;

            }

        }
    }
}
