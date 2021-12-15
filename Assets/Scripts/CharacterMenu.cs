using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{

    public Text levelText, hitpointText, goldText, upgradeCostText, xpText;

    // Logic
    public RectTransform xpBar;

    //Update the character Information
    public void UpdateMenu()
    {

        //meta
        hitpointText.text = Gamemanager.instance.player.hitpoint.ToString();
        goldText.text = Gamemanager.instance.gold.ToString();

        //xp
        levelText.text = Gamemanager.instance.GetCurrentLevel().ToString();

        //xp bar
        int currLvl = Gamemanager.instance.GetCurrentLevel();
        if(currLvl == Gamemanager.instance.xpTable.Count)
        {
            xpText.text = Gamemanager.instance.experience.ToString() + " total experience points"; // Display total xp
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = Gamemanager.instance.GetXpToLevel(currLvl - 1);
            int currLevelXp = Gamemanager.instance.GetXpToLevel(currLvl);

            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = Gamemanager.instance.experience - prevLevelXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + " / " + diff;
        }

        //xpText.text = "TODO";
        //xpBar.localScale = new Vector3(0.5f, 0, 0);
    }
}
