using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject floor;
    private Plane floorPlane;

    public float movementSpeed = 3f;
    public float jumpStrength = 1f;
    Rigidbody rigidBody;
    private float cameraDif;
    //Vector3 gunOffset;

    // Start is called before the first frame update
    void Start()
    {
        //gunOffset = transform.position - transform.Find("Gun").gameObject.transform.position;
        rigidBody = gameObject.GetComponent<Rigidbody>();
        cameraDif = Camera.main.transform.position.y - transform.position.y;
        floorPlane = new Plane(floor.transform.up, transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FaceMouse();

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 velocity = new Vector3(-movementSpeed, 0, 0);
            rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 velocity = new Vector3(movementSpeed, 0, 0);
            rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 velocity = new Vector3(0, 0, movementSpeed);
            rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 velocity = new Vector3(0, 0, -movementSpeed);
            rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        }

    }

    private void FaceMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(floorPlane.Raycast(ray, out float distance))
        {
            transform.LookAt(ray.GetPoint(distance));
        }

    }
}
