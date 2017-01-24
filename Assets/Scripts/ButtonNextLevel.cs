using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonNextLevel : MonoBehaviour
{
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
		    if(score != null)
		    {
			    score.GetComponent<Score>().Reset();
		    }
			SceneManager.LoadScene(NextLevelName);
	    }
	}
	public void NextLevelButton(int index)
	{
		GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().Reset();
		SceneManager.LoadScene(index);
	}

	public void NextLevelButton(string levelName)
	{
		GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().Reset();
		SceneManager.LoadScene(levelName);
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}