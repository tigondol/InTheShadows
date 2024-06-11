using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 150f;
    bool dragging = true;
    public GameObject target;
    public bool easyMod = false;

    void Update()
    {
        dragging = Input.GetMouseButton(0);
    }
    void FixedUpdate(){
        if (Input.GetButton("Jump") & dragging){
            Debug.Log("GetMouseButton = " + Input.GetMouseButton(0));
            Debug.Log("dragging = " + dragging);
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;

            if (!easyMod) transform.RotateAround(target.transform.position, Vector3.right, (-y));
            transform.RotateAround(target.transform.position, Vector3.up, (-x));
        }
    }
}
