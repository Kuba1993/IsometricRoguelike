using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    private void Awake()
    {
        if(Gamemanager.instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
    }

    //Resources
    public List<int> xpTable;

    //References
    public Player player;
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;

    //Logic
    public int gold;
    public int experience;

    //Floating Text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    /*
     INT character
     INT gold
     INT experience
     INT weaponLevel
    */

    //Experience system
    public int GetCurrentLevel()
    {
        int r = 0;
        int add = 0;

        while(experience >= add)
        {
            add += xpTable[r];
            r++;

            //Max level
            if (r == xpTable.Count)
                return r;
        }

        return r;
    }
    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;
        while (r < level)
        {
            xp += xpTable[r];
            r++;
        }

        return xp;
    }

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s+= gold.ToString() + "|";
        s+= experience.ToString() + "|";

        PlayerPrefs.SetString("SaveState", s);


        Debug.Log("saveState");

    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // apply new values
        gold = int.Parse(data[1]);
        experience = int.Parse(data[2]);

        Debug.Log("loadState with " + gold + " gold");
    }

    public void portPlayer(Vector3 position)
    {
        player.PortMover(position);
    }
}
