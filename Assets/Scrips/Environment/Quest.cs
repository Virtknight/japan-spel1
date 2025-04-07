using UnityEngine;

[CreateAssetMenu(fileName = "Create new Quest", menuName = "Quests/")]
public class Quest : ScriptableObject
{
    public enum Questtype
    {
        find,
        gather,
        explore
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public int RequiredAmount { get; protected set; }
    public bool finished {get; protected set;}
    public Questtype type;
    


}



