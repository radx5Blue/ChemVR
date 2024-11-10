using UnityEngine;
using System.Collections;

/// <summary>
/// Shows the spill point on the glass when it's rotated.
/// </summary>
namespace LiquidVolumeFX
{
	public class SpillController1 : MonoBehaviour
	{

		public GameObject spill;

		//public GameObject part;

		LiquidVolume lv;
		GameObject[] dropTemplates;
		const int DROP_TEMPLATES_COUNT = 1;
			
		void Start ()
		{
			lv = GetComponent<LiquidVolume> ();

			dropTemplates = new GameObject[DROP_TEMPLATES_COUNT];
			for (int k = 0; k < DROP_TEMPLATES_COUNT; k++) {
				GameObject oneSpill = Instantiate (spill) as GameObject;
				oneSpill.transform.localScale *= Random.Range (0.45f, 0.65f);
				oneSpill.GetComponent<Renderer> ().material.color = Color.Lerp (lv.liquidColor1, lv.liquidColor1, Random.value);
				oneSpill.SetActive (false);
				dropTemplates [k] = oneSpill;
			}
		}

		void Update ()
		{
			//const float rotationSpeed = 10f;
			//if (Input.GetKey (KeyCode.LeftArrow)) {
			//	transform.Rotate (Vector3.forward * Time.deltaTime * rotationSpeed);
			//}
			//if (Input.GetKey (KeyCode.RightArrow)) {
				//transform.Rotate (-Vector3.forward * Time.deltaTime * rotationSpeed);
			//}
		}


		void FixedUpdate ()
		{
												
			Vector3 spillPos;
			float spillAmount;
			if (lv.GetSpillPoint (out spillPos, out spillAmount)) {
				const int drops = 1;
				for (int k = 0; k < drops; k++) {
				int template = Random.Range (0, DROP_TEMPLATES_COUNT);
				GameObject oneSpill = Instantiate (dropTemplates[template]) as GameObject;
				oneSpill.SetActive (true);
				//Rigidbody rb = oneSpill.GetComponent<Rigidbody> ();
				//rb.position = spillPos + Random.insideUnitSphere * 0.01f;
				//rb.AddForce(new Vector3 (Random.value - 0.5f, Random.value * 0.1f - 0.2f, Random.value - 0.5f));
				oneSpill.transform.position = spillPos;
				StartCoroutine (DestroySpill (oneSpill));

				//part.SetActive(true);
				



				}
				lv.level -= spillAmount / 10f + 0.01f;
			}
		}


		IEnumerator DestroySpill (GameObject spill)
		{
			yield return new WaitForSeconds (.2f);
			Destroy(spill);
		}
	}
}
