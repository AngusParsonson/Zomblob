using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject floor;
    public Animator animator;
    private Plane floorPlane;

    public float movementSpeed = 3f;
    public float jumpStrength = 1f;
    Rigidbody rigidBody;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        floorPlane = new Plane(floor.transform.up, floor.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FaceMouse();
        velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            velocity = new Vector3(-movementSpeed, 0, 0);
            rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity = new Vector3(movementSpeed, 0, 0);
            rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            velocity = new Vector3(0, 0, movementSpeed);
            rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            velocity = new Vector3(0, 0, -movementSpeed);
            rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        }

        animator.SetFloat("Speed", velocity.sqrMagnitude);
    }

    private void FaceMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(floorPlane.Raycast(ray, out float distance))
        {
            Vector3 point = ray.GetPoint(distance);
            point.y = transform.position.y;
            transform.LookAt(point);
            animator.SetFloat("Horizontal", point.x);
            animator.SetFloat("Vertical", point.z);
        }

    }
}
