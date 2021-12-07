using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public float gravity;
    public Vector2 velocity;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float groundHeight = 10;
    public float jumpVelocity = 50;
    public float maxXVelocity = 100;
    public bool isGrounded = false;

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;

    public float jumpGroundThreshold = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float groundDisatance = Mathf.Abs(pos.y - groundHeight);

        if(isGrounded || groundDisatance <= jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0;

            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (!isGrounded)
        {

            if(isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if(holdJumpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }    
            //increment player position every frame of game also adjust how much the next frame thats able to get adjusted, take grav and pull back velocity so position gets adjusted by a smaller velocity till velocity is 0 then grav makes velocity go negative.

            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }
            if (pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
            }
        }

        if (isGrounded)
        {
            velocity.x += acceleration * Time.fixedDeltaTime;
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);

            if (velocity.x >= maxXVelocity)
            {
                velocity.x = maXVelocity;
            }
        }

        transform.position = pos;

    }
}
