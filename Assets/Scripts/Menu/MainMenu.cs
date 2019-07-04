using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public GameObject areYouSurePanel;

    public AudioSource buttonClick;

	public void NewScene(string LevelName)
	{
        buttonClick.Play();
		SceneManager.LoadScene (LevelName);
	}

	public void Quit()
	{
        buttonClick.Play();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
	
	public void NoQuitGame()
	{
        buttonClick.Play();
		areYouSurePanel.SetActive (false);
	}

	public void AreYouSure()
	{
        buttonClick.Play();
		areYouSurePanel.SetActive (true);
	}

}
