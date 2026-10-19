using Unity.Mathematics;
using UnityEngine;

public class TurningStars : MonoBehaviour
{
    [SerializeField] float turningDegrees;
    [SerializeField] float turningSpeed;
    float starsRotationY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //starsRotationY = transform.rotation.y;
    }
    void Update()
    {
        //Debug.Log($"{transform.rotation.y}");
        //starsRotationY = starsRotationY * speed * Time.deltaTime;

        starsRotationY = turningDegrees * (turningSpeed*Time.deltaTime);
        transform.Rotate(0f, starsRotationY, 0f);

    }

}
