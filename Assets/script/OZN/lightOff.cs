using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class lightOff : MonoBehaviour
{
    Light myLight;

    private float changeTime = 0f;
    public float delay;

    public Light light1;
    public Light light2;
    public Light light3;
    public Light light4;
    public bodyRotation BodyRotation;

    private bool[] lights = { true, true, false, false };

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        light1.enabled = lights[0];
        light2.enabled = lights[3];
        light3.enabled = lights[2];
        light4.enabled = lights[1];

        var localRot = BodyRotation.getRotationY();
        localRot -= 360;
        localRot *= -1;

        if (val(0,90,localRot))
        {
            reset();
            lights[0] = true;
            lights[1] = true;
        }
        
        if (val(90,180,localRot))
        {
            reset();
            lights[1] = true;
            lights[2] = true;
        }
        
        if (val(180,270,localRot))
        {
            reset();
            lights[2] = true;
            lights[3] = true;
        }
        
        if (val(270,360,localRot))
        {
            reset();
            lights[3] = true;
            lights[0] = true;
        }
        // for (var i = 0; i <= 3; i++)
        // {
        //     var j = 0;
        //     foreach (var b in lights)
        //     {
        //         if (b)
        //         {
        //             j++;
        //             break;
        //         }
        //
        //         j++;
        //     }
        //
        //     if (changeTime == 0)
        //     {
        //         changeTime += Time.deltaTime;
        //     }
        //     else if (changeTime < delay)
        //     {
        //         changeTime += Time.deltaTime;
        //         return;
        //     }
        //
        //     switch (j)
        //     {
        //         case 0:
        //         {
        //             light1.enabled = true;
        //             reset();
        //             lights[0] = true;
        //             break;
        //         }
        //         case 1:
        //         {
        //             light2.enabled = true;
        //             reset();
        //             lights[1] = true;
        //             break;
        //         }
        //         case 2:
        //         {
        //             light3.enabled = true;
        //             reset();
        //             lights[2] = true;
        //             break;
        //         }
        //         case 3:
        //         {
        //             light4.enabled = true;
        //             reset();
        //             lights[3] = true;
        //             break;
        //         }
        //     }
        // }
    }

    // float randomNumber = Random.Range(1, 4);
    // if (myLight.name == randomNumber.ToString())
    // {
    //     if (changeTime == 0)
    //     {
    //         changeTime += Time.deltaTime;
    //     } else
    //     if (changeTime < delay)
    //     {
    //         changeTime += Time.deltaTime;
    //         return;
    //     }
    //     myLight.enabled = !myLight.enabled;
    // }
    
    public bool val(int x, int y, float z)
    {
        return x < z && z < y;
    }

    public void reset()
    {
        for (var i1 = 0; i1 < lights.Length; i1++)
        {
            lights[i1] = false;
        }
    }
}