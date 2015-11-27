using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable] public class WaveInfo
{
	public List<GameObject> waveInfo;
}


public class WaveSystem : MonoBehaviour {
	[SerializeField] Text _textField; 

	public List<GameObject> waveInfo;

	private int _waveCounter = 0;
	
	public bool waveIsActive = false;
	
	public List<WaveInfo> waves = new List<WaveInfo>();
	
	public void SpawnEnemies()
	{
		if (waveIsActive == false)
		{
			Debug.Log ("#1 Wavesystem"); 
			waveIsActive = true;
			GameObject.Find("WaveSpawner").GetComponent<EnemySpawner>().SpawnEnemy(waves[_waveCounter].waveInfo);
			_waveCounter++;
			_textField.text = ""+ _waveCounter;
		}
	}

}
