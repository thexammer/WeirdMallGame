using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] LayerMask collectables = default;
    [SerializeField] GameObject prompt = null;
    List<GameObject> collectedThings = new List<GameObject>();

    void FixedUpdate()
    {
        if (Physics.CheckSphere(transform.position, 3f, collectables) && !prompt.activeSelf)
        {
            prompt.SetActive(true);
        }
        else if (!Physics.CheckSphere(transform.position, 3f, collectables) && prompt.activeSelf)
        {
            prompt.SetActive(false);
        }
    }

    void Update()
    {
        if (prompt.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            // Check for actual object being interacted with, and then collect it
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f, collectables);
            collectedThings.Add(hitColliders[0].gameObject);
            hitColliders[0].gameObject.SetActive(false);
        }
    }
}
