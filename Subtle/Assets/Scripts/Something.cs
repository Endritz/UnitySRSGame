using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles interactions with the animator component of the player
/// It reads the player's state from the controller and animates accordingly
/// </summary>
public class Something : MonoBehaviour
{
    public GameObject Player;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", true);
        }


        //else
        //{
        //    Player.GetComponent<Animator>().Play("Run");
        //}
    }
}