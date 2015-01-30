using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public GameObject target;
	public GameObject work;
	public GameObject home;
	public float carSpeed = 2.5f;

	public bool stuck = false;
	public bool stuckBehindCar = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!stuck)
			avoidanceChecks();
//		else
			//reRoute();
	}

	void avoidanceChecks()
	{
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		Debug.DrawRay(transform.position, fwd);
		if(Physics.Raycast(transform.position, fwd, out hit, 3.5f))
		{
			bool driving = false;

			//if the object directly in front of the car is the business then keep driving
			if(hit.collider.name == "Business")
			{
				driveToTarget();
				driving = true;
				if(stuck)
				{
					stuckBehindCar = false;
					stuck = false;
					GameObject.Find("GameMaster").GetComponent<GameMaster>().carsStuck--;
				}
			}
			else if(hit.collider.name == "Car(Clone)")
			{
				driving=true;
				stuckBehindCar = true;
			}

			if(!driving && !stuck)
			{
				stuck = true;
				GameObject.Find("GameMaster").GetComponent<GameMaster>().carsStuck++;
			}
		}
		else
		{
			driveToTarget();
			if(stuck)
			{
				stuckBehindCar = false;
				stuck = false;
				GameObject.Find("GameMaster").GetComponent<GameMaster>().carsStuck--;
			}
		}
	}

    public carDetail getCarDetails()
    {
		carDetail thisCar = new carDetail();
		thisCar.setCarDetailValues(target, home, work, carSpeed);
		return thisCar;
    }

	//TODO: THIS
	void reRoute()
	{
		bool rerouting = true;
		while(rerouting)
		{
			bool obstructLeft = false;
			bool obstructRight = false;

			Vector3 left = transform.TransformDirection(Vector3.left);
			Vector3 right = transform.TransformDirection(Vector3.right);
			RaycastHit hit;
			if(Physics.Raycast(transform.position, left, out hit, 3.5f))
			{
				obstructLeft = true;
			}
			if(Physics.Raycast(transform.position, right, out hit, 3.5f))
			{
				obstructRight = true;
			}

			if(obstructLeft && obstructRight)
			{

			}
		}
	}

	public void setTarget(GameObject trgt)
	{
		this.target = trgt;
	}

	public void setHome(GameObject home)
	{
		this.home = home;
	}

	void driveToTarget()
	{
		if(target!= null)
		{
            Vector3 pos = target.transform.position;

            pos.y = 0;

			transform.LookAt(pos);
			this.transform.Translate(Vector3.forward * Time.deltaTime * carSpeed);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.collider.name == "Car(Clone)")
		{
			GameObject.Find("GameMaster").GetComponent<GameMaster>().carCrashes++;
		}
		else if(col.collider.name == "Business")
		{
			Debug.Log("Ding");
			Destroy(this.gameObject);
			enabled = false;
		}
	}
}