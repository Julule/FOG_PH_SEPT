using UnityEngine;

[CreateAssetMenu(fileName = "ActorSO" , menuName = "Dialogue/NPC")] // nouvelle option de menu Create > Dialogue > NPC qui créé un scriptable object ActorSO

public class ActorSO : ScriptableObject
{
    [SerializeField] public string actorName;
    [SerializeField] public Sprite portrait;
}
