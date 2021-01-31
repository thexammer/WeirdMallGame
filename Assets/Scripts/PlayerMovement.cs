using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller = null;
    [SerializeField] public float speed = 5f;

    [SerializeField] float gravityForce = -9.81f;
    float gravityVel = 0;
    [SerializeField] Transform bottom = null;
    [SerializeField] LayerMask noPlayer = default;

    void Update()
    {
        // Horizontal Movement

        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 move = (transform.right * x) + (transform.forward * z);
        controller.Move(move);

        controller.Move(transform.up * gravityVel * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // Falling physics

        if (Physics.CheckSphere(bottom.position, 0.25f, noPlayer, QueryTriggerInteraction.Ignore))
        {
            gravityVel = 0;
        }
        else
        {
            gravityVel += gravityForce * Time.deltaTime;
        }
    }
}
