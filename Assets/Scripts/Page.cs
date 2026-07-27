using UnityEngine;

public enum PageType
{
    StoryLayoutText,
    CardLayout,
    StoryLayoutImage
}

[System.Serializable]
public class Page
{
    public int chapterNumber;
    public PageType pageType;

    [Header("Content")]
    public string title;

    [TextArea(3, 10)]
    public string description;

    public Sprite image;

    [Header("Card Content")]
    public string label1;
    public string label2;

    [Header("Optional Content")]
    public bool hideButton;
}