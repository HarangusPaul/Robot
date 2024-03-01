using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runFire : MonoBehaviour
{
    public Rigidbody weight;
    public GameObject rock;
    private Vector3 launchPos = new Vector3((float)22.88, (float)18.04, (float)-4.97);
    private bool _fired = false;
    void Start()
    {
    }

    // Update is called once per frame
    int spaceKeyPressed = 0;

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && spaceKeyPressed == 0)
        // {
        //     spaceKeyPressed =+1;
        //     weight.isKinematic = false;
        //     Debug.Log("Space key pressed");
        // }
        //
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     spaceKeyPressed += 1;
        // }
        
        if (rock.transform.localPosition.y >= launchPos.y && !weight.isKinematic)
        {
            // spaceKeyPressed = false;
            HingeJoint destroyRope = rock.GetComponent<HingeJoint>();
            Destroy(destroyRope);
            Debug.Log(rock.transform.localPosition);
        }
    }

    public void doFire()
    {
        weight.isKinematic = false;
    }
}