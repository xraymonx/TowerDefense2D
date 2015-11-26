﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	private float _spawnDistanceBetween = 0.2f;
	public List<GameObject> enemiesSpawned = new List<GameObject>();
	
	
	//public void SpawnEnemy(List<GameObject> enemies)
	public void SpawnEnemy(List<GameObject> enemies)
	{
		Vector3 spawnLocation = transform.position;


		for (int i = 0; i < enemies.Count; i++)
		{
			GameObject obj = Instantiate(enemies[i], spawnLocation, Quaternion.identity) as GameObject;
			obj.transform.SetParent(this.transform);
			enemiesSpawned.Add(obj);
			spawnLocation.y += _spawnDistanceBetween;
		}
	}
	
	void Update()
	{
		if (enemiesSpawned != null)
		{
			if (enemiesSpawned.Count == 0)
			{

				GameObject.Find("WaveInfo").GetComponent<WaveSystem>().waveIsActive = false;
			}
		}
	}

}
