using System;

[Serializable]
public class TelegramWebAppUser
{
    public int id;
    public string firstName;
    public string lastName;
    public string username;
    public string languageCode;
    public string photoUrl;
    public bool isPremium;
    public string joinedBy;
}
