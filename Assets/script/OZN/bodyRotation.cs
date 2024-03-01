using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyRotation : MonoBehaviour
{
    private readonly float _moveSpeed = 10f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down, _moveSpeed * Time.deltaTime);
        
        // transform.position += Vector3.back;
        // Debug.Log(transform.position.y);
    }


    public float getRotationY()
    {
        return transform.eulerAngles.y;
    }
}
