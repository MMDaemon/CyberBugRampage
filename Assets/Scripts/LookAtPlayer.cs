using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class LookAtPlayer : MonoBehaviour
{

	public float Distance = 2.0f;
	public float HeightPercentage = 0.8f;
	public float SpeedV = 2.0f;
	public float SpeedH = 2.0f;

	private Transform _player;
	private CapsuleCollider _playerCollider;


	// Use this for initialization
	void Start()
	{
		GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
		_player = playerObject.transform;
		_playerCollider = playerObject.GetComponent<CapsuleCollider>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Vector3 playerShoulder = _player.position + _playerCollider.transform.up * _playerCollider.height * HeightPercentage;
		float xRotbefore = transform.eulerAngles.x;
		//follow player
		transform.LookAt(playerShoulder);
		transform.eulerAngles = new Vector3(xRotbefore, transform.eulerAngles.y, transform.eulerAngles.z);
		float flatDistance = Vector3.Dot(transform.forward * Distance, Vector3.Normalize(Vector3.Scale(transform.forward, new Vector3(1, 0, 1))));
		float currentDistance = Vector3.Distance(Vector3.Scale(transform.position, new Vector3(1, 0, 1)), Vector3.Scale(playerShoulder, new Vector3(1, 0, 1)));
		transform.position += Vector3.Scale(transform.forward, new Vector3(1, 0, 1)) * (currentDistance - flatDistance);

		//manual rotation
		//Vector3 rotationX = new Vector3(SpeedV * Input.GetAxis("Mouse Y"), 0.0f, 0.0f);
		//if ((transform.eulerAngles - rotationX).x < 60.0f || (transform.eulerAngles - rotationX).x > 300.0f)
		//{
		//	transform.eulerAngles -= rotationX;
		//}
		Vector3 rotationY = new Vector3(0.0f, SpeedH * Input.GetAxis("Mouse X"), 0.0f);
		transform.eulerAngles += rotationY;

		this.transform.position = playerShoulder - transform.forward * Distance;
	}
}
