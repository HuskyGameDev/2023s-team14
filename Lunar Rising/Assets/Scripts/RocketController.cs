using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] float thrusterForce = 10f;
    [SerializeField] float tiltingForce = 10f;

    bool thrust = false;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float tilt = Input.GetAxis("Horizontal");
        thrust = Input.GetKey(KeyCode.W);

        if(!Mathf.Approximately(tilt, 0f))
        {
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(0f, 0f, (tilt * tiltingForce * Time.deltaTime))));
        }

        rb.freezeRotation = false;
    }

    private void FixedUpdate()
    {
        if (thrust)
        {
            FindObjectOfType<AudioManager>().Play("rocket_thrust_sound");
            rb.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("rocket_thrust_sound");
        }
    }
}
