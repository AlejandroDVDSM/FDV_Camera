using UnityEngine;

public class OneDirectionMovement : MonoBehaviour
{
    [SerializeField] private EDirection direction;
    [SerializeField] private float movementSpeed;

    private Vector3 v;
    
    private void Update()
    {
        if (direction.Equals(EDirection.Right))
            v = (transform.position + Vector3.right) - transform.position;
        else if(direction.Equals(EDirection.Left))
            v = (transform.position + Vector3.left) - transform.position;
        else if(direction.Equals(EDirection.TopRight))
            v = (transform.position + new Vector3(1, 1, 0)) - transform.position;
        else if(direction.Equals(EDirection.TopLeft))
            v = (transform.position + new Vector3(-1, 1, 0)) - transform.position;
         
        transform.Translate(v.normalized * (movementSpeed * Time.deltaTime), Space.World);
    }
}
