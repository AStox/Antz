using UnityEngine;

public class ClickScript : MonoBehaviour {

    Camera mainCam;
    public GameObject destination;

    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = mainCam.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Vector3 pos = hit.point;
                Instantiate(destination, pos, Quaternion.identity);
            }
        }
    }

}