using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    public float rotateSpeed = 50.0f; 
    public float moveSpeed = 50.0f; 

    void Update()
    {
        
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

       
        float moveVertical = Input.GetAxis("Vertical"); 
  
        float moveHorizontal = Input.GetAxis("Horizontal"); 

   
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

      
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);
    }
}



