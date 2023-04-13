using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketController : MonoBehaviour
{
    [SerializeField] float thrusterForce = 10f;
    [SerializeField] float tiltingForce = 10f;

    bool isGrounded = false;
    public Transform GroundCheck;
    public LayerMask groundLayer;

    bool thrust = false;
    [SerializeField] float boostAmount = 100f;
    float maxBoost;
    [SerializeField] float rechargeInterval = 1f;
    float time = 0f;
    float delayAmount = 2f;

    Rigidbody2D rb;

    [SerializeField] ParticleSystem thrustParticles;

    public FuelTank fuelTank;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        maxBoost = boostAmount;
        fuelTank.SetMaxFuel((int)boostAmount);
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

        if (transform.position.y > 215f)
        {
            rb.gravityScale = 0.167f;
        } 
        else if (transform.position.y > 175f)
        {
            if ((215f - transform.position.y) >= 8f)
            {
                rb.gravityScale = (215f - transform.position.y) * 0.020825f;
            } else
            {
                rb.gravityScale = 0.167f;
            }
        } else
        {
            rb.gravityScale = 1f;
        }
    }

    private void FixedUpdate()
    {
        if (thrust && boostAmount > 2f)
        {
            thrustParticles.Play();
            FindObjectOfType<AudioManager>().Play("rocket_thrust_sound");
            rb.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
            boostAmount = boostAmount - rechargeInterval;
            fuelTank.SetFuel((int)boostAmount);
        }
        else if(thrust && (boostAmount <= 2f && boostAmount > 0f))
        {
            thrustParticles.Stop();
            FindObjectOfType<AudioManager>().Stop("rocket_thrust_sound");
            rb.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
            boostAmount = boostAmount - rechargeInterval;
            fuelTank.SetFuel((int)boostAmount);
        }
        else if (!thrust || boostAmount <= 0f)
        {
            FindObjectOfType<AudioManager>().Stop("rocket_thrust_sound");
            thrustParticles.Stop();

            if (boostAmount < maxBoost && isGrounded)
            {
                time += Time.time;
                if (time > delayAmount)
                {
                    boostAmount = boostAmount + rechargeInterval;
                    fuelTank.SetFuel((int)boostAmount);
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
