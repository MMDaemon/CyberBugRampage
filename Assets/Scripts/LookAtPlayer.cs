using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class LookAtPlayer : MonoBehaviour
{

	[SerializeField]
	float distance = 2.0f;
	[SerializeField]
	float heightPercentage = 0.8f;
	[SerializeField]
	float speedH = 2.0f;
	[SerializeField]
	float cameraHeight = 0.2f;

	private Transform _player;
	private Transform _cameraPos;
	private CapsuleCollider _playerCollider;
	

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
		Vector3 playerShoulder = _player.position + _playerCollider.transform.up * _playerCollider.height * heightPercentage;

		_cameraPos.LookAt(playerShoulder);

		transform.eulerAngles = new Vector3(20, _cameraPos.transform.rotation.eulerAngles.y, 0);
		float currentDistance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(playerShoulder.x, playerShoulder.z));
		if (currentDistance != distance)
		{
			transform.position = transform.position + new Vector3(transform.forward.x, 0, transform.forward.z) * (currentDistance - distance);
		}

		this.transform.eulerAngles += new Vector3(0.0f, speedH * Input.GetAxis("Mouse X"), 0.0f);

		this.transform.position = playerShoulder - new Vector3(transform.forward.x, -cameraHeight, transform.forward.z) * distance;
	}
}
