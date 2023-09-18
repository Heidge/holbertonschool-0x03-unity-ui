using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	/// <summary>
	/// public Material trapMat = new Color32(255, 112, 0, 1);
	/// </summary>
	///public Material goalMat = Color.blue;
	public Toggle colorblindMode;

	public void PlayMaze()
	{
		SceneManager.LoadScene(1);
	}

	public void QuitMaze()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}
}
