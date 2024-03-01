using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class left_upper_leg_up_movment : MonoBehaviour
{
    private Vector3 _initialRot;
    private readonly float _moveSpeed = 10f;
    private int _reverse;
    private float _finalRot = (float)15.0;
    private Vector3 _upOrDown = new Vector3(0,0,1);
    private lower_leg _lowerLeg;
    public right_upper_leg_movement _rightUpperLegMovement;
    private bool doStopMoving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _initialRot = gameObject.transform.eulerAngles;
        _lowerLeg = GetComponentInChildren<lower_leg>();
        // if (gameObject.name == "upper leg right")
        // {
        //     yield return new WaitForSeconds ( 1.8f );
        // }
        _reverse = 1;
        transform.Rotate(_reverse*_upOrDown, _moveSpeed * Time.deltaTime);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if(doStopMoving)
            return;
        
        if (gameObject.transform.eulerAngles.z >= _finalRot)
        {
            _reverse *= -1;
            transform.Rotate(_reverse*_upOrDown, _moveSpeed * Time.deltaTime);
            _lowerLeg.returnEuler(_reverse*_upOrDown,_moveSpeed);
            _rightUpperLegMovement.DoStart();
            return;
        }

        if (gameObject.transform.eulerAngles.z == 0)
        {
            DoStop();
        }

        _lowerLeg.returnEuler(_reverse*_upOrDown,_moveSpeed);
        transform.Rotate(_reverse*_upOrDown, _moveSpeed * Time.deltaTime);
    }

    public void DoStop()
    {
        doStopMoving = true;
    }
    
    public void DoStart()
    {
        doStopMoving = false;
        transform.Rotate(_reverse*_upOrDown, _moveSpeed * Time.deltaTime);
    }
}
