using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}
	
[System.Serializable]
public class Drift {
	public float minDrift, maxDrift;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class CloudController : MonoBehaviour {

	//public instance variables
	public Speed speed;
	public Drift drift;
	public Boundary boundary;

	//Private instance variables
	private Transform _transform;
	private Vector2 _currentPosition;
	private float _CurrentSpeed;
	private float _CurrentDrift;

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
		this._currentPosition += new Vector2(_CurrentDrift, 0);
		this._currentPosition -= new Vector2(0, _CurrentSpeed);

		this._transform.position = this._currentPosition;

		if (this._currentPosition.y <= boundary.yMin) {
			this.Reset ();
		}
	}

	public void Reset() {
		this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
		this._CurrentDrift = Random.Range (drift.minDrift, drift.maxDrift);

		this._transform.position = new Vector2 (Random.Range(boundary.xMin,boundary.xMax), boundary.yMax);
	}
}
