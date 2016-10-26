using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public GameObject EnergyOrbPrefab;
	public float Speed = 1;

	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag.Equals("MeleeCollider"))
		{
			GameObject energyOrb = GameObject.Instantiate(EnergyOrbPrefab);
			energyOrb.transform.position = this.transform.position;
			gameObject.SetActive(false);
		}
	}
}
