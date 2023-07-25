using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourQuizManager : MonoBehaviour
{
    private bool quizComplete = false;

    public void OnSkipButtonClick()
    {
        quizComplete = false;
        // Handle any other actions you want to perform when the "Skip" button is clicked.
    }

    public void OnNextButtonClick()
    {
        quizComplete = true;
        // Handle any other actions you want to perform when the "Next" button is clicked.
    }

    // Getter method to access the quizComplete variable from other scripts
    public bool IsQuizComplete()
    {
        return quizComplete;
    }

    
}
