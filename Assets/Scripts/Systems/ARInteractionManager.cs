using UnityEngine;

public class ARInteractionManager : MonoBehaviour
{
    [Header("AR Components")]
    [Tooltip("Reference to the AR camera.")]
    [SerializeField] private Camera arCamera;

    [Tooltip("Prefab or object to be placed in AR.")]
    [SerializeField] private GameObject arObject;

    private bool isObjectPlaced = false;

    private void Update()
    {
        if (isObjectPlaced) return;

        HandleTouchInput();
    }

    /// <summary>
    /// Handles user touch input for placing the AR object.
    /// </summary>
    private void HandleTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObjectInAR();
        }
    }

    /// <summary>
    /// Instantiates and places the object in AR space.
    /// </summary>
    private void PlaceObjectInAR()
    {
        if (arCamera == null || arObject == null)
        {
            Debug.LogError("[ARInteractionManager] Missing AR camera or AR object reference.");
            return;
        }

        // Raycast from the touch position to detect AR plane
        Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Instantiate the AR object at
