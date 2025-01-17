using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public float Price;
	public bool IsBookFoodMedicalsupply;
	public bool IsImported;

#if UNITY_EDITOR
	private void OnValidate()
	{
		Name = name;
	}
#endif
}
