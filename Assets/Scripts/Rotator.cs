using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    public bool EasyMod;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody> ();
    }

    void OnMouseDrag () {
        dragging = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)){
            dragging = false;
        }
    }
    void FixedUpdate(){
        if (dragging & !Input.GetButton("Jump")){
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            if (EasyMod == false) {
                float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;
                rb.AddTorque(Vector3.right*(-y));
            }

            rb.AddTorque(Vector3.down*x);
        }
    }
}
