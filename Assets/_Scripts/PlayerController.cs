using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//Public Instance Variables
	public float speed;
	public Boundary boundary;

	//Private Instance Vairables

	private Vector2 _newPosition = new Vector2(0.0f, 0.0f);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this._CheckInput ();
	}

	private void _CheckInput() {
		this._newPosition = gameObject.GetComponent<Transform> ().position; //current position

		if(Input.GetAxis("Horizontal") > 0) {
			this._newPosition.x += this.speed; //add move value to current position
		}

		if(Input.GetAxis("Horizontal") < 0) {
				this._newPosition.x -= this.speed; //add move value to current position
			}

		//if(Input.GetAxis("Vertical" > 0) {
		//	this._newPosition.y += this.move.y; //add move value to current position
		//}

		//	if(Input.GetAxis("Vertical" < 0) {
		//		this._newPosition.y -= this.move.y; //add move value to current position
		//	}

		this._BoundaryCheck ();

		gameObject.GetComponent<Transform>().position = this._newPosition;
	}

	private void _BoundaryCheck(){
		if (this._newPosition.x < this.boundary.xMin) {
			this._newPosition.x = this.boundary.xMin;
		}

		if (this._newPosition.x > this.boundary.xMax) {
			this._newPosition.x = this.boundary.xMax;
		}
	}
}
