using System;

using UnityEngine;

public class ProgressSystem : MonoBehaviour
{
    [field: SerializeField] private SaveLoad SaveLoad { get; set; }
    [field: SerializeField] private WebRequester WebRequester { get; set; }

    private void Start()
    {
        SaveLoad.OnLoad += Load;
        SaveLoad.OnSave += Save;
    }

    private void OnDestroy()
    {
        SaveLoad.OnLoad -= Load;
        SaveLoad.OnSave -= Save;
    }

    public void Load()
    {
        if (PlayerPrefs.GetInt("PlayerExist") == 1)
        {
            StartCoroutine(WebRequester.GetData(WebRequestSettings.REQUEST_LOAD_URL + DataHolder.PlayerData.player.userid));
        }
        else
        {
            WWWForm form = new();
            form.AddField("userid", DataHolder.PlayerData.player.userid);
            form.AddField("nickname", DataHolder.PlayerData.player.nickname);
            form.AddField("image", DataHolder.PlayerData.player.image);
            StartCoroutine(WebRequester.CreateNewPlayer(WebRequestSettings.REQUEST_NEW_PLAYER_URL, form));

            if (!string.IsNullOrEmpty(DataHolder.TelegramWebAppUser.joinedBy)
                && DataHolder.PlayerData.player.userid != Convert.ToInt32(DataHolder.TelegramWebAppUser.joinedBy))
            {
                WWWForm rewardform = new();
                int userid = Convert.ToInt32(DataHolder.TelegramWebAppUser.joinedBy);
                rewardform.AddField("userid", userid);
                rewardform.AddField("lifes", LifesSettings.DEFAULT_LIFES);
                rewardform.AddField("additionallifes", LifesSettings.REWARD_LIFES);
                StartCoroutine(WebRequester.SendRewardForInvite(WebRequestSettings.REQUEST_INVITE_REWARD_URL, rewardform));
            }

            PlayerPrefs.SetInt("PlayerExist", 1);
        }
        PlayerPrefs.Save();
    }

    public void Save()
    {
        WWWForm form = new();
        form.AddField("userid", DataHolder.PlayerData.player.userid);
        form.AddField("coin", DataHolder.PlayerData.player.coin);
        form.AddField("lifes", DataHolder.PlayerData.player.lifes);
        form.AddField("additionallifes", DataHolder.PlayerData.player.additionallifes);
        form.AddField("lifetimer", DataHolder.PlayerData.player.lifetimer ?? "");
        form.AddField("nickname", DataHolder.PlayerData.player.nickname);
        form.AddField("image", DataHolder.PlayerData.player.image);
        StartCoroutine(WebRequester.SendData(WebRequestSettings.REQUEST_SAVE_URL, form));
    }
}
