using System;
using Unity.Collections;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    
    [SerializeField] private Vector3 cameraDistance;
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
        transform.position = objectToFollowTransform.position + cameraDistance;
    }
}
