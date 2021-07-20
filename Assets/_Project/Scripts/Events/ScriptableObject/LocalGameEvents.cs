using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewLocalGameEvents",  menuName = "Events/Local Game Events")]
public sealed class LocalGameEvents : ScriptableObject
{
    public UnityAction<int, int> OnHealthChanged;

    public UnityAction<int, int> OnPowerChanged;

    public UnityAction OnPlayerShotBomb;

    public UnityAction OnLaserCollide;

    public delegate void DelegateOnReadPlayerInputs(PlayerInputData playerInputData);
    public DelegateOnReadPlayerInputs OnReadPlayerInputs;

    public delegate void DelegateOnAmmoChanged(int currentProjectileAmount);
    public DelegateOnAmmoChanged OnAmmoChanged;
}
