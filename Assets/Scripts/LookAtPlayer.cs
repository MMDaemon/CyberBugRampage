using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class LookAtPlayer : MonoBehaviour
{

	[SerializeField] float distance =2.0f;
	[SerializeField] float height = 0.8f;
	[SerializeField] float speedH = 2.0f;
	[SerializeField] float speedV = 2.0f;

	private Transform _player;
	CapsuleCollider _playerCollider;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	// Use this for initialization
	void Start ()
	{
		GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
		_player = playerObject.transform;
		_playerCollider = playerObject.GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		this.transform.position = _player.position - this.transform.forward*distance + _playerCollider.transform.up*_playerCollider.height*height;
	}
}
