using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
	[SerializeField] private float _health;
	private GameObject _target;
	[SerializeField]private float _targettingRadius;
	private int _layerMask;
	[SerializeField]private int damageTake;
	[SerializeField]private Transform _hpbar; 
	private Vector3 _hpScale;

	// Use this for initialization
	void Start () {
		_layerMask = LayerMask.GetMask ("Bullets");
		_hpScale = _hpbar.transform.localScale;
	}
	// Update is called once per frame
	void Update () {
		Collider2D col = Physics2D.OverlapCircle(this.transform.position, _targettingRadius, _layerMask);

		if (col) 
		{
			Debug.Log("AUW SHIT!");
			Destroy(col.gameObject);
			decreaseHP();
		}
		_hpbar.transform.localScale = _hpScale;

	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(this.transform.position, _targettingRadius);
	}

	void decreaseHP()
	{
		_health = _health - damageTake;
		_hpScale.x = (_health/200);
	
		Debug.Log (_hpScale);
		if (_health <= 0) 
		{
			Debug.Log("ik ben dood, ownee..");
			Destroy(this.gameObject);
		}

	}
}
