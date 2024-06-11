using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluePaper : MonoBehaviour
{
    public bool IsPlayerInteracting = false;
    public bool IsPlayerCanInteract = false;
    private GameObject player;
    private StateMachine playerStatemachine;
    [SerializeField] private GameObject door;
    private Animator doorAnim;
    private BoxCollider2D doorCollider;
    [SerializeField] private GameObject ClueImage;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatemachine = player.GetComponent<PlayerStateMachine>();
        doorAnim = door.GetComponent<Animator>();
        doorCollider = door.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            IsPlayerCanInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            IsPlayerCanInteract = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerCanInteract == true)
        {
            Invoke("Read", 0.5f);
        }
        else if (IsPlayerCanInteract == false && IsPlayerInteracting == true)
        {
            Invoke("Close", 0.5f);
        }
    }

    void Read()
    {
        if (Input.GetKey(KeyCode.Space) && IsPlayerInteracting == false)
        {
            playerStatemachine.enabled = false;
            ClueImage.SetActive(true);
            IsPlayerInteracting = true;
            IsPlayerCanInteract = false;
        }
    }

    void Close()
    {
        if (Input.GetKey(KeyCode.Space) && IsPlayerInteracting == true)
        {
            doorAnim.SetBool("isDoorOpen", true);
            doorCollider.enabled = false;
            playerStatemachine.enabled = true;
            ClueImage.SetActive(false);
            IsPlayerInteracting = false;
            IsPlayerCanInteract = true;
        }
    }
}
