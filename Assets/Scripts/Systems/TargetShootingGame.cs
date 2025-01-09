using UnityEngine;

public class TargetShootingGame : MonoBehaviour
{
    public GameObject[] targets;
    public int score = 0;

    public void ShootTarget(RaycastHit hit)
    {
        if (hit.collider != null && hit.collider.CompareTag("Target"))
        {
            Destroy(hit.collider.gameObject);
            score += 10;
            Debug.Log("Target hit! Score: " + score);
        }
    }
}