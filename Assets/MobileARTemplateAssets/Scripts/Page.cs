using UnityEngine;

public enum PageType
{
    MainContent,
    DifferentPage
}

[System.Serializable]

public class Page
{
    [Header("Page Information")]
    public int chapterNumber = 0;

    public PageType pageType;

    [Header("Content")]
    public string title;

    [TextArea(3, 10)]
    public string description;

    [Header("Optional Content")]
    public Sprite image;

    public bool hideButton;
}