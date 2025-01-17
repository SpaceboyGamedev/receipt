using UnityEngine;

/// <summary>
/// Represents an item that can be added to the cart for receipt calculation.
/// </summary>
[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
	[Tooltip("Name of the item.")]
	public string Name;

	[Tooltip("Base price of the item (without tax).")]
	public float Price;

	[Tooltip("Indicates if the item is exempt from basic sales tax (e.g., books, food, or medical supplies).")]
	public bool IsBookFoodMedicalsupply;

	[Tooltip("Indicates if the item is an imported good (subject to import duty).")]
	public bool IsImported;

#if UNITY_EDITOR
	/// <summary>
	/// Ensures the item's name in the inspector matches its asset name for better organization.
	/// This method is only executed in the Unity Editor.
	/// </summary>
	private void OnValidate()
	{
		Name = name;
	}
#endif
}
