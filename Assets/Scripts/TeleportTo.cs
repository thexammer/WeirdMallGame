using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TeleportTo : MonoBehaviour
{
    public Transform TeleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            CharacterController control = other.GetComponent<CharacterController>();
            control.enabled = false;
            Vector3 rot = TeleportPoint.rotation.eulerAngles;
            other.transform.SetPositionAndRotation(TeleportPoint.position, Quaternion.Euler(0, rot.y, 0));
            MouseLook look = other.gameObject.GetComponentInChildren<MouseLook>();
            look.enabled = false;
            look.vertRot = rot.x;
            look.transform.rotation = Quaternion.Euler(rot.x, 0, 0);
            DOTween.Sequence().AppendInterval(0.01f).AppendCallback(() =>
            {
                control.enabled = true;
                look.enabled = true;
            });
        }

    }
}
