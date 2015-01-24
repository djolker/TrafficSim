using UnityEngine;
using System.Collections;

public class Business : MonoBehaviour {
	public GameObject text;

	public int working;

	// Use this for initialization
	void Start () {
		working = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.GetComponent<TextMesh>().text = "Working Currently: " + working;
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.collider.name == "Car(Clone)")
		{
			Debug.Log("Triggered");
			working++;
		}
	}
}
