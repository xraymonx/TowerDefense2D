using UnityEngine;
using System.Collections;

public class NavFollower : MonoBehaviour {

	public Transform targetPos;
	private NavMeshAgent _navComponent;


	// Use this for initialization
	void Start () {

		_navComponent = this.transform.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(targetPos)
		{
			_navComponent.SetDestination(targetPos.position);


		}

	
	}
}
