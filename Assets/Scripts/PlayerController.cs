using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool hasPowerUp;
    public bool hasPowerUpRockets;
    public GameObject powerupIndicatorForce;
    public GameObject powerupIndicatorJump;
    public GameObject rocket;

    private Rigidbody playerRB;
    private GameObject focalPoint;
    private float powerupStrength = 15;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerupIndicatorForce.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        powerupIndicatorJump.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicatorForce.SetActive(true);
        }
        if (other.CompareTag("Powerup Rocket"))
        {
            Destroy(other.gameObject);
            hasPowerUpRockets = true;
            StartCoroutine(LaunchRockets());
        }

        if (other.CompareTag("Powerup Jump"))
        {
            Destroy(other.gameObject);
            powerupIndicatorJump.SetActive(true);
            StartCoroutine(PowerupJump());
        }


    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        hasPowerUp = false;
        hasPowerUpRockets = false;
        powerupIndicatorForce.SetActive(false);
    }

    IEnumerator LaunchRockets()
    {
        for (int i = 0; i < 15; i++)
        {
            Instantiate(rocket, transform.position + new Vector3(0, 0.1f, 1f), Quaternion.Euler(0, 0, 0));
            Instantiate(rocket, transform.position + new Vector3(1f, 0.1f, 1f), Quaternion.Euler(0, 45, 0));
            Instantiate(rocket, transform.position + new Vector3(1f, 0.1f, 0), Quaternion.Euler(0, 90, 0));
            Instantiate(rocket, transform.position + new Vector3(1f, 0.1f, -1f), Quaternion.Euler(0, 135, 0));
            Instantiate(rocket, transform.position + new Vector3(0, 0.1f, -1f), Quaternion.Euler(0, 180, 0));
            Instantiate(rocket, transform.position + new Vector3(-1f, 0.1f, -1f), Quaternion.Euler(0, 225, 0));
            Instantiate(rocket, transform.position + new Vector3(-1f, 0.1f, 0), Quaternion.Euler(0, 270, 0));
            Instantiate(rocket, transform.position + new Vector3(-1f, 0.1f, 1f), Quaternion.Euler(0, 315, 0));
            yield return new WaitForSeconds(1);

        }

        hasPowerUpRockets = false;
    }

    IEnumerator PowerupJump() // add animation for pulse
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = (enemy.transform.position - transform.position);
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength / awayFromPlayer.magnitude, ForceMode.Impulse);
            }
            yield return new WaitForSeconds(1);
        }
        powerupIndicatorJump.SetActive(false);
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
