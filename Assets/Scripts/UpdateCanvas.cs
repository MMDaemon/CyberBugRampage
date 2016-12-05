using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateCanvas : MonoBehaviour {

	public Text HP;
	public Text Energy;

	private PlayerAttributes _attributes;

	void Start () {
		_attributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		HP.text = "HP: "+(int)_attributes.HP;
		Energy.text = "Energy: " + (int)_attributes.Energy;
	}
}
