using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void YouPlay()
	{
		SceneManager.LoadScene(1);
	}

	public void AIPlays()
	{

	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
