using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // komponent som gör det möjligt att använda fysik för kontroller
    Rigidbody rb;

    public LayerMask layerMask;
    public bool Grounded;

    // public gör det möjligt att ändra koden utan att gå in i VSC
    public float moveSpeed = 6;
    public float jumpForce = 12;
   
   // körs en gång när scriptet startas
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // körs varje frame
    void Update()
    {
        // lägger till så bollen kan röra sig höger och vänster
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;

        // kollar om bollen är på marken
        Grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y -1, transform.position.z), 0.4f, layerMask);

        // kollar om man klickar på space och om man är på marken för att kunna hoppa
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
   
        // sätter och uppdaterar nya positionen
        Vector3 movePos = transform.right * x + transform.forward * y;
        Vector3 newMovePos = new Vector3(movePos.x, rb.velocity.y, movePos.z);

        rb.velocity = newMovePos;
    }
}
