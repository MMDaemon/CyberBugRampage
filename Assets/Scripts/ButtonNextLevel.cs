using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonNextLevel : MonoBehaviour
{
	public string NextLevelName;

	void FixedUpdate()
	{
		if (Input.GetButton("Jump"))
		{
			GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().Reset();
			SceneManager.LoadScene(NextLevelName);
		}
		if (Input.GetButton("Cancel"))
		{
			Application.Quit();
		}

	}
	public void NextLevelButton(int index)
	{
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