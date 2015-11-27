using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _ShotSpawner;
	[SerializeField] private float _fireRate = 0.1f;
	[SerializeField] private float _nextFire = 0.1f;

    TowerTarget towerTarget;
	AnimationController _AnimationController;

    void Awake()
    {
        towerTarget = GetComponent<TowerTarget>();
		_AnimationController = GetComponentInChildren<AnimationController> ();
    }

    void Start()
    {
	

    }

    void Update()
    {
        if (towerTarget.GetTarget ()) {
			if (Time.time > _nextFire) {
				_nextFire = Time.time + _fireRate;
				Instantiate (_bullet, _ShotSpawner.position, _ShotSpawner.rotation);

				_AnimationController.ShootingAnimation();
			} else {
				_AnimationController.NotShootingAnimation();
			}
		}



    }


}
