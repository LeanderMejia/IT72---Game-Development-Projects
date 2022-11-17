using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player: MonoBehaviour
{
    [SerializeField] private float speed;
    
    public Text CollisionPoint;
    public List<string> cordinatesList = new List<string>();
    public float velocityBall;
   
    private Rigidbody rb;
    private int count; void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        
        
    }
    void Update()
    {
        velocityBall = rb.velocity.magnitude;
        
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
       
     float moveVertical = Input.GetAxis("Vertical"); Vector3 movement =
new Vector3(moveHorizontal, 0.0f, moveVertical); rb.AddForce(movement
* speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
           
            CollisionPoint.text = "Collision point: " +
           other.transform.position.ToString();
            cordinatesList.Add(CollisionPoint.text);
        }
    }
    
    
}
