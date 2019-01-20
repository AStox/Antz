using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour {

	[SerializeField]
	float _speed;
	[SerializeField]
	float _rotation;

	public Incentive currentDestination;
	public bool destAvailable;
	public List<Destination> destList;
	public List<Incentive> incentiveList;


	public struct Incentive {
		public Incentive(Destination _destination)
		{
			destination = _destination;
			if (destination){
				rating = destination.rating;
			}
			else
			{
				rating = 0;
			}
		}
		public Destination destination;
		public float rating;
		public Transform transform{
			get {
				return destination.transform;
			}
		}
		public static Incentive Blank(){
			return new Incentive(null);
		}

	}
	void Start () {
		currentDestination = Incentive.Blank();
	}
	
	// Update is called once per frame
	void Update () {
		//check for a higher priority destination
		if (destList.Count > 0)
		{
			Destination[] destinations = (Destination[])FindObjectsOfType(typeof(Destination));
			for (int i = 0; i < destinations.Length; i++)
			{
				Incentive incentive = CreateIncentive(destinations[i]);

				if (incentive.rating > currentDestination.rating)
				{
					currentDestination = incentive;
				}
			}
		}
		if (currentDestination.rating > 0)
		{
			
			var output = Vector3.Normalize(currentDestination.transform.position);
			transform.Translate(output * Time.deltaTime * _speed, Space.World);
			// transform.position += output * Time.deltaTime * _speed;

			if (output.magnitude > 0)
			{
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(output), _rotation * Time.deltaTime);
			}
		}
	}

	public void CreateIncentive(Destination dest)
	{
		//Make incentive adjustments based on destination's value and tbd factors here

		return new Incentive(destinations[i]);
	}

	public void AddDest(Destination dest)
	{
		destList.Add(dest);
	}
}
