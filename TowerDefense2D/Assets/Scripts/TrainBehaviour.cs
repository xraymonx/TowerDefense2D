using UnityEngine;
using System.Collections;

public class TrainBehaviour : MonoBehaviour {

	[SerializeField] private GameObject[] _waypoints;
	[SerializeField] private float _movementSpeed;

	private int _currentWaypoint = 0;
	private float _lastWaypointSwitchTime;
	// Use this for initialization

	void Start () {
	
		_lastWaypointSwitchTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		MoveToWaypoint ();
		RotateIntoMoveDirection();
	}

	void MoveToWaypoint()
	{
		Vector3 startPosition = _waypoints [_currentWaypoint].transform.position;
		Vector3 endPosition = _waypoints [_currentWaypoint + 1].transform.position;


		float pathLength = Vector3.Distance (startPosition, endPosition);
		float totalTimeForPath = pathLength / _movementSpeed;
		float currentTimeOnPath = Time.time - _lastWaypointSwitchTime;
		gameObject.transform.position = Vector3.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);


		if (gameObject.transform.position.Equals(endPosition)) {
			if (_currentWaypoint < _waypoints.Length - 2) {

				_currentWaypoint++;
				_lastWaypointSwitchTime = Time.time;

			} 
			else 
			{

				Destroy(gameObject);
			}
		}
	}


	void RotateIntoMoveDirection()
	{


		Vector3 newStartPosition = _waypoints [_currentWaypoint].transform.position;
		Vector3 newEndPosition = _waypoints [_currentWaypoint + 1].transform.position;
		Vector3 newDirection = (newEndPosition - newStartPosition);

		float x = newDirection.x;
		float z = newDirection.z;
		float rotationAngle = Mathf.Atan2 (x, z) * 180 / Mathf.PI;

		GameObject sprite = (GameObject)gameObject.transform.FindChild("Sprite").gameObject;
		sprite.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.up);


	}
}