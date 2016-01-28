using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour {
	//Public Instance Variables
	public Text scoreLabel;
	public Text livesLabel;	
	public Text gameOverLabel;
	public Text finalScoreLabel;
	public int scoreValue = 0;
	public int livesValue = 5;

	//Private instance variables
	private AudioSource[] _audioSources; // an array of audiosources
	private AudioSource _islandAudioSource, _cloudAudioSource; 


	// Use this for initialization
	void Start () {
		this._audioSources = this.GetComponents<AudioSource> ();
		this._cloudAudioSource = this._audioSources [1];
		this._islandAudioSource = this._audioSources [2];

		this._SetScore ();
		this.gameOverLabel.enabled = false;
		this.finalScoreLabel.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherGameObject) {
		
		if (otherGameObject.tag == "Island") {
			this._islandAudioSource.Play (); //play the yay sound
			this.scoreValue += 100; //add 100 points
		}
		if (otherGameObject.tag == "Cloud") {
			this._cloudAudioSource.Play (); //play the thunder sound
			this.livesValue--; //remove one life

			if(this.livesValue <= 0) {
				this._EndGame ();
			}

		}
		this._SetScore ();
	}

	//Private method
	private void _SetScore () {
		this.scoreLabel.text = "Score: " + this.scoreValue;
		this.livesLabel.text = "Lives: " + this.livesValue;
	}

	private void _EndGame() {
		Destroy (gameObject);
		this.scoreLabel.enabled = false;
		this.livesLabel.enabled = false;
		this.gameOverLabel.enabled = true;
		this.finalScoreLabel.enabled = true;
		this.finalScoreLabel.text = "Score: " + this.scoreValue;
	}
}
