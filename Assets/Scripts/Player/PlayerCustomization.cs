using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    public PartType partType;
    public BodyPart part;

    private void Start()
    {
        GetPlayerPart();
        UpdatePlayerView();
    }

    public void SetPart(BodyPart part)
    {
        this.part = part;
        UpdatePlayerView();
    }

    // changes the player model
    private void UpdatePlayerView()
    {
        Destroy(transform.GetChild(0).gameObject);
        Instantiate(part.part, transform);
    }

    public void UpdatePlayerPart()
    {
        if (!part.owned)
        {
            return;
        }

        Player player = Player.Instance;

        switch (partType)
        {
            case PartType.Hat:
                player.Hat = part;
                break;

            case PartType.Head:
                player.Head = part;
                break;

            case PartType.Body:
                player.Body = part;
                break;

            default:
                print("Unknown part type");
                break;
        }
    }

    public void GetPlayerPart()
    {
        Player player = Player.Instance;

        switch (partType)
        {
            case PartType.Hat:
                part = player.Hat;
                break;

            case PartType.Head:
                part = player.Head;
                break;

            case PartType.Body:
                part = player.Body;
                break;

            default:
                print("Unknown part type");
                break;
        }
    }
}
