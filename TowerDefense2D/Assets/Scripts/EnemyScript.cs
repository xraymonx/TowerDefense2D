using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
	[SerializeField] private int health;
	private GameObject _target;
	[SerializeField]private float _targettingRadius;
	private int _layerMask;
	[SerializeField]private int damageTake;
	// Use this for initialization
	void Start () {
		_layerMask = LayerMask.GetMask("Bullets");
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
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(this.transform.position, _targettingRadius);
	}

	void decreaseHP()
	{
		health = health - damageTake;

		if (health <= 0) 
		{
			Debug.Log("ik ben dood, ownee..");
			Destroy(this.gameObject);
		}

	}
}
