using UnityEngine;
using System.Collections;

public class Caster : MonoBehaviour {

	public GameObject car;

	// Use this for initialization
	void Start () {
		car = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		Debug.DrawRay(transform.position, fwd);

		if(Physics.Raycast(this.transform.position, fwd, out hit, 2f))
		{
			if(hit.collider.name == "Car(Clone)")
			{
				car.GetComponent<Car>().stuckBehindCar = true;
			}
		}
		else
		{
			car.GetComponent<Car>().stuckBehindCar = false;
			car.GetComponent<Car>().stuck = false;
		}
	}
}
