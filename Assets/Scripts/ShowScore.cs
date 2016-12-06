using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

	int _score;
	private Text _textField;
	// Use this for initialization
	void Start () {
		_textField = gameObject.GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().ScorePoints;
		string text = "Score: " + _score;
		_textField.text = text;
	}
}
