using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float strength = 7f;
    public float speed = 7f;
    private Rigidbody enemyRB;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BossForce() // add animation for pulse
    {
        yield return new WaitForSeconds(10);
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        Vector3 awayFromBoss = (transform.position - player.transform.position);
        playerRigidbody.AddForce(awayFromBoss * strength / awayFromBoss.magnitude, ForceMode.Impulse);
    }
}

