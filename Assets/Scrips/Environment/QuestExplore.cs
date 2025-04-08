using UnityEngine;

[CreateAssetMenu(fileName = "Create new explore quest", menuName = "Quests/Explore-quest")]
public class QuestExplore : Quest
{
    [Header("Explore-specific")]
    public GameObject questmanager;
    public Transform player;
    public Transform goal;
    public float distance;


    public void close()
    {
        if (Vector3.Distance(player.position, goal.position) < distance)
        {
            finished = true;
            questmanager.GetComponent<QuestManager>().CheckForRemoval();
        }
    }
}