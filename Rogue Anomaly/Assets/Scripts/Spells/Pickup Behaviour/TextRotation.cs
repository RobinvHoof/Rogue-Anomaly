using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TextRotation : MonoBehaviour
{
    [SerializeField]
    Transform target;

    // Update is called once per frame
    void Update()
    {
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(-direction.x, direction.y, -direction.z), Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 4);
    }
}
