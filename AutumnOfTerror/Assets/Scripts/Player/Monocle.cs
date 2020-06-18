using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monocle : MonoBehaviour
{
    bool used = false;
    public float activeTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !used)
        {
            StartCoroutine(MonocleActive(activeTime));
        }
    }

    IEnumerator MonocleActive(float activeTime)
    {
        //get all GameObjects in the scene that are tagged as "Clue"
        GameObject[] clueObjs = GameObject.FindGameObjectsWithTag("Clue");

        foreach (GameObject clueObj in clueObjs)
        {
            clueObj.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        yield return new WaitForSeconds(activeTime);

        foreach (GameObject clueObj in clueObjs)
        {
            clueObj.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        used = true;
    }
}
