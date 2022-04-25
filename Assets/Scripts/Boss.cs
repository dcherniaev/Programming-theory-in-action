using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField]
    private float strength = 7f;

    IEnumerator BossForce() // add animation for pulse
    {
        yield return new WaitForSeconds(10);
        PushThePlayerAway();
    }

    void PushThePlayerAway()
    {
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        Vector3 awayFromBoss = (transform.position - player.transform.position);
        playerRigidbody.AddForce(awayFromBoss * strength / awayFromBoss.magnitude, ForceMode.Impulse);

    }
}

