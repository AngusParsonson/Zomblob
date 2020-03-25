using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private GameObject gun;
    public GameObject bulletPrefab;
    public GameObject cartridgePrefab;

    public float bulletThrust = 1000f;
    private float cartridgeRecoil = 100f;
    private float gunRecoil = 2f;

    private float damage;
    private int clipsLeft;
    private int clipSize;
    private int bulletsLeft;
    private int bulletsLeftInClip;

    // Start is called before the first frame update
    void Start()
    {
        gun = transform.Find("Gun").gameObject;
        EquipGun(10, 1000, 5, 100, 1);
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletsLeftInClip != 0) FireBullet();
        }
        if (Input.GetKey(KeyCode.R))
        {
            if (bulletsLeft > 0) Reload();
        }
    }

    private void FireBullet()
    {
        Transform bulletSpawnPoint = gun.transform.Find("BulletSpawnPoint").gameObject.transform;
        Transform cartridgeSpawnPoint = gun.transform.Find("CartridgeSpawnPoint").gameObject.transform;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.transform.rotation);
        GameObject cartridge = Instantiate(cartridgePrefab, cartridgeSpawnPoint.position, cartridgeSpawnPoint.rotation);
        bullet.GetComponent<Bullet>().damage = damage;

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        Rigidbody cartridgeRb = cartridge.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * bulletThrust);

        cartridgeRb.AddForce((transform.right) * cartridgeRecoil);

        bulletsLeft--;
        bulletsLeftInClip--;
        Recoil();
    }

    private void Reload()
    {
        int bulletsLoaded = clipSize -bulletsLeftInClip; ;
        if (bulletsLoaded > bulletsLeft) bulletsLoaded = bulletsLeft;
        
        bulletsLeft -= bulletsLoaded;
        bulletsLeftInClip += bulletsLoaded;
    }

    private void EquipGun(int numClips, int numBulletsInClip, float dmg, float cartridgeRec, float gunRec)
    {
        clipsLeft = numClips;
        clipSize = numBulletsInClip;
        damage = dmg;
        bulletsLeft = numClips * numBulletsInClip;
        bulletsLeftInClip = clipSize;
        cartridgeRecoil = cartridgeRec;
        gunRecoil = gunRec;
    }

    private void Recoil()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * gunRecoil, ForceMode.Impulse);
    }
}
