using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    // Array of background images
    public Image[] backgrounds;
    private int currentBackgroundIndex = 0;

    void Start()
    {
        ShowBackground(currentBackgroundIndex);
    }

    // Switch the background to the specified sprite and position
    public void SwitchBackground(Sprite sprite, Vector2 newPosition)
    {
        currentBackgroundIndex = (currentBackgroundIndex + 1) % backgrounds.Length;
        SetBackgroundSprite(currentBackgroundIndex, sprite, newPosition);
    }

    // Set the sprite and position of the background at the specified index
    private void SetBackgroundSprite(int index, Sprite sprite, Vector2 newPosition)
    {
        backgrounds[index].sprite = sprite;
        backgrounds[index].rectTransform.anchoredPosition = newPosition;
        ShowBackground(index);
    }

    // Show the background at the specified index
    private void ShowBackground(int index)
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].gameObject.SetActive(i == index);
        }
    }
}
