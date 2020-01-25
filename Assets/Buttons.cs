using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

	public Button menuButton;
	public Button playButton;
	public Button instructButton;

	// Use this for initialization
	void Start () {

		if (menuButton != null) {
			// load menu when menu button is clicked
			menuButton.onClick.AddListener (LoadMenu);
		}
		if (playButton != null) {
			// load game when play button is clicked
			playButton.onClick.AddListener (LoadGame);
		}
		if (instructButton != null) {
			// load instructions when instructions button is clicked
			instructButton.onClick.AddListener (LoadInstructions);
		}
	}

	void LoadGame() {
		// load game scene
		SceneManager.LoadScene ("Scene");
	}

	void LoadInstructions() {
		// load instructions scene
		SceneManager.LoadScene ("Instruct");
	}

	void LoadMenu() {
		// load menu scene
		SceneManager.LoadScene ("Menu");
	}
}
