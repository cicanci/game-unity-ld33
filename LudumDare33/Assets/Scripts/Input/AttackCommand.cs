using UnityEngine;

public class AttackCommand : Command
{
    public void Execute(GameObject obj)
    {
        obj.GetComponent<Character>().Attack();
    }
}
