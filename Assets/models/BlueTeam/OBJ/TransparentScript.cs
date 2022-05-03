using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Transparentify());
    }

   



    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Transparentify()
    {
        yield return new WaitForSeconds(2);
        for(int i = 0; i < gameObject.GetComponent<SkinnedMeshRenderer>().materials.Length; i++)
        {
            //Debug.Log(gameObject.GetComponent<SkinnedMeshRenderer>().materials[i].name);
            Material mat = gameObject.GetComponent<SkinnedMeshRenderer>().materials[i];
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, .6f);
            mat.SetFloat("_Mode", 3);
            
        }
    }
}
