using System;

[Serializable]
public class Player 
{
    public string username;
    public string password;
    public string email;
    public uint score;
    public string levelEnglish;
    public Player(){}

    public Player(string username, string password, string email, uint score, string levelEnglish)
    {
        this.username = username;
        this.password = password;
        this.email = email;
        this.score = score;
        this.levelEnglish = levelEnglish;
    }
    
}
