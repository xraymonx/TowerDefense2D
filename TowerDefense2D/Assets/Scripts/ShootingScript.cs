using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform ShotSpawner;
    private float fireRate = 0.1f;
    private float nextFire = 0.1f;

    TowerTarget towerTarget;

    void Awake()
    {
        towerTarget = GetComponent<TowerTarget>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (towerTarget.GetTarget())
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bullet, ShotSpawner.position, ShotSpawner.rotation);
            }
        }
    }
}
