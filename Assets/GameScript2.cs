using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript2 : MonoBehaviour {

	// variables for various game objects
	GameObject progressBar;
	float initialXScale;
	GameObject proSprite;
	GameObject conSprite;
	GameObject indicator1;
	GameObject indicator2;
	GameObject cashier;

	// other variables
	int numHitsRequiredTotal = 428;
	int numHitsRequiredTurn = 60;
	int numHitsRequiredBreak = 20;
	int numHitsTotal = 0;
	int numHitsTurn = 0;
	int numHitsBreak = 0;
	List <Sprite> proCards = new List<Sprite>();
	List <Sprite> conCards = new List<Sprite>();
	Sprite moneySprite;

	int once1 = 0;
	int once2 = 0;

	// Use this for initialization
	void Start () {

		// set reference to declared game objects
		progressBar = GameObject.Find("ProgressBar/Bar");
		proSprite = GameObject.Find("ProCard");
		conSprite = GameObject.Find("ConCard");
		indicator1 = GameObject.Find("Player1/Player1Light");
		indicator2 = GameObject.Find("Player2/Player2Light");
		cashier = GameObject.Find ("Cashier");

		// already altered the x scale in the editor, so need to get what that is
		initialXScale = progressBar.transform.localScale.x;

		// reset it to zero so there is no bar initially
		progressBar.transform.localScale = new Vector2(0, progressBar.transform.localScale.y);

		// add cards to empty lists on start and money sprite for intermission
		AddCards ();
		moneySprite = Resources.Load ("MONEY", typeof(Sprite)) as Sprite;

		// add a hit every second, starting on start
		InvokeRepeating ("CountDown", 0.0f, 1.0f);
	}

	// Update is called once per frame
	void Update () {

		// if the bar is full
		if (numHitsTotal == numHitsRequiredTotal) {
			// load end scene
			SceneManager.LoadScene ("End");
		}

		if (numHitsTotal < 61 || (numHitsTotal > 142 && numHitsTotal < 204) || (numHitsTotal > 285 && numHitsTotal < 347)) {
			// player 1's turn

			if (once1 == 0) {
				numHitsTurn = 0;
				RandomCard ();
				once1 = 1;
				once2 = 0;
			}
			float pecentDone = numHitsTurn*1.0f/numHitsRequiredTurn;
			progressBar.transform.localScale = new Vector2(pecentDone * initialXScale, progressBar.transform.localScale.y);

			indicator1.GetComponent<SpriteRenderer> ().color = Color.black;
			indicator2.GetComponent<SpriteRenderer> ().color = Color.black;
			progressBar.GetComponent<SpriteRenderer> ().color = Color.white;
		} else if ((numHitsTotal > 60 && numHitsTotal < 122) || (numHitsTotal > 203 && numHitsTotal < 265) || (numHitsTotal > 346 && numHitsTotal < 408)) {
			// player 2's turn

			if (once2 == 0) {
				numHitsTurn = 0;
				RandomCard ();
				once2 = 1;
				once1 = 0;
			}
			float pecentDone = numHitsTurn*1.0f/numHitsRequiredTurn;
			progressBar.transform.localScale = new Vector2(pecentDone * initialXScale, progressBar.transform.localScale.y);

			indicator1.GetComponent<SpriteRenderer> ().color = Color.white;
			indicator2.GetComponent<SpriteRenderer> ().color = Color.white;
			progressBar.GetComponent<SpriteRenderer> ().color = Color.black;
		} else {
			// intermission
			if (numHitsTotal == 122 || numHitsTotal == 265 || numHitsTotal == 408) {
				numHitsBreak = 0;
				proSprite.GetComponent<SpriteRenderer> ().sprite = moneySprite;
				conSprite.GetComponent<SpriteRenderer> ().sprite = moneySprite;
				cashier.GetComponent<AudioSource> ().Play ();
			}
			float pecentDone = numHitsBreak*1.0f/numHitsRequiredBreak;
			progressBar.transform.localScale = new Vector2(pecentDone * initialXScale, progressBar.transform.localScale.y);

			indicator1.GetComponent<SpriteRenderer> ().color = Color.grey;
			indicator2.GetComponent<SpriteRenderer> ().color = Color.grey;
			progressBar.GetComponent<SpriteRenderer> ().color = Color.grey;
		}

	}

	void CountDown() {
		numHitsTotal++;
		numHitsTurn++;
		numHitsBreak++;
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
		proCards.Add(Resources.Load ("PRO15", typeof(Sprite)) as Sprite);
		proCards.Add(Resources.Load ("PRO16", typeof(Sprite)) as Sprite);

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
		conCards.Add(Resources.Load ("CON15", typeof(Sprite)) as Sprite);
		conCards.Add(Resources.Load ("CON16", typeof(Sprite)) as Sprite);

		// named so pro and con cards match up
	}
}
