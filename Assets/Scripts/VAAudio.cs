using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VAAudio : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> clips;
    public float min, max;
    private int lastClip;

    private void Start()
    {
        StartCoroutine(PLayAudio());
    }

    IEnumerator PLayAudio()
    {
        int random = Random.Range(0, clips.Count - 1);
        float wait = Random.Range(min, max);
       
        if (lastClip == random)
        {
            StartCoroutine(PLayAudio());
            yield break;
        }

        lastClip = random;
        source.clip = clips[random];
        source.Play();

        yield return new WaitForSecondsRealtime(wait);
        StartCoroutine(PLayAudio());
    }
}
