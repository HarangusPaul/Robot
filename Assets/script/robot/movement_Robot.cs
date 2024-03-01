using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class movement_Robot : MonoBehaviour
{
    private GameObject _gameObject;

    // private Vector3 initialPos = new Vector3(0, (float)0.762, 0);
    // private Vector3 firstPos = new Vector3(7, (float)0.762, 0);
    // private Vector3 secondPos = new Vector3(7, (float)0.762, -7);
    // private Vector3 thirdPos = new Vector3(0, (float)0.762, 7);
    private Vector3 initialPos;
    private Vector3 firstPos ;
    private Vector3 secondPos;
    private Vector3 thirdPos;
    private float currentRot = 0;
    private static float step = (float)0.001;
    private Vector3 move = new Vector3(step, 0, 0);
    private bool[] _vec = { false, true, true ,true};
    private bool isStoped = false;
    private float initialTime;
    private float currentTime = 0;
    private bool fired = false;
    
    //publics
    public float delay;
    public left_upper_leg_up_movment _leftUpperLegUpMovment;
    public right_upper_leg_movement _rightUpperLegMovement;
    public runFire trabuche;
    public float wallDistance;


    // Start is called before the first frame update
    void Start()
    {
        secondPos = new Vector3(7, 0,7);
        initialPos = transform.localPosition;
        firstPos = transform.localPosition + new Vector3(7,0,0);
        secondPos = transform.localPosition + new Vector3( 7,0,7) + new Vector3(0,0,wallDistance);
        thirdPos = transform.localPosition + new Vector3(0,0,7);
        transform.position += move;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x >= firstPos.x && !_vec[0])
        {
            if (isStoped == false && !fired)
            {
                isStoped = true;
                initialTime = Time.deltaTime;
                _leftUpperLegUpMovment.DoStop();
                _rightUpperLegMovement.DoStop();
                return;
            }

            if (currentTime <= delay && !fired)
            {
                currentTime += Time.deltaTime;
                Debug.Log(Time.deltaTime);
                return;
            }
            
            trabuche.doFire();
            _leftUpperLegUpMovment.DoStart();
            _rightUpperLegMovement.DoStart();

            fired = true;
            currentTime = 0;
            isStoped = false;
            _vec[0] = true;
            _vec[1] = false;
            transform.Rotate(0f, -90f, 0f);
            move = new Vector3(0, 0, step);
        }
        else if (transform.localPosition.z >= secondPos.z && !_vec[1])
        {
            
            _vec[1] = true;
            _vec[2] = false;
            transform.Rotate(0f, -90f, 0f);
            move = new Vector3(-step, 0, 0);
        }
        else if (transform.localPosition.x <= thirdPos.x && !_vec[2])
        {
            _vec[2] = true;
            _vec[3] = false;
            transform.Rotate(0f, -90f, 0f);
            move = new Vector3(0, 0, -step);
        }
        else if (transform.localPosition.z <= initialPos.z && !_vec[3])
        {
            _vec[3] = true;
            _vec[0] = false;
            transform.Rotate(0f, -90f, 0f);
            move = new Vector3(step, 0, 0);
            // for (var i = 0; i < _vec.Length-1; i++)
            // {
            //     _vec[i] = true;
            // }
            transform.position += move;
        }
        else
            transform.position += move;
    }

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds ( seconds );
    }
}