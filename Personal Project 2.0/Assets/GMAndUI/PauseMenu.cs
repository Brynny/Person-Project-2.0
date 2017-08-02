using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{	
	private bool IsPaused = false;

	[SerializeField] private GameObject InGameMenu;

	void Awake()
	{
		InGameMenu.SetActive (false);
	}

	void Update ()
	{
		HandlePauseMenu ();
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Debug.Log ("Hit");
		}
	}

	void HandlePauseMenu()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && IsPaused == false)
		{
			Debug.Log ("Key Hit");
			InGameMenu.SetActive (true);
			Time.timeScale = 0;
			IsPaused = true;
		}
		else if (Input.GetKeyDown (KeyCode.Escape) && IsPaused == true)
		{
			InGameMenu.SetActive (false);
			Time.timeScale = 1;
			IsPaused = false;
		}
	}

	public void SaveGame()
	{

	}

	public void LoadGame()
	{

	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
