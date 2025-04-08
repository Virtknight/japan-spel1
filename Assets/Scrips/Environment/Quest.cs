using UnityEngine;

[CreateAssetMenu(fileName = "Create new Quest", menuName = "Quests/")]
public class Quest : ScriptableObject
{
    public enum Questtype
    {
        find,
        explore
    }
[Header("Default values")]
   [SerializeField] private string Name;
    [SerializeField] private string Description;
    [SerializeField] private int RequiredAmount;
    public bool finished {get; protected set;}
    [SerializeField] private Questtype type;
    


}



