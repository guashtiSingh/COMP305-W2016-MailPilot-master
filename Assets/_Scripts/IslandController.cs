using UnityEngine;
using System.Collections;

public class IslandController : MonoBehaviour {
	//public instance variables
	public float speed = 5f;

	//Private instance variables
	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
		//make a reference with the Transform component
		this._transform = gameObject.GetComponent<Transform> ();

		//reset the gameobject sprite to the top
		this.Reset();
	}

	// Update is called once per frame
	void Update () {
		this._currentPosition = this._transform.position;
		this._currentPosition -= new Vector2(0, this.speed);
		this._transform.position = this._currentPosition;

		if (this._currentPosition.y <= -270) {
			this.Reset ();
		}
	}

	public void Reset() {
		this._transform.position = new Vector2 (Random.Range(-290f,290f), 270f);
	}
}
