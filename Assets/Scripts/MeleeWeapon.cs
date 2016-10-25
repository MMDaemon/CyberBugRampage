using UnityEngine;
using System.Collections;

public class MeleeWeapon : MonoBehaviour
{

	public GameObject Wielder;
	public float AttackSpeed = 1.0f;
	public float LoadSpeed = 0.5f;
	public float MinRot = 0.0f;
	public float MaxRot = 180.0f;
	public float Height = 1.0f;
	public float Distance = 0.5f;


	private bool _attackState = false;
	private bool _attackReady = true;
	private float _meleeMovement = 0;

	private BoxCollider _collider;

	// Use this for initialization
	void Start()
	{
		_collider = transform.GetChild(0).GetComponent<BoxCollider>();
		_collider.enabled = false;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (_attackReady && Input.GetButtonDown("Fire1"))
		{
			StartAttack();
		}

		if (_attackState)
		{
			_meleeMovement += AttackSpeed * Time.deltaTime;
			if (_meleeMovement >= MaxRot / 180 * Mathf.PI)
			{
				_meleeMovement = MaxRot / 180 * Mathf.PI;
				FinishAttack();
			}
		}
		else
		{
			_meleeMovement -= LoadSpeed * Time.deltaTime;
			if (_meleeMovement < MinRot / 180 * Mathf.PI)
			{
				_meleeMovement = MinRot / 180 * Mathf.PI;
				SetAttackReady();
			}
		}

		transform.localPosition = Distance * new Vector3(Mathf.Cos(_meleeMovement), Height / Distance + Mathf.Cos(_meleeMovement), Mathf.Sin(_meleeMovement));

		transform.LookAt(Wielder.transform.position + new Vector3(0, 1, 0));
	}

	private void StartAttack()
	{
		_attackState = true;
		_collider.enabled = true;
	}

	private void FinishAttack()
	{
		_attackState = false;
		_collider.enabled = false;
		_attackReady = false;
	}

	private void SetAttackReady()
	{
		_attackReady = true;
	}
}
