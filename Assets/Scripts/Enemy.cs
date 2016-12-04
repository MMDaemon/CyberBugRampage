using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public GameObject EnergyOrbPrefab;
	public float Speed = 1;
	[Range(0.0f, 1.0f)]
	[SerializeField]
	float Droprate = 0.7f;

	private Transform player;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag.Equals("MeleeCollider"))
		{
			if (Random.Range(0.0f, 1.0f) <= Droprate)
			{
				GameObject energyOrb = GameObject.Instantiate(EnergyOrbPrefab);
				energyOrb.transform.position = this.transform.position+Vector3.up;
			}
			gameObject.SetActive(false);

		}
	}
}
