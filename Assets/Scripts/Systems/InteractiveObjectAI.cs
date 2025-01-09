using UnityEngine;

public class InteractiveObjectAI : MonoBehaviour
{
    public AudioClip interactionSound;
    public Vector3 movementOffset;
    public float interactionCooldown = 5f;

    private bool isInteractable = true;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void Interact()
    {
        if (isInteractable)
        {
            PlayInteractionSound();
            MoveObject();
            StartCoroutine(CooldownInteraction());
        }
    }

    private void PlayInteractionSound()
    {
        AudioSource.PlayClipAtPoint(interactionSound, transform.position);
    }

    private void MoveObject()
    {
        transform.position = originalPosition + movementOffset;
    }

    private System.Collections.IEnumerator CooldownInteraction()
    {
        isInteractable = false;
        yield return new WaitForSeconds(interactionCooldown);
        transform.position = originalPosition;
        isInteractable = true;
    }
}