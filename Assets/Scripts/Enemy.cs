using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public GameObject EnergyOrbPrefab;
	public float Speed = 1;
	[Range(0.0f, 1.0f)]
	[SerializeField]
	float Droprate = 0.7f;

	private SpawnerMaster _spawnerMaster;

	// Use this for initialization
	void Start()
	{
		_spawnerMaster = GameObject.FindGameObjectWithTag("SpawnerMaster").GetComponent<SpawnerMaster>();
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag.Equals("MeleeCollider"))
		{
			if (Random.Range(0.0f, 1.0f) <= Droprate)
			{
				GameObject energyOrb = _spawnerMaster.PullEnergyOrb();
				energyOrb.transform.position = this.transform.position+Vector3.up;
			}
			_spawnerMaster.PushEnemy(gameObject);
		}
	}
}
