using UnityEngine;
using System.Collections;

public class TextureTiling : MonoBehaviour {
public int PanelNum = 4;
public float MoveVector = 1;
public bool Horizontal = true;
public bool Vertical = false;

	void OnTriggerEnter2D(Collider2D collider)
	{
		float WidthOfPanel;
		Vector3 pos = collider.transform.position;
		if (Horizontal) {
			WidthOfPanel = ((BoxCollider2D)collider).size.x;
			pos.x = pos.x + (WidthOfPanel * PanelNum + WidthOfPanel / 2) * MoveVector;
		}
		if (Vertical) {
			WidthOfPanel = ((BoxCollider2D)collider).size.y;
			pos.y = pos.y + (WidthOfPanel * PanelNum + WidthOfPanel / 2) * MoveVector;
		}
		collider.transform.position = pos;
		
	}
}
