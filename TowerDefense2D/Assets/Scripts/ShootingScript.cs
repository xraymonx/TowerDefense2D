using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _ShotSpawner;
    private float _fireRate = 0.1f;
    private float _nextFire = 0.1f;

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
            if (Time.time > _nextFire)
            {
                _nextFire = Time.time + _fireRate;
                Instantiate(_bullet, _ShotSpawner.position, _ShotSpawner.rotation);
            }
        }
    }
}
