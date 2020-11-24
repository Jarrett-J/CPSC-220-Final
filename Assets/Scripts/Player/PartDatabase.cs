using System.Collections.Generic;
using UnityEngine;

public class PartDatabase : Singleton<PartDatabase>
{
    [SerializeField] private List<BodyPart> hats;
    [SerializeField] private List<BodyPart> heads;
    [SerializeField] private List<BodyPart> bodies;

    public BodyPart FindHat(string id)
    {
        foreach (BodyPart hat in hats)
        {
            if (hat.part.name == id)
            {
                return hat;
            }
        }
        print("Hat not found: id is " + id);
        return null;
    }

    public BodyPart FindHead(string id)
    {
        foreach (BodyPart head in heads)
        {
            if (head.part.name == id)
            {
                return head;
            }
        }
        print("Head not found: id is " + id);
        return null;
    }

    public BodyPart FindBody(string id)
    {
        foreach (BodyPart body in bodies)
        {
            if (body.part.name == id)
            {
                return body;
            }
        }
        print("Body not found: id is " + id);
        return null;
    }
}
