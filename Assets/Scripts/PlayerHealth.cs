using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyHealth>().meleeDamage);
            gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.forward * 5, ForceMode.Impulse); 
        }
    }

    override public void Die()
    {
        Debug.Log("Game Over!");
    }
}
