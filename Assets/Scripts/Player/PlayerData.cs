using System;

[Serializable]
public class PlayerData
{
    public int points;
    public string hat;
    public string head;
    public string body;

    public PlayerData(Player player)
    {
        points = player.Points;
        hat = player.Hat.part.name;
        head = player.Head.part.name;
        body = player.Body.part.name;
    }
}
