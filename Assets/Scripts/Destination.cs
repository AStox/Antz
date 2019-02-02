using UnityEngine;

public class Destination : MonoBehaviour, IDestination {
    Ant[] ants;
    public float Rating{get; set;}
    public float rating = 5;
    public Transform transform {get; set;}
    void Awake()
    {
        Rating = rating;
        transform = this.gameObject.GetComponent<Transform>();
    }

    public void Interact(Ant ant)
    {
        Rating -= 1;
        ant.value += 1;
        if (Rating < 0)
        {
            Rating = 0;
        }
    }
}

