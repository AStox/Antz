using UnityEngine;
public interface IDestination {
    float Rating {get; set;}
    void Interact(Ant ant);
    Transform transform {get; set;}

}