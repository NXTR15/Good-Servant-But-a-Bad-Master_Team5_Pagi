using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidePlayer : MonoBehaviour
{
    private Animator boxAnim;
    public bool IsPlayerHiding = false;
    public bool IsPlayerCanHide = false;
    public GameObject player { get; set; }
    private void Awake()
    {
        boxAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            IsPlayerCanHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            IsPlayerCanHide = false;
        }
    }
    private void FixedUpdate()
    {
        if (IsPlayerCanHide == true)
        {
            
            Hide();
        }
        else if (IsPlayerCanHide == false && IsPlayerHiding == true)
        {
            Invoke("Unhide", 0.5f);
        }
    }

    void Hide()
    {
        if (Input.GetKey(KeyCode.Space) && IsPlayerHiding == false)
        {
            boxAnim.SetBool("isHiding", true);
            player.SetActive(false);
            IsPlayerHiding = true;
        }
    }

    void Unhide()
    {
        if (Input.GetKey(KeyCode.Space) && IsPlayerHiding == true)
        {
            boxAnim.SetBool("isHiding", false);
            player.SetActive(true);
            IsPlayerHiding = false;
        }
    }
}
