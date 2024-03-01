using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class lower_arm_B : MonoBehaviour
{
    private GameObject _gameObject;
    private readonly float _moveSpeed = 10f;
    private int _reverse;
    private Vector3 _initialRot;
    private int _finalRot = 22;
    private Vector3 _upOrDown = Vector3.down; //up = true down = false

    // Start is called before the first frame update
    void Start()
    {
        _initialRot = gameObject.transform.eulerAngles;
        Debug.Log(gameObject.transform.rotation);
        _reverse = gameObject.transform.rotation.y > 0?1:-1;
        transform.Rotate(_reverse*_upOrDown, _moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        var _currentRot = gameObject.transform.eulerAngles;
        var spinningInReverse = _reverse < 0;
        if (!spinningInReverse?contdition2_left(_initialRot.x, _currentRot.x):contdition2_right(_initialRot.x, _currentRot.x))
        {
            _upOrDown = _reverse*Vector3.down;
            transform.Rotate(_upOrDown, _moveSpeed * Time.deltaTime);
            return;
        }

        if (!spinningInReverse?contdition1_left(_initialRot.x-_finalRot, _currentRot.x):contdition1_right(_initialRot.x+_finalRot, _currentRot.x))
        {
            _upOrDown = _reverse*Vector3.up;
            transform.Rotate(_upOrDown, _moveSpeed * Time.deltaTime);
            return;
        }
        transform.Rotate(_upOrDown, _moveSpeed * Time.deltaTime);
    }


    private bool contdition1_left(float primComp, float value)
    {
        return value <= primComp;
    }
    
    private bool contdition2_left(float primComp, float value)
    {
        return value >= primComp;
    }
    
    private bool contdition1_right(float primComp, float value)
    {
        return value >= primComp;
    }
    
    private bool contdition2_right(float primComp, float value)
    {
        return value <= primComp;
    }
}