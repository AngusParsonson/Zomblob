using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform playerPosition;
    private Rigidbody rb;

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();

        playerPosition = playerObj.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = playerPosition.position - transform.position;
        direction.Normalize();

        transform.LookAt(playerPosition);
        rb.MovePosition(transform.position + (direction * movementSpeed * Time.deltaTime));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cartridge")
        {
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
        }
    }
}
