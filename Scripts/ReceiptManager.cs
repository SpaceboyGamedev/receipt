using System;
using System.Collections.Generic;
using UnityEngine;

public class ReceiptManager : MonoBehaviour
{
	[SerializeField] private List<Item> cartItems = new List<Item>();
	private const float salesTaxRate = 0.1f;
	private const float importDutyRate = 0.05f;

	#region MonoBehaviours
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.P))
		{
			PrintReceipt();
		}
	}
	#endregion

	private void PrintReceipt()
	{
		float totalItemPrice = 0;
		float totalSalesTax = 0;
		foreach (Item item in cartItems)
		{
			totalItemPrice += item.Price;

			float salesTax = 0;
			if (!item.IsBookFoodMedicalsupply) { salesTax += item.Price * salesTaxRate; }
			if (item.IsImported) { salesTax += item.Price * importDutyRate; }

			totalSalesTax += (float)RoundUp20th(salesTax);

		}

		print($"salesTax=${totalSalesTax} && total=${totalItemPrice + totalSalesTax}");
	}

	private double RoundUp20th(float tax)
	{
		return Math.Ceiling((double)tax * 20) / 20.0;
	}
}
