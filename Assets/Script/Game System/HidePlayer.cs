using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidePlayer : MonoBehaviour
{
    private Button button;
    public bool IsPlayerHiding = false;
    public bool IsPlayerCanHide = false;
    public GameObject player { get; set; }
    private void Awake()
    {
        button = GetComponent<Button>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Staying");
        if (collision.gameObject == player)
        {
            IsPlayerCanHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Leaving");
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
            player.SetActive(false);
            IsPlayerHiding = true;
        }
    }

    void Unhide()
    {
        if (Input.GetKey(KeyCode.Space) && IsPlayerHiding == true)
        {
            player.SetActive(true);
            IsPlayerHiding = false;
        }
    }
}
