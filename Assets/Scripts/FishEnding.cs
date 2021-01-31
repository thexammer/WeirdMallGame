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
        Debug.Log("debug");

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("here");
            SceneManager.LoadScene("Fish Room");
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Fish Room"))
            StartCoroutine(FishEndingTime());
    }



    IEnumerator FishEndingTime()
    {
        Debug.Log("called");
        if (fish.transform.position != target.position)
        {
            fish.transform.position = Vector3.MoveTowards(fish.transform.position, target.position, step);
            yield return new WaitForSecondsRealtime(.15f);
            StartCoroutine(FishEndingTime());
            yield break;
        }
        else
        {
            Debug.Log("starttext");
            StartCoroutine(Text());
        }
    }

    IEnumerator Text()
    {
        Debug.Log("here");
        text.text += words[count];
        count += 1;

        if (count > words.Length - 1)
        {
            SceneManager.LoadScene("Credits");
            yield return null;
        }
        else
        {
            yield return new WaitForSecondsRealtime(.25f);
            StartCoroutine(Text());
        }
    }
}
