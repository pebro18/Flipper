using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public AudioSource buttonClick;

    public void LaadLevel(string levelnaam)
    {
        buttonClick.Play();
        SceneManager.LoadSceneAsync(levelnaam);
    }
		
    public void LaadVolgendLevel()
    {
        buttonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
		
    public void HerlaadLevel()
    {
        buttonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StopSpel()
    {
        buttonClick.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
    }

}
