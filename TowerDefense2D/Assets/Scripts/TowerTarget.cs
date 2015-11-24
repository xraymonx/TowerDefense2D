using UnityEngine;
using System.Collections;

public class TowerTarget : MonoBehaviour
{


    private GameObject _target;
    [SerializeField]private float _targettingRadius;
    private int _layerMask;
	private Quaternion rotation;
	private int _turnSpeed = 10;
    void Start()
    {
        _layerMask = LayerMask.GetMask("Enemy");
    }

    void Update()
    {

        Collider2D col = Physics2D.OverlapCircle(this.transform.position, _targettingRadius, _layerMask);

		if (col)
        {

            _target = col.gameObject;
			Rotating();
        }
        else
        {
            _target = null;
        }
    }

    public GameObject GetTarget()
    {
        return _target;
    }

    void OnDrawGizmos()
    {
		Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, _targettingRadius);
    }

	void Rotating()
	{
		Vector3 direction = _target.transform.position - this.transform.position;
		float angle = Mathf.Atan2 (direction.x, direction.z) * Mathf.Rad2Deg;
		rotation = Quaternion.Lerp (this.transform.rotation, Quaternion.Euler (0, angle, 0), Time.time * _turnSpeed);
		this.transform.rotation = rotation;

	}


}
