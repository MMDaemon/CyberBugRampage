using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{

	public GameObject EnemyPrefab;
	public float TimeValue = 5;
	public float TimeScope = 5;
	public float MinDist = 1;
	public float MaxDist = 5;

	private float _currentTime;

	// Use this for initialization
	void Start()
	{

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
			GameObject enemy = GameObject.Instantiate(EnemyPrefab);
			float randX;
			do
			{
				randX = Random.Range(-1.0f, 1.0f);
			} while (randX == 0);
			float randY;
			do
			{
				randY = Random.Range(-1.0f, 1.0f);
			} while (randY == 0);

			Vector3 randomVector = Vector3.Normalize(new Vector3(randX, 0, randY)) * Random.Range(MinDist, MaxDist);

			enemy.transform.position = transform.position + new Vector3(0, 1, 0) + randomVector;
			Debug.Log(randomVector);
			_currentTime = TimeValue + Random.Range(-TimeScope, TimeScope);
		}
	}
}
