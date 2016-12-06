using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{

	public GameObject EnemyPrefab;
	public float TimeValue = 3;
	public float TimeScope = 2.5f;
	public float MinDist = 5;

	private float _currentTime;
	private Transform _player;
	private SpawnerMaster _spawnerMaster;

	// Use this for initialization
	void Start()
	{
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		_spawnerMaster = GameObject.FindGameObjectWithTag("SpawnerMaster").GetComponent<SpawnerMaster>();
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
				GameObject enemy = _spawnerMaster.PullEnemy();
				NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
				agent.enabled = false;
				enemy.transform.position = transform.position;
				agent.enabled = true;
			}
			_currentTime = TimeValue + Random.Range(-TimeScope, TimeScope);
		}
	}
}
