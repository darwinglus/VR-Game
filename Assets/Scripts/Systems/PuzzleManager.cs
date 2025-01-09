using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzlePieces; // Puzzle pieces in the scene
    public Transform[] targetPositions; // Target positions for each piece
    public float placementThreshold = 0.5f; // Threshold distance to snap into place

    private bool isPuzzleCompleted = false;

    private void Update()
    {
        if (!isPuzzleCompleted)
        {
            CheckPuzzleCompletion();
        }
    }

    private void CheckPuzzleCompletion()
    {
        int correctlyPlacedCount = 0;

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (Vector3.Distance(puzzlePieces[i].transform.position, targetPositions[i].position) < placementThreshold)
            {
                correctlyPlacedCount++;
            }
        }

        if (correctlyPlacedCount == puzzlePieces.Length)
        {
            isPuzzleCompleted = true;
            OnPuzzleCompleted();
        }
    }

    private void OnPuzzleCompleted()
    {
        Debug.Log("Puzzle completed!");
        // Trigger rewards or next stage
    }
}