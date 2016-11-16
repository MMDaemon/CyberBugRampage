using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{

	public GameObject EnemyPrefab;
	public float TimeValue = 3;
	public float TimeScope = 5;
	public float MinDist = 5;

	private float _currentTime;
	private Transform _player;

	// Use this for initialization
	void Start()
	{
		_player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (_currentTime > 0)
		{
			_currentTime -= Time.deltaTime;
		}
		else
		{
			if (MinDist < Vector3.Distance(_player.transform.position, transform.position))
			{
				GameObject enemy = GameObject.Instantiate(EnemyPrefab);
				enemy.transform.position = transform.position;
			}
			_currentTime = TimeValue + Random.Range(-TimeScope, TimeScope);
		}
	}
}
