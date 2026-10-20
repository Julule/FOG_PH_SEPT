using System;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollowing();
    }

    private void CameraFollowing()
    {
       Transform objectToFollowTransform = objectToFollow.transform;
        transform.position = objectToFollowTransform.position;
    }
}
