using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // on load, delete whatever is currently equipped
    // replace it with the bodypart variable

    public PartType partType;   // assign in inspector
    public BodyPart part;

    private void Start()
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

        try
        {
            GameObject startPart = transform.GetChild(0).gameObject;

            if (startPart != null
                && part != null
                && startPart.name != part.name)
            {
                Destroy(startPart);
                Instantiate(part.part, transform);
            }
        }
        catch
        {
            print("startPart null");
        }
        
    }

}

public enum PartType
{
    Hat,
    Head,
    Body
}
