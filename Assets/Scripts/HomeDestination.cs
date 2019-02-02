using UnityEngine;
public class HomeDestination : MonoBehaviour, IDestination {
    Ant[] ants;
    public float Rating{get; set;}
    public Transform transform{get; set;}
    float valueStore;
    void Awake()
    {
        transform = this.gameObject.GetComponent<Transform>();
    }

    public void Interact(Ant ant)
    {
        valueStore += ant.value;
        ant.value = 0;
    }
}