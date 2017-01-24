using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {

	public string NextLevelName;

	void FixedUpdate()
	{
		if (Input.GetButton("Cancel"))
		{
			Application.Quit();
		}
		else if (Input.anyKey)
		{
			GameObject score = GameObject.FindGameObjectWithTag("Score");
			if (score != null)
			{
				score.GetComponent<Score>().Reset();
			}
			SceneManager.LoadScene(NextLevelName);
		}
	}
}
