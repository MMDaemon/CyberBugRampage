using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class LookAtPlayer : MonoBehaviour
{

	[SerializeField]
	float distance = 2.0f;
	[SerializeField]
	float height = 0.8f;
	[SerializeField]
	float speedH = 2.0f;
	[SerializeField]
	float speedV = 2.0f;

	private Transform _player;
	private Transform _cameraPos;
	CapsuleCollider _playerCollider;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	// Use this for initialization
	void Start()
	{
		GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
		_cameraPos = this.transform.GetChild(0);
		_player = playerObject.transform;
		_playerCollider = playerObject.GetComponent<CapsuleCollider>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Vector3 playerShoulder = _player.position + _playerCollider.transform.up * _playerCollider.height * height;

		_cameraPos.LookAt(playerShoulder);

		transform.eulerAngles = new Vector3(20, _cameraPos.transform.rotation.eulerAngles.y, 0);
		float currentDistance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(playerShoulder.x, playerShoulder.z));
		if (currentDistance != distance)
		{
			transform.position = transform.position + new Vector3( transform.forward.x , 0, transform.forward.z)*(currentDistance - distance);
		}

		//yaw += speedH * Input.GetAxis("Mouse X");
		//this.transform.eulerAngles = new Vector3(20.0f, yaw, 0.0f);

		//this.transform.position = playerShoulder - this.transform.forward*distance;
	}
}
