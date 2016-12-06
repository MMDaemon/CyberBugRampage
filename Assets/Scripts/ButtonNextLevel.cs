using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonNextLevel : MonoBehaviour
{
	public void NextLevelButton(int index)
	{
		SceneManager.LoadScene(index);
	}

	public void NextLevelButton(string levelName)
	{
		GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().Reset();
		SceneManager.LoadScene(levelName);
	}
}
