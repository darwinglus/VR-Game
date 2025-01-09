using UnityEngine;
using UnityEngine.XR;

public class HapticFeedbackManager : MonoBehaviour
{
    public void TriggerHapticFeedback(float intensity, float duration)
    {
        foreach (var device in InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand))
        {
            if (device.TryGetHapticCapabilities(out var hapticCapabilities) && hapticCapabilities.supportsImpulse)
            {
                uint channel = 0;
                device.SendHapticImpulse(channel, intensity, duration);
                Debug.Log($"Haptic feedback triggered with intensity {intensity} for {duration} seconds.");
            }
        }
    }
}