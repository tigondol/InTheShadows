using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    public bool CheatActivated = false;

    public void ActivateCheat() 
    {
        CheatActivated = true;
    }

    public void DeactivateCheat() 
    {
        CheatActivated = false;
    }

    void Update()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        if (CheatActivated == false)
        {
            for (int i = 0; i < lvlButtons.Length; i++)
            {
                if (i + 1 > levelAt)
                    lvlButtons[i].interactable = false;
            }
        } else {
            for (int i = 0; i < lvlButtons.Length; i++)
            {
                lvlButtons[i].interactable = true;
            }
        }
    }

}
