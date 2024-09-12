using System;


[Serializable]
public class Player
{
    public int userid;
    public int coin;
    public int lifes;
    public int additionallifes;
    public string lifetimer;
    public string nickname;
    public string image;

    public Player(int userid, int coin = 0, int lifes = 3, int additionallifes = 0, string lifetimer = default, string nickname = "", string image = "")
    {
        this.userid = userid;
        this.coin = coin;
        this.lifes = lifes;
        this.additionallifes = additionallifes;
        this.lifetimer = lifetimer;
        this.nickname = nickname;
        this.image = image;
    }
}
