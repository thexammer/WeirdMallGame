using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform Player;

    public bool ConstrainY = true;

    private void Update()
    {
        Vector3 lookAt = Player.position;
        if (ConstrainY)
        {
            lookAt = new Vector3(lookAt.x, transform.position.y, lookAt.z);
        }
        transform.LookAt(lookAt);
    }
}
