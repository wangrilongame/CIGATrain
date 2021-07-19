using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float trainSpeed;
    public GameObject railway;
    public Vector2 fowardDirection;
    public Vector2 circleDirection;
    public GameObject deathParticles;

    private float angleSpeed;
    private bool moveAround;
    private Vector2 fowardDirectionBefore;
    private float Clockwise;
    private float turnAngle;

    void Start()
    {
        moveAround = true;
        Clockwise = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveAround = false;
        }

        if (moveAround) {
            circleDirection = (Vector2)railway.transform.position - (Vector2)transform.position;
            fowardDirection = Vector2.Perpendicular(circleDirection) * Clockwise;

            angleSpeed = trainSpeed * 360 / (2f*3.14f* circleDirection.magnitude);
            transform.RotateAround(railway.transform.position, new Vector3(0, 0, -1* Clockwise), angleSpeed * Time.deltaTime);

            Debug.DrawRay(transform.position, circleDirection, Color.red);
            Debug.DrawRay(transform.position, fowardDirection, Color.cyan);
            Debug.DrawRay(transform.position, fowardDirectionBefore, Color.green);

            if (Vector3.Angle(circleDirection, transform.right) > 90f)
                transform.Rotate(transform.forward, Vector3.Angle(circleDirection, transform.up));
            else
                transform.Rotate(transform.forward, -Vector3.Angle(circleDirection, transform.up));


            transform.GetComponent<SpriteRenderer>().flipY = true;
            if (Clockwise == 1)
            {
                transform.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                transform.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else {
            transform.Translate(fowardDirection.normalized * trainSpeed * Time.deltaTime, Space.World);
            if(turnAngle != 0){
                if(fowardDirection.y < 0)
                {
                    if (fowardDirection.x > 0)
                        transform.Rotate(transform.forward, transform.rotation.z - turnAngle);
                    else
                        transform.Rotate(transform.forward, transform.rotation.z + turnAngle);
                } else
                {
                    if (fowardDirection.x > 0)
                        transform.Rotate(transform.forward, transform.rotation.z + turnAngle);
                    else
                        transform.Rotate(transform.forward, transform.rotation.z - turnAngle);

                }

                turnAngle = 0f;
            }
        }
    }
    public void ChangeRailway(GameObject collision)
    {
        railway = collision.gameObject;
        moveAround = true;
        fowardDirectionBefore = fowardDirection;

        Vector2 circleDirectionTemp = (Vector2)railway.transform.position - (Vector2)transform.position;
        Vector2 fowardDirectionTemp = Vector2.Perpendicular(circleDirectionTemp);

        float angle = Mathf.Abs(Vector3.Angle(fowardDirectionBefore, fowardDirectionTemp));
        if (angle > 90)
        {
            Clockwise = -1;
        }
        else
        {
            Clockwise = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("WallX"))
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            turnAngle = Vector2.Angle(fowardDirection, new Vector2(fowardDirection.x, -1 * fowardDirection.y));
            fowardDirection = new Vector2(fowardDirection.x, -1 * fowardDirection.y);
            GameManager.Instance.CutHeart();
        } else if(collision.gameObject.tag.Equals("WallY"))
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            turnAngle = 360-Vector2.Angle(fowardDirection, new Vector2(-1 * fowardDirection.x, fowardDirection.y));
            fowardDirection = new Vector2(-1 * fowardDirection.x, fowardDirection.y);
            GameManager.Instance.CutHeart();
        }

        if (collision.gameObject.tag.Equals("CheckArea"))
        {
            Vector2 circleDirectionTemp = (Vector2)collision.gameObject.GetComponentInParent<Transform>().position - (Vector2)transform.position;
            fowardDirection = (circleDirectionTemp + fowardDirection) / 2;
        }
    }
}
