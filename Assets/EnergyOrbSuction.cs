using UnityEngine;
using System.Collections;

public class EnergyOrbSuction : MonoBehaviour
{

	public float SuctionStrength = 1;
	public GameObject CollectionRadius;

	Rigidbody _parentRigidbody;
	float _energyPerOrb;

	// Use this for initialization
	void Start()
	{
		_parentRigidbody = GetComponentInParent<Rigidbody>();
		_energyPerOrb = CollectionRadius.GetComponent<EnergyOrbCollection>().EnergyPerOrb;
	}

	// Update is called once per frame
	void OnTriggerStay(Collider collider)
	{
		if (collider.tag.Equals("Player") && collider.GetComponent<PlayerAttributes>().CanCollectOrb(_energyPerOrb))
		{
			float distance = 1 + Vector3.Distance(collider.transform.position + Vector3.up, GetComponentInParent<Transform>().position);
			Vector3 suctionDirection = (collider.transform.position + Vector3.up) - GetComponentInParent<Transform>().position;
			suctionDirection = suctionDirection.normalized;
			Debug.Log(suctionDirection);
			_parentRigidbody.constraints = RigidbodyConstraints.None;
			_parentRigidbody.velocity = suctionDirection * (SuctionStrength/distance);
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.tag.Equals("Player"))
		{
			_parentRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		}
	}
}
