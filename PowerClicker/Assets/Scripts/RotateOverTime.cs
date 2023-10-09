using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{

    private float spinSpeed;

    [SerializeField] private float min = -45f;
    [SerializeField] private float max = 45f;
    // Start is called before the first frame update
    void Start()
    {

        spinSpeed = Random.Range(min, max);
        
    }

    // Update is called once per frame
    void Update()
    {

            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
        
    }
}
