using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the calculation and printing of receipts, including sales taxes and total costs.
/// </summary>
public class ReceiptManager : MonoBehaviour
{
	[Header("Cart Items")]
	[Tooltip("List of items in the shopping cart.")]
	[SerializeField] private List<Item> cartItems = new List<Item>();

	// Constants for tax rates
	private const float salesTaxRate = 0.1f;  // 10% sales tax rate
	private const float importDutyRate = 0.05f; // 5% import duty rate

	#region MonoBehaviour Methods
	/// <summary>
	/// Checks for the 'P' key to print the receipt during runtime.
	/// </summary>
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.P))
		{
			PrintReceipt();
		}
	}
	#endregion

	/// <summary>
	/// Calculates and prints the receipt, including item details, sales taxes, and total cost.
	/// </summary>
	private void PrintReceipt()
	{
		float totalItemPrice = 0; // Total price of items (before taxes)
		float totalSalesTax = 0; // Total sales tax accumulated

		foreach (Item item in cartItems)
		{
			totalItemPrice += item.Price;

			float salesTax = 0;

			// Add basic sales tax if the item is not exempt
			if (!item.IsBookFoodMedicalsupply)
			{
				salesTax += item.Price * salesTaxRate;
			}

			// Add import duty if the item is imported
			if (item.IsImported)
			{
				salesTax += item.Price * importDutyRate;
			}

			// Round the calculated tax and accumulate it
			totalSalesTax += (float)RoundUp20th(salesTax);
		}

		// Print the receipt details
		Debug.Log($"Sales Taxes: {totalSalesTax:F2} | Total: {totalItemPrice + totalSalesTax:F2}");
	}

	/// <summary>
	/// Rounds up a value to the nearest 0.05 (20th of a unit).
	/// </summary>
	/// <param name="tax">The tax value to round up.</param>
	/// <returns>The tax value rounded up to the nearest 0.05.</returns>
	private double RoundUp20th(float tax)
	{
		return Math.Ceiling((double)tax * 20) / 20.0;
	}
}
