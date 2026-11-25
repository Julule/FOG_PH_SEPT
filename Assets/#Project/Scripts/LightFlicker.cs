using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float baseIntensity = 1.5f;
    public float amplitude = 0.5f;
    public float speed = 2f;

    Light objectLight;

    void Start() => objectLight = GetComponent<Light>();

    void Update()
    {
        float n = Mathf.PerlinNoise(Time.time * speed, 0f);
        objectLight.intensity = baseIntensity + (n - 0.5f) * 2f * amplitude;
    }
}
