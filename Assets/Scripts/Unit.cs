using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Unit : MonoBehaviour
{
    const float DISTANCE_THRESHOLD = 0.1f;

    [SerializeField]
    private float speed = 5f;

    private Vector3 targetPosition;

    public void Move(Vector3 position)
    {
        targetPosition = position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(targetPosition, transform.position) > DISTANCE_THRESHOLD)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += speed * Time.deltaTime * moveDirection;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetMousePosition());
        }
    }
}
