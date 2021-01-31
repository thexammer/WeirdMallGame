using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FishEnding : MonoBehaviour
{
    bool inFishRoom = false;
    public GameObject fish;
    public Transform target;
    public float step;

    public TextMeshProUGUI text;
    private int count = 0;

    private string words = "You've been here awile, better wake up before you forget how :)";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !inFishRoom)
        {
            inFishRoom = true;
            StartCoroutine(FishEndingTime());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !inFishRoom)
        {
            inFishRoom = true;
            StartCoroutine(FishEndingTime());
        }
    }



    IEnumerator FishEndingTime()
    {
        while(fish.transform.position != target.position)
        {
            fish.transform.position = Vector3.MoveTowards(fish.transform.position, target.position, step);
        }

        StartCoroutine(Text());

        
        yield return null;
    }

    IEnumerator Text()
    {

        text.text += words[count];
        count += 1;

        if (count > words.Length)
        {
            SceneManager.LoadScene("Credits");
            yield return null; }
        else
        {
            yield return new WaitForSecondsRealtime(.25f);
            StartCoroutine(Text());
        }
    }
}
