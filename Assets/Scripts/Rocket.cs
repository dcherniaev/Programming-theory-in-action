using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 5;
    public float borders = 20;

    private Rigidbody rocketRB;

    // Start is called before the first frame update
    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindGameObjectsWithTag("Enemy");
        rocketRB.AddForce (transform.forward * speed, ForceMode.Impulse);

        if (transform.position.x > borders | transform.position.x < -borders | transform.position.z > borders | transform.position.z < -borders)
        {
            Destroy(gameObject);
        }
    }
}
