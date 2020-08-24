using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public static class Mission 
{
    public static Dictionary<string, int> GetMissionItems(Scene currScene)
    {
        Dictionary<string, int> missionItems = new Dictionary<string, int>();
        switch (currScene.name) {
            case "Level01":
                missionItems.Add("RedBlock", 0);
                return missionItems;
            case "Level02":
                missionItems.Add("RedBlock", 0);
                missionItems.Add("BlueBlock", 0);
                return missionItems;
            case "Level03":
                missionItems.Add("RedBlock", 0);
                missionItems.Add("BlueBlock", 0);
                return missionItems;
            case "Level04":
                missionItems.Add("RedBlock", 0);
                missionItems.Add("BlueBlock", 0);
                return missionItems;
            case "Level05":
                missionItems.Add("IceBlock", 0);
                return missionItems;
            case "Level06":
                missionItems.Add("BlueBlock", 0);
                return missionItems;
            case "Level07":
                missionItems.Add("RedBlock", 1);
                return missionItems;
            case "Level08":
                missionItems.Add("IceBlock", 0);
                return missionItems;
        }

        return null;
    }
}