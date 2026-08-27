using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject PausedUI;
	private bool paused = false;



	void Start()
		{

		PausedUI.SetActive(false); 

		}

	void Update()
	{
        if (Input.GetButtonDown("Pause"))
        {

            paused = !paused;
		} 
		if (paused) {

						PausedUI.SetActive(true);
						Time.timeScale = 0;
				}
		if (!paused) {

			PausedUI.SetActive(false);
			Time.timeScale = 1;
				}


	}
	public void Resume()
	{
		paused = false;
	}
	public void save()
	{
		paused = false;
	}

	public void LoadLevel()
	{
        SceneManager.LoadScene(0);

       // Application.LoadLevel(0);
	}

	public void Restart()
	{
        SceneManager.LoadScene(0);

        //Application.LoadLevel(Application.loadedLevel) ;
	}
	public void Quit()
	{
		Application.Quit();
	}

}
