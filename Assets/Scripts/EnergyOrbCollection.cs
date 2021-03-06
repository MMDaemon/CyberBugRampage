﻿using UnityEngine;
using System.Collections;

public class EnergyOrbCollection : MonoBehaviour
{
	public float EnergyPerOrb = 50;

	private SpawnerMaster _spawnerMaster;
	void Start ()
	{
		_spawnerMaster = GameObject.FindGameObjectWithTag("SpawnerMaster").GetComponent<SpawnerMaster>();
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag.Equals("Player"))
		{
			if (collider.GetComponent<PlayerAttributes>().AddEnergy(EnergyPerOrb))
			{
				_spawnerMaster.PushEnergyOrb(transform.parent.gameObject);
			}
		}
	}
}
