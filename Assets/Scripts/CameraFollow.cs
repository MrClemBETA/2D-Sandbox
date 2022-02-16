using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 newPos = target.transform.position + offset;
        transform.position = Vector3.Lerp(pos, newPos, 3f * Time.deltaTime);
    }
}
