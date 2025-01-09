using UnityEngine;

public class EmotionalStateManager : MonoBehaviour
{
    public enum EmotionState { Happy, Sad, Angry, Neutral }
    public EmotionState currentEmotion = EmotionState.Neutral;

    public Renderer faceRenderer; // Reference to character's face material
    public AudioSource voiceSource; // Reference to character's voice audio source

    public AudioClip happyVoice;
    public AudioClip sadVoice;
    public AudioClip angryVoice;

    public void UpdateEmotion(EmotionState newEmotion)
    {
        currentEmotion = newEmotion;

        switch (currentEmotion)
        {
            case EmotionState.Happy:
                faceRenderer.material.color = Color.green;
                PlayEmotionVoice(happyVoice);
                break;

            case EmotionState.Sad:
                faceRenderer.material.color = Color.blue;
                PlayEmotionVoice(sadVoice);
                break;

            case EmotionState.Angry:
                faceRenderer.material.color = Color.red;
                PlayEmotionVoice(angryVoice);
                break;

            case EmotionState.Neutral:
                faceRenderer.material.color = Color.white;
                break;
        }

        Debug.Log($"Emotion updated to {currentEmotion}");
    }

    private void PlayEmotionVoice(AudioClip clip)
    {
        if (voiceSource != null && clip != null)
        {
            voiceSource.clip = clip;
            voiceSource.Play();
        }
    }
}