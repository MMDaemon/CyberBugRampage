using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public GameObject EnergyOrbPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
