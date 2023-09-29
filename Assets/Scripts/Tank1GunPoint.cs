using System.Collections;
using UnityEngine;

public class Tank1GunPoint : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int magazineSize;
    [SerializeField] private float reloadTime;

    private bool canFire = true;
    private int bulletsRemaining;
    private float timeSinceLastShot;

    private void Awake()
    {
        gunPoint = GetComponent<Transform>();
        bulletsRemaining = magazineSize;
    }

    private void Update()
    {
        if (canFire && Input.GetKeyDown("q") && bulletsRemaining > 0)
        {
            FireBullet();
            bulletsRemaining--;

            if (bulletsRemaining <= 0)
            {
                canFire = false;
                StartCoroutine(Reload());
            }
            else
            {
                timeSinceLastShot = 0;
            }
        }

        timeSinceLastShot += Time.deltaTime;
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(gunPoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        bulletsRemaining = magazineSize;
        canFire = true;
    }
}
