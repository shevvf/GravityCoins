
using UnityEngine;

public class ProgressEntryPoint : MonoBehaviour
{
    [field: SerializeField] private SaveLoad SaveLoad { get; set; }
    [field: SerializeField] private bool GenerateRandomPlayer { get; set; }

    private void Start()
    {
        if (Application.isEditor)
        {
            DataHolder.TelegramWebAppUser.joinedBy = "1";

            if (GenerateRandomPlayer)
            {
                PlayerPrefs.SetInt("PlayerExist", 0);
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

                char[] nickname = new char[Random.Range(5, 15)];
                for (int i = 0; i < nickname.Length; i++)
                {
                    nickname[i] = chars[Random.Range(0, chars.Length)];
                }
                string nicknameString = new(nickname);

                char[] imageUrl = new char[Random.Range(25, 50)];
                for (int i = 0; i < imageUrl.Length; i++)
                {
                    imageUrl[i] = chars[Random.Range(0, chars.Length)];
                }
                string imageUrlString = new(imageUrl);

                DataHolder.PlayerData.player = new Player(Random.Range(0, 999999), Random.Range(0, 999999), 3, 0, null,
                                                          nicknameString, imageUrlString);
            }
            else
            {
                PlayerPrefs.SetInt("PlayerExist", 1);
                DataHolder.PlayerData.player = new Player(1, 100, 3, 0, null, "TEST_USER", "TEST_USER_IMAGE_URL");
            }
        }
        SaveLoad.Load();
    }

    public void SetWebAppUser(string UserDataJson)
    {
        DataHolder.TelegramWebAppUser = DataExtensions.SetData<TelegramWebAppUser>(UserDataJson);

        DataHolder.PlayerData.player = new(DataHolder.TelegramWebAppUser.id, 0, 3, 0, null,
            DataHolder.TelegramWebAppUser.username, DataHolder.TelegramWebAppUser.photoUrl);

        Debug.Log("Received Telegram Data:");
        Debug.Log("User ID: " + DataHolder.TelegramWebAppUser.id);
        Debug.Log("First Name: " + DataHolder.TelegramWebAppUser.firstName);
        Debug.Log("Last Name: " + DataHolder.TelegramWebAppUser.lastName);
        Debug.Log("Username: " + DataHolder.TelegramWebAppUser.username);
        Debug.Log("Language Code: " + DataHolder.TelegramWebAppUser.languageCode);
        Debug.Log("Photo URL: " + DataHolder.TelegramWebAppUser.photoUrl);
        Debug.Log("Is Premium: " + DataHolder.TelegramWebAppUser.isPremium);
        Debug.Log("Joined By: " + DataHolder.TelegramWebAppUser.joinedBy);
    }
}
