using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicPlayer : MonoBehaviour
{
    [SerializeField] private string bgmName;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(bgmName);
    }
}
