using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public GameStateController gameStateController;
    public ParticleSystem bloodParticles;
    private Transform bloodSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        health = 20;
        pointReward = 10;
        meleeDamage = 5;
        bloodSpawnPoint = gameObject.transform.Find("BloodSpawnPoint").transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
            Instantiate(bloodParticles, bloodSpawnPoint.position, bloodSpawnPoint.rotation);
            Destroy(collision.gameObject);
        }   
    }
    
    override public void Die()
    {
        gameStateController.RegisterKill(pointReward);
        Destroy(gameObject);
    }
}
