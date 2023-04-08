using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] float thrusterForce = 10f;
    [SerializeField] float tiltingForce = 10f;

    bool isGrounded = false;
    public Transform GroundCheck;
    public LayerMask groundLayer;

    bool thrust = false;
    [SerializeField] float boostAmount = 100f;
    [SerializeField] float rechargeInterval = 1f;
    float time = 0f;
    float delayAmount = 2f;

    Rigidbody2D rb;

    [SerializeField] ParticleSystem thrustParticles;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.15f, groundLayer);
        Debug.Log(isGrounded);

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
        if (thrust && boostAmount > 0f)
        {
            thrustParticles.Play();
            FindObjectOfType<AudioManager>().Play("rocket_thrust_sound");
            rb.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
            boostAmount = boostAmount - rechargeInterval;
        }
        else if (!thrust)
        {
            FindObjectOfType<AudioManager>().Stop("rocket_thrust_sound");
            thrustParticles.Stop();

            if (boostAmount < 100f && isGrounded)
            {
                time += Time.time;
                if (time > delayAmount)
                {
                    boostAmount = boostAmount + rechargeInterval;
                    time = 0f;
                }
            }
        }
    }

    IEnumerator rechargeDelay()
    {
        yield return new WaitForSeconds(delayAmount);
    }
}
