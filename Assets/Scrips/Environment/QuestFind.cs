using UnityEngine;
[CreateAssetMenu(fileName = "Create new find quest", menuName = "Quests/Find-quest")]
public class Questfind : Quest
{
    public Item item;
    public bool Completed;
    void Check()
    {
        if (item.HasBeenPickedUp == true)
        {

        }
    }
}