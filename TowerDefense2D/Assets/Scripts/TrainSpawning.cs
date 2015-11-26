using UnityEngine;
using System.Collections;

public class TrainSpawning : MonoBehaviour {
	[SerializeField] GameObject _train;
	public float counter = 0;

	private GameObject _waveSystemObject;
	WaveSystem waveSystem;
	// Use this for initialization
	void Start () {
		_waveSystemObject = GameObject.FindWithTag("WaveSystem"); 
		waveSystem = _waveSystemObject.GetComponent<WaveSystem>(); 
	}
	
	// Update is called once per frame
	void Update () {
		counter += (1 * Time.deltaTime); 
		if (counter >= 3f && waveSystem.waveIsActive == true) 
		{
			Instantiate(_train, this.transform.position, this.transform.rotation);
			counter = 0;

		}
	}
}
