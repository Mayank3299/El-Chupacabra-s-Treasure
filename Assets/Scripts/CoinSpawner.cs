using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    private Vector3 Min;
    private Vector3 Max;
    
    private float _xAxis;
    private float _yAxis;
    private float _zAxis;

    private Vector3 _randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        SetRanges();
        for(int i = 0; i < 10; i++ )
        {
            SpawnCoin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnCoin()
    {
        _xAxis = Random.Range(Min.x, Max.x);
        _yAxis = 0.2f;
        _zAxis = Random.Range(Min.z, Max.z);

        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);

        Instantiate(coin, _randomPosition, coin.transform.rotation);

    }

    private void SetRanges()
    {
        Min = new Vector3(5, 0, -5);
        Max = new Vector3(19, 0, 3);
    }
}
