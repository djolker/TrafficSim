using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour {
	public GameObject timer;
	public GameObject crashCount;

	#region time
    public string time;
    private double timePassed;

    private float hour;
    public float minute;
	#endregion

	public int carCrashes;
	public int carsStuck;


	public List<GameObject> houses = new List<GameObject>();
	public List<GameObject> businesses = new List<GameObject>();
	public List<GameObject> cars = new List<GameObject>();

	// Use this for initialization
	void Start () {
        hour = 6f;
        minute = 0f;
		carCrashes = 0;

		//count all houses
		houses = countHouses();
		businesses = countBusinesses();
		cars = countCars();
		initHouses();

	}
	
	// Update is called once per frame
	void Update () {
        runTime();
		crashCount.GetComponent<GUIText>().text = "Car Crashes: " + carCrashes;
        timer.GetComponent<GUIText>().text = "Time: " + time;
	}

	void initHouses()
	{
		foreach(GameObject house in houses)
		{
			house.GetComponent<House>().generateNewLeavingTime();
		}
	}

    void runTime()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 1)
        {
            minute++;
            timePassed = 0f;
        }

        if (minute >= 60f)
        {
            hour++;
            minute = 0f;
        }

        if (hour >= 24)
        {
            hour = 0f;
        }

        if (minute.ToString().Length == 2)
        {
            time = hour.ToString() + ":" + minute.ToString();
        }
        else
        {
            time = hour.ToString() + ":0" + minute.ToString();
        }
    }

	List<GameObject> countHouses()
	{
		List<GameObject> houses = new List<GameObject>();
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("House"))
		{
			houses.Add(go);
		}

		return houses;
	}

	List<GameObject> countBusinesses()
	{
		List<GameObject> businesses = new List<GameObject>();
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Business"))
		{
			businesses.Add(go);
		}
	}

	List<GameObject> countCars()
	{

	}
}
