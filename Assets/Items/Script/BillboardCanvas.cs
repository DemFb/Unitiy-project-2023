using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCanvas : MonoBehaviour
{
    public Transform cameraTramnsform;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraTramnsform); 
    }
}
