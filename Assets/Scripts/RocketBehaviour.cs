using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public GameObject explosion;
    private float speed = 1f;
    private float rotationSpeed = 0.01f;
    private Rigidbody rb;
    private GameObject player;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 pos = player.transform.position- transform.position;
        var newRot = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotationSpeed);
        rb.MovePosition(this.transform.forward * speed * Time.deltaTime + transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "RocketSpawner")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
