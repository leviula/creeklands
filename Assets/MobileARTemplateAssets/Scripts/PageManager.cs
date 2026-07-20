using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Image image;
    public Button button;

    [Header("Page Data")]
    public Page[] pages;

    private int currentPage = 0;

    [Header("Page Layouts")]
    public GameObject mainContentLayout;
    public GameObject differentPageLayout;
    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        Page page = pages[currentPage];


        // Hide both layouts first
        mainContentLayout.SetActive(false);
        differentPageLayout.SetActive(false);

        // Activate the correct one
        switch (page.pageType){
            case PageType.MainContent:
                mainContentLayout.SetActive(true);
                break;

            case PageType.DifferentPage:
                differentPageLayout.SetActive(true);
                break;
        }
        titleText.text = page.title;
        descriptionText.text = page.description;

        bool hasImage = page.image != null;

        image.gameObject.SetActive(hasImage);

        if (hasImage)
        {
            image.sprite = page.image;
        }

        button.gameObject.SetActive(!page.hideButton);
    }

    public void NextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            currentPage++;
            UpdateUI();
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdateUI();
        }
    }
}
