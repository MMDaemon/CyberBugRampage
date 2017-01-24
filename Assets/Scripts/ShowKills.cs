using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowKills : MonoBehaviour
{

    float _kills;
    private Text _textField;
    // Use this for initialization
    void Start()
    {
        _textField = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _kills = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().Killcounter;
        string text = "Kills: " + _kills;
        _textField.text = text;
    }
}
