using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluePaper : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate GUID for id")]
    private void GenerateGUID()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public bool IsDoorOpened = false;
    public bool IsPlayerCanInteract = false;
    private GameObject player;
    [SerializeField] private GameObject door;
    private Animator doorAnim;
    private BoxCollider2D doorCollider;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        if (IsPlayerCanInteract == true && !IsDoorOpened)
        {
            Read();
        }
        return;
    }

    void Read()
    {
        if (Input.GetKey(KeyCode.E))
        {
            doorAnim.SetBool("isDoorOpen", true);
            doorCollider.enabled = false;
            IsPlayerCanInteract = false;
            IsDoorOpened = true;
        }
    }

    public void LoadData(GameData data)
    {
        data.doorOpened.TryGetValue(id, out IsDoorOpened);
        if (IsDoorOpened == true)
        {
            doorAnim.SetBool("isDoorOpen", true);
            doorCollider.enabled = false;
        }
    }

    public void SaveData(GameData data)
    {
        if (data.doorOpened.ContainsKey(id))
        {
            data.doorOpened.Remove(id);
        }
        data.doorOpened.Add(id, IsDoorOpened);
    }
}
