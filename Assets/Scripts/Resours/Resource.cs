using UnityEngine;

[CreateAssetMenu(fileName = "Resourse",menuName = "ScriptableObject/Resours")]
public class Resource : ScriptableObject
{
    [SerializeField] private Sprite _icon;

    public Sprite GetIcon()
    {
        return Sprite.Create(_icon.texture, _icon.rect, _icon.pivot, _icon.pixelsPerUnit);
    }
}
