using UnityEngine;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    [SerializeField] public Queue<Quest> queue;
    [SerializeField] private List<Quest> QuestsInOrder;

    // Update is called once per frame
    void Start()
    {
        AddQuestList();
    }

    private void AddQuestList()
    {
        foreach (Quest quest in QuestsInOrder)
        {
            queue.Enqueue(quest);
        }
    }

    public void RemoveFromList()
    {
        queue.Dequeue();
    }

    public void ChangeDisplayed()
    {

    }
    public void CheckForRemoval()
    {
        if (queue.Peek() != null)
        {
            Quest first = queue.Peek();
            if(first.finished == true){
                RemoveFromList();
            }
        }



    }
}
