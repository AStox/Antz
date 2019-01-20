using UnityEngine;
public class Destination : MonoBehaviour {
    CharacterInput[] characters;
    public float rating;
    void Start()
    {
        characters = (CharacterInput[])GameObject.FindObjectsOfType(typeof(CharacterInput));
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].AddDest();
        }
    }

}