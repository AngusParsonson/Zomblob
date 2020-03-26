﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject.GetComponent<Rigidbody>(), 4f);
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hello");
            //Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
        }
    }
}
