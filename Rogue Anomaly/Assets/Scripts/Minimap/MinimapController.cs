using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    [SerializeField] Transform trackTarget;
    [SerializeField] float cameraHeight = 100;
    [SerializeField] bool lockNorth = true;

    void Update()
    {
        transform.position = new Vector3(trackTarget.position.x, cameraHeight, trackTarget.position.z);

        if (!lockNorth) {
            transform.rotation = Quaternion.Euler(90, trackTarget.transform.rotation.eulerAngles.y, 0);
        } else {
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
}
