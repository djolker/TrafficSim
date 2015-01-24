using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	public GameObject worksAt;
	public GameObject car;
	public GameObject floatingText;

    public GameObject gameMaster;

	int cars = 0;

	public string leavingTime;

	// Use this for initialization
	void Start () {
		cars = 1;
	}
	
	// Update is called once per frame
	void Update () {
		floatingText.GetComponent<TextMesh>().text = "Cars: " + cars + "/1";

        if(gameMaster.GetComponent<GameMaster>().time == leavingTime)
        {
            spawnCar();
        }
	}

	public void generateNewLeavingTime()
	{
		System.Random rnd = new System.Random();
		string min = rnd.Next(0,30).ToString();

		if (min.Length == 2)
		{
			leavingTime = "7:" + min;
		}
		else
		{
			leavingTime = "7:0" + min;
		}
	}

	void spawnCar()
	{
		if(cars>0)
		{
			Vector3 pos = new Vector3();
			pos.x = this.transform.position.x;
			pos.z = this.transform.position.z;
			pos.y = 1.03313446f;
			
			car.transform.position = pos;
			
			car.transform.Translate(Vector3.forward * 3f);
			car.GetComponent<Car>().setHome(this.gameObject);
			car.GetComponent<Car>().setTarget(worksAt);
			Instantiate(car, car.transform.position, car.transform.rotation);
			cars--;
		}
	}
}
