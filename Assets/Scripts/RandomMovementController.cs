using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMovementController : MonoBehaviour
{
    public float Radius = 3.0f;
    public float MoveDuration = 1.0f;

    private void Start()
    {
        Random.InitState(DateTime.Now.Millisecond);
        MoveToRandomPosition();
    }    
    
    private void Update()
    {
        _moveTime += Time.deltaTime;
        if (_moveTime < MoveDuration)
        {            
            transform.localPosition = Vector3.Lerp(_from, _to, Smooth(_moveTime / MoveDuration));            
        }
        else
        {
            transform.localPosition = _to;
            MoveToRandomPosition();
        }
    }

    private void MoveToRandomPosition()
    {
        _from = transform.localPosition;
        _to = Radius * Random.onUnitSphere;
        _moveTime = 0;
    }

    private static float Smooth(float t)
    {
        return 0.5f * (1.0f - Mathf.Cos(Mathf.PI * t));
    }

    private float _moveTime;
    private Vector3 _from;
    private Vector3 _to;
}
