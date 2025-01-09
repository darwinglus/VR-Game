using UnityEngine;

public class DynamicEnvironmentManager : MonoBehaviour
{
    public Light globalLight; // Reference to main light
    public AudioSource ambientSound; // Reference to ambient sound
    public ParticleSystem rainEffect; // Reference to rain particle system

    public void ChangeEnvironment(string environmentType)
    {
        switch (environmentType.ToLower())
        {
            case "forest":
                globalLight.color = Color.green;
                ambientSound.clip = Resources.Load<AudioClip>("Audio/ForestAmbience");
                rainEffect.Stop();
                Debug.Log("Environment changed to Forest.");
                break;

            case "cave":
                globalLight.color = Color.gray;
                ambientSound.clip = Resources.Load<AudioClip>("Audio/CaveAmbience");
                rainEffect.Stop();
                Debug.Log("Environment changed to Cave.");
                break;

            case "rainy":
                globalLight.color = Color.blue;
                rainEffect.Play();
                Debug.Log("Environment changed to Rainy.");
                break;

            default:
                Debug.LogWarning("Unknown environment type!");
                break;
        }

        if (ambientSound != null && ambientSound.clip != null)
        {
            ambientSound.Play();
        }
    }
}