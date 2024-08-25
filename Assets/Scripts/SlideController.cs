using UnityEngine;

public class SlideController : MonoBehaviour
{
    // Array to store references to slide materials
    public Material[] slideMaterials;

    // Reference to the screen object whose material will change
    public Renderer screenRenderer;

    // Singleton instance
    private static SlideController instance;

    // Static variable to store the current slide index
    private static int currentSlideIndex = 0;

    void Start()
    {
        // Ensure the screen renderer is assigned
        if (screenRenderer == null)
        {
            Debug.LogError("Screen Renderer is not assigned!");
            return;
        }

        // Check if there are slide materials
        if (slideMaterials.Length == 0)
        {
            Debug.LogError("No slide materials assigned!");
            return;
        }

        // Set the material of the screen to the initial slide
        screenRenderer.material = slideMaterials[currentSlideIndex];
    }

    // Method to change to the next slide
    public void NextSlide()
    {
        // Increment the slide index
        currentSlideIndex++;

        // If we reach the end, loop back to the first slide
        if (currentSlideIndex >= slideMaterials.Length)
        {
            currentSlideIndex = 0;
        }

        // Update the slide for all instances
        UpdateSlideForAllInstances();
    }

    // Method to change to the previous slide
    public void PreviousSlide()
    {
        // Decrement the slide index
        currentSlideIndex--;

        // If we reach the beginning, loop to the last slide
        if (currentSlideIndex < 0)
        {
            currentSlideIndex = slideMaterials.Length - 1;
        }

        // Update the slide for all instances
        UpdateSlideForAllInstances();
    }

    // Method to update the slide for all instances
    private void UpdateSlideForAllInstances()
    {
        // Find all instances of SlideController in the scene
        SlideController[] slideControllers = FindObjectsOfType<SlideController>();

        // Update the slide index for each instance
        foreach (SlideController controller in slideControllers)
        {
            controller.screenRenderer.material = slideMaterials[currentSlideIndex];
        }
    }
}
