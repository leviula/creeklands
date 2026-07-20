using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Image image;
    public Button button;

    [Header("Pages")]
    public Page[] pages;

    // The current page's array index
    private int currentPage = 0;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Make sure there are pages
        if (pages == null || pages.Length == 0)
        {
            Debug.LogWarning("No pages have been added to the Page Manager.");
            return;
        }

        // Get the current page
        Page page = pages[currentPage];

        // Update text
        titleText.text = page.title;
        descriptionText.text = page.description;

        // Show or hide the image
        bool hasImage = page.image != null;

        image.gameObject.SetActive(hasImage);

        if (hasImage)
        {
            image.sprite = page.image;
        }

        // Show or hide the button
        button.gameObject.SetActive(page.showButton);

        // Automatically calculate the page number
        int pageNumber = currentPage + 1;

        Debug.Log(
            $"Chapter {page.chapterNumber}, Page {pageNumber}"
        );
    }

    public void NextPage()
    {
        // Prevent going past the last page
        if (currentPage < pages.Length - 1)
        {
            currentPage++;
            UpdateUI();
        }
    }

    public void PreviousPage()
    {
        // Prevent going before the first page
        if (currentPage > 0)
        {
            currentPage--;
            UpdateUI();
        }
    }
}