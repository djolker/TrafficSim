using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Business : MonoBehaviour {
	public GameObject text;
	public GameObject GM;

	public GameObject car;
	public int working;

	public List<carDetail> carsAtWork = new List<carDetail>();

	// Use this for initialization
	void Start () {
		working = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.GetComponent<TextMesh>().text = "Working Currently: " + working;
		if(GM.GetComponent<GameMaster>().time.Split(':')[0] == "15")
		{
			letOutRandomCar();
		}
	}

	void OnCollisionEnter(Collision col)
	{

		if(col.collider.name == "Car(Clone)")
		{
			working++;
			carDetail newCar = col.collider.GetComponent<Car>().getCarDetails();
			carsAtWork.Add(newCar);
			Debug.Log("Car successfully added to list: " + newCar.home.name + " - " + newCar.carspeed);
		}
		else{
			Debug.Log(col.collider.name);
		}
	}

	void letOutRandomCar()
	{
		Vector3 pos = new Vector3();
		pos.x = this.transform.position.x;
		pos.z = this.transform.position.z;
		pos.y = 1.03313446f;
		
		car.transform.position = pos;
		car.transform.Translate(Vector3.forward * 5f);

		int picked = pickRandomCar();

		car.GetComponent<Car>().setHome(this.gameObject);
		car.GetComponent<Car>().setTarget(carsAtWork[picked].home);
		Instantiate(car, car.transform.position, car.transform.rotation);
		carsAtWork.Remove(carsAtWork[picked]);
		working--;
	}

	int pickRandomCar()
	{
		System.Random rnd = new System.Random();
		return rnd.Next(0,carsAtWork.Count-1);
	}
}
