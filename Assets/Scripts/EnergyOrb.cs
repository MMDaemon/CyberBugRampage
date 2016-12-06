using UnityEngine;
using System.Collections;

public class EnergyOrb : MonoBehaviour
{
	private SpawnerMaster _spawnerMaster;
	void Start ()
	{
		_spawnerMaster = GameObject.FindGameObjectWithTag("SpawnerMaster").GetComponent<SpawnerMaster>();
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag.Equals("Player"))
		{
			if (collider.GetComponent<PlayerAttributes>().AddEnergy(50))
			{
				_spawnerMaster.PushEnergyOrb(transform.parent.gameObject);
			}
		}
	}
}
