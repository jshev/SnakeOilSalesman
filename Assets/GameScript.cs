using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {

	// variables for various game objects
	GameObject progressBar;
	float initialXScale;
	GameObject proSprite;
	GameObject conSprite;
	GameObject indicator1;
	GameObject indicator2;

	// other variables
	int numHitsRequired = 240;
	int numHits = 0;
	List <Sprite> proCards = new List<Sprite>();
	List <Sprite> conCards = new List<Sprite>();

	// Use this for initialization
	void Start () {

		// set reference to declared game objects
		progressBar = GameObject.Find("ProgressBar/Bar");
		proSprite = GameObject.Find("ProCard");
		conSprite = GameObject.Find("ConCard");
		indicator1 = GameObject.Find("Player1/Player1Light");
		indicator2 = GameObject.Find("Player2/Player2Light");


		// already altered the x scale in the editor, so need to get what that is
		initialXScale = progressBar.transform.localScale.x;

		// reset it to zero so there is no bar initially
		progressBar.transform.localScale = new Vector2(0, progressBar.transform.localScale.y);

		// add cards to empty lists on start
		AddCards ();

		// add a hit every second, starting on start
		InvokeRepeating ("CountDown", 0.0f, 1.0f);

		// change cards every 30 seconds
		InvokeRepeating ("RandomCard", 0.0f, 30.0f);

	}

	// Update is called once per frame
	void Update () {

		// calculate percentage done (a number between 0 and 1)
		float pecentDone = numHits*1.0f/numHitsRequired;

		// multiply the percentage by the original scale (of what the bar looks like full)
		progressBar.transform.localScale = new Vector2(pecentDone * initialXScale, progressBar.transform.localScale.y);

		// if the bar is full
		if (numHits == numHitsRequired) {
			// load end scene
			SceneManager.LoadScene ("End");
		}

		if (numHits < 61 || (numHits > 120 && numHits < 181)) {
			// player 1's turn
			indicator1.GetComponent<SpriteRenderer> ().color = Color.black;
			indicator2.GetComponent<SpriteRenderer> ().color = Color.black;
			progressBar.GetComponent<SpriteRenderer> ().color = Color.white;
		} else {
			// player 2's turn
			indicator1.GetComponent<SpriteRenderer> ().color = Color.white;
			indicator2.GetComponent<SpriteRenderer> ().color = Color.white;
			progressBar.GetComponent<SpriteRenderer> ().color = Color.black;
		}

	}

	void CountDown() {
		numHits++;

	}

	void ResetHits() {
		numHits = 0;
	}


	void RandomCard() {
		// pick random number in range of list
		int index = Random.Range(0, proCards.Count - 1);
		// render card at that index in list
		proSprite.GetComponent<SpriteRenderer> ().sprite = proCards[index];
		conSprite.GetComponent<SpriteRenderer> ().sprite = conCards[index];
		// remove chosen card so it cannot be repeated
		proCards.RemoveAt(index);
		conCards.RemoveAt(index);
	}

	void AddCards() {
		// add all proCard Sprites to list
		proCards.Add(Resources.Load ("PRO1", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO2", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO3", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO4", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO5", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO6", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO7", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO8", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO9", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO10", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO11", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO12", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO13", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO14", typeof(Sprite)) as Sprite);

		// add all conCard Sprites to list
		conCards.Add(Resources.Load ("CON1", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON2", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON3", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON4", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON5", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON6", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON7", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON8", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON9", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON10", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON11", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON12", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON13", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON14", typeof(Sprite)) as Sprite);

		// named so pro and con cards match up
	}
}
