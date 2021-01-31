using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CatRoom : MonoBehaviour
{
    public MeshCollider FloorCollider;

    public float CountDownTime;

    private Sequence CountDown;

    private AudioSource sin;

    private void Start()
    {
        sin = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CountDown = DOTween.Sequence();
        CountDown.AppendInterval(CountDownTime);
        CountDown.AppendCallback(() => TooMuchSin());
    }

    private void OnTriggerExit(Collider other)
    {
        CountDown.Kill(false);
    }

    private void TooMuchSin()
    {
        GetComponent<BoxCollider>().enabled = false;
        FloorCollider.enabled = false;
        sin.Play();
    }
}
