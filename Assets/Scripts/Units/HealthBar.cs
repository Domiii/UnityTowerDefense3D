using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @see https://unity3d.com/learn/tutorials/projects/tanks-tutorial/tank-health
/// </summary>
public class HealthBar : MonoBehaviour
{
	public Unit unit;
	public Slider m_Slider;                             // The slider to represent how much health the tank currently has.
	public Image m_FillImage;                           // The image component of the slider.
	public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
	public Color m_ZeroHealthColor = Color.red;         // The color the health bar will be when on no health.


	void Awake() {
	}

	void Update() {
		var health = unit.Health;
		var maxHealth = unit.MaxHealth;

		// Set the slider's values appropriately.
		m_Slider.maxValue = unit.MaxHealth;
		m_Slider.value = health;

		// Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
		m_FillImage.color = Color.Lerp (m_ZeroHealthColor, m_FullHealthColor, health / maxHealth);
	}
}