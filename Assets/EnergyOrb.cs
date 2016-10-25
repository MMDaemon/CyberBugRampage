using UnityEngine;
using System.Collections;

public class EnergyOrb : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag.Equals("Player"))
		{
			if (collider.GetComponent<PlayerAttributes>().AddEnergy(50))
			{
				transform.parent.gameObject.SetActive(false);
			}
		}
	}
}
