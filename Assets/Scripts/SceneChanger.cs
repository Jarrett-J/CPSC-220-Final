using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private List<GameObject> playerParts;
    [SerializeField] private GameObject errorMessage;

    private void Start()
    {
        if (errorMessage != null)
        {
            errorMessage.SetActive(false);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void CheckAndChange()
    {
        if (PlayerPartsOwned())
        {
            ChangeScene();
        }
        else
        {
            StartCoroutine(DisplayError());
        } 
    }

    // check if selected dropdown items are owned
    // if they are, then player can exit the scene
    // if not, then display error message

    private bool PlayerPartsOwned()
    {
        List<BodyPart> parts = new List<BodyPart>();

        foreach(GameObject playerPart in playerParts)
        {
            parts.Add(playerPart.GetComponent<PlayerCustomization>().part);
        }

        foreach(BodyPart part in parts)
        {
            if (part == null)
            {
                continue;
            }

            if (!part.owned)
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator DisplayError()
    {
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(3f);
        errorMessage.SetActive(false);
    }
}
