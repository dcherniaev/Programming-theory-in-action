using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private Rigidbody enemyRB;
    protected GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GetRigidbody();
        FindPlayer();
        PrintMessage();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GoToPlayer();
        DestroyWhenFall();
    }

    public virtual void FindPlayer()
    {
        player = GameObject.Find("Player");
    }

    void GetRigidbody()
    {
        enemyRB = GetComponent<Rigidbody>();
    }

    void GoToPlayer()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed);
    }

    void DestroyWhenFall()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public virtual void PrintMessage()
    {
        string enemyName = this.gameObject.name;
        Debug.Log(enemyName + " spawned");
    }

}
