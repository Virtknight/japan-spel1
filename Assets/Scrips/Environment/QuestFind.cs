using UnityEngine;
[CreateAssetMenu(fileName = "Create new find quest", menuName = "Quests/Find-quest")]
public class Questfind : Quest
{
    [Header("Find specific")]
    public GameObject item;
    public bool Completed {get; protected set;}
    public GameObject questmanager;

    public void Check()
    {
        if (item.GetComponent<Item>().HasBeenPickedUp == true)
        {
            Completed = true;
            questmanager.GetComponent<QuestManager>().CheckForRemoval();

        }
    }
}