using UnityEngine;

[System.Serializable]
public class Page
{
    [Header("Page Information")]
    public int chapterNumber = 0;

    [Header("Content")]
    public string title;

    [TextArea(3, 10)]
    public string description;

    [Header("Optional Content")]
    public Sprite image;

    public bool showButton;
}