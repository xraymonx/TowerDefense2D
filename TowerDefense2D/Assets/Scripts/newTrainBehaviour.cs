using UnityEngine;
using System.Collections;

public class newTrainBehaviour : MonoBehaviour {

	[SerializeField] private float maxSpeed = 10;
	[SerializeField] private float mass = 5;
	[SerializeField] private GameObject[] _wayPoints;

	private int _WaypointCounter = 0;

	private Rigidbody _rigidbody3D;

	private Vector3 _target;
	private GameObject resourceGameObject;
	ResourceScript resourceScript;

	// Use this for initialization
	void Start () {
		resourceGameObject = GameObject.FindWithTag ("Resource");
		resourceScript = resourceGameObject.GetComponent<ResourceScript>();


		_rigidbody3D = GetComponent<Rigidbody> ();
	}
	void FixedUpdate()
	{


	}
	
	// Update is called once per frame
	void Update ()
	{
		Seek ();
		
	}
	void Seek()
	{
		_target = _wayPoints [_WaypointCounter].transform.position;

		Vector3 desiredStep = _target - _rigidbody3D.position;

		float distanceToWaypoint = desiredStep.magnitude;

		desiredStep.Normalize ();

		Vector3 desiredVelocity = desiredStep * maxSpeed;
		Vector3 steeringForce = desiredVelocity - _rigidbody3D.velocity;

		_rigidbody3D.velocity = _rigidbody3D.velocity + steeringForce / mass;

		float angle = Mathf.Atan2 (_rigidbody3D.velocity.x, _rigidbody3D.velocity.z) * Mathf.Rad2Deg;

		_rigidbody3D.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (-90, 180,angle), Time.deltaTime * 60f);


		if(distanceToWaypoint < 0.1)
		{
			if(_WaypointCounter+1 != _wayPoints.Length)
			{
			_WaypointCounter++;
			}
			else
			{
				Destroy(this.gameObject);

			}
			if (_WaypointCounter == 2) 
			{
				resourceScript.AddingResources();
				Debug.Log("ik ben der");
			}
		}

	}
}
