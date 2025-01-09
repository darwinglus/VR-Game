public class WeatherSystem : MonoBehaviour
{
    public Light directionalLight;
    public float dayDuration = 120f; // in seconds
    private float timeOfDay = 0f;

    public string currentWeather = "Sunny";
    private string[] weatherTypes = { "Sunny", "Rainy", "Cloudy", "Stormy" };

    private void Update()
    {
        UpdateDayCycle();
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeWeather();
        }
    }

    private void UpdateDayCycle()
    {
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay > 1f)
            timeOfDay = 0f;

        float angle = timeOfDay * 360f - 90f;
        directionalLight.transform.rotation = Quaternion.Euler(angle, 170f, 0f);
        directionalLight.intensity = Mathf.Clamp01(1.5f - Mathf.Abs(angle / 180f));
    }

    private void ChangeWeather()
    {
        currentWeather = weatherTypes[Random.Range(0, weatherTypes.Length)];
        Debug.Log($"Weather changed to {currentWeather}");
    }
}