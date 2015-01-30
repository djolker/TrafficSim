using UnityEngine;
using System.Collections;

public class carDetail {

	public GameObject target;
	public GameObject home;
	public GameObject work;
	public float carspeed;

	/// <summary>
	/// Sets the car detail values.
	/// </summary>
	/// <param name="target">Target.</param>
	/// <param name="home">Home.</param>
	/// <param name="work">Work.</param>
	/// <param name="carspeed">Carspeed.</param>
	public void setCarDetailValues(GameObject target, GameObject home, GameObject work, float carspeed)
	{
		this.target = target;
		this.home = home;
		this.work = work;
		this.carspeed = carspeed;
	}
}
