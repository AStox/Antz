using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ant : MonoBehaviour {

	[SerializeField]
	float _speed;
	[SerializeField]
	float _rotation;
	bool canInteract = true;

	public Incentive currentDestination;
	public HomeDestination homeDestination;
	public bool destAvailable;
	public List<IDestination> destList;
	public List<Incentive> incentiveList;
	public float value = 0;


	public struct Incentive {
		public Incentive(IDestination _destination)
		{
			destination = _destination;
			if (destination != null){
				rating = destination.Rating;
			}
			else
			{
				rating = 0;
			}
		}
		public IDestination destination;
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
		currentDestination = CreateIncentive(homeDestination);
	}
	
	// Update is called once per frame
	void Update () {
		//check for a higher priority destination
		var destinations = GameObject.FindObjectsOfType(typeof(Destination));
		foreach(Destination dest in destinations)
		{
			Incentive incentive = CreateIncentive(dest);

			if (incentive.rating > currentDestination.rating)
			{
				currentDestination = incentive;
			}
		}
		if (value > 0)
		{
			currentDestination = CreateIncentive(homeDestination);
		}
		var output = Vector3.Normalize(currentDestination.destination.transform.position - transform.position);
		float dist = Vector3.Distance(transform.position, currentDestination.transform.position);
		transform.Translate(output * Time.deltaTime * _speed * Mathf.Clamp01(dist + 0.1f), Space.World);
		// transform.position += output * Time.deltaTime * _speed;

		if (output.magnitude > 0)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(output), _rotation * Time.deltaTime);
		}

		if (dist < 0.001f)
		{
			currentDestination.destination.Interact(this);
		}
	}

	public Incentive CreateIncentive(IDestination dest)
	{
		//Make incentive adjustments based on destination's value and tbd factors here
		//- Base value (declines when ant reaches it)
		//- Proximity

		return new Incentive(dest);
	}

	public void FindDestinations() {
		destList = new List<IDestination>();
		IDestination[] destinations = (IDestination[])GameObject.FindObjectsOfType(typeof(IDestination));
		foreach (IDestination dest in destinations)
		{
			destList.Add(dest);
		}
	}

	public void AddDest(IDestination dest)
	{
		destList.Add(dest);
	}
}
