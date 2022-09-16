using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    [SerializeField] Transform trackTarget;
    [SerializeField] float cameraHeight = 100;

    void Update()
    {
        transform.position = new Vector3(trackTarget.position.x, cameraHeight, trackTarget.position.z);
    }
}
