using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCarriage : MonoBehaviour
{
    public GameObject forwardPoint;
    public GameObject railwayPoint;
    public Vector3 direction;

    private bool moveAround;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveAround = false;
        }

        if (moveAround)
        {
            direction = railwayPoint.GetComponentInParent<Transform>().transform.position - transform.position;
            if (Vector3.Angle(direction, transform.right) > 90f) // Ŀ������ұ�
            {
                transform.Rotate(transform.forward, Vector3.Angle(direction, transform.up) - 180 );
            }
            else // Ŀ��������
            {
                transform.Rotate(transform.forward, -Vector3.Angle(direction, transform.up) - 180);
            }
        }
        else
        {
            direction = forwardPoint.transform.position - transform.position;
            if (Vector3.Angle(direction, transform.right) > 90f) // Ŀ������ұ�
            {
                transform.Rotate(transform.forward, Vector3.Angle(direction, transform.up) - 90);
            }
            else // Ŀ��������
            {
                transform.Rotate(transform.forward, -Vector3.Angle(direction, transform.up) + 90);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Railway"))
        {
            moveAround = true;
            railwayPoint = collision.gameObject;
        }
    }
}
