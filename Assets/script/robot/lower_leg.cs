using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lower_leg : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        var a = gameObject.transform.parent;
    }

    public float returnEuler(Vector3 rotation,float speed)
    {
        var a = gameObject.transform.parent;
        // Store the current rotation
        var rot = Vector3.forward * rotation.z;
        transform.Rotate(-rot, speed*2 * Time.deltaTime);
        // transform.Rotate(vector3*-100, moveSpeed * Time.deltaTime);
        // var transform1 = transform;
        // var angles = transform1.eulerAngles;
        // angles.z = 0;
        // transform1.eulerAngles = angles;
        // Counteract the initial parent's rotation
        // transform.localRotation = rotation;
        return gameObject.transform.eulerAngles.z;
    }
}
