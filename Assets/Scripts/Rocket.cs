using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    private float borders = 20;
    private Rigidbody rocketRB;

    // Start is called before the first frame update
    void Start()
    {
        GetRigidbody();
    }

    // Update is called once per frame
    void Update()
    {
        LaunchRocket();
        DestroyOutOfBounds();
    }

    void GetRigidbody()
    {
        rocketRB = GetComponent<Rigidbody>();
    }

    void LaunchRocket()
    {
        rocketRB.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.x > borders | transform.position.x < -borders | transform.position.z > borders | transform.position.z < -borders)
        {
            Destroy(gameObject);
        }
    }

}
