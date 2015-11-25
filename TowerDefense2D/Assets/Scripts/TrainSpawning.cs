using UnityEngine;
using System.Collections;

public class TrainSpawning : MonoBehaviour {
	[SerializeField] GameObject _train;
	public float counter = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		counter += (1 * Time.deltaTime); 
		if (counter >= 3f) 
		{
			Instantiate(_train, this.transform.position, this.transform.rotation);
			counter = 0;

		}
	}
}
