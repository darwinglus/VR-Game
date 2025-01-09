using UnityEngine;

public class ARInteractionManager : MonoBehaviour
{
    public Camera arCamera; // AR camera reference
    public GameObject arObject; // Object to place in AR

    private bool isObjectPlaced = false;

    private void Update()
    {
        if (!isObjectPlaced && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObjectInAR();
        }
    }

    private void PlaceObjectInAR