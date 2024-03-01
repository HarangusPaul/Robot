using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oznMov : MonoBehaviour
{
    // Start is called before the first frame update
    public float slowDoyn;

    private Vector3 direction;
    void Start()
    {
        direction = (Vector3.back/slowDoyn);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction;
        if (transform.position.z < 0.5 || transform.position.z > 20.5)
        {
            direction *= -1;
        }
        
    }
}
