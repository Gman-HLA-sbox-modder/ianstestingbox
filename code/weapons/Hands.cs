using Sandbox;

[Library( "weapon_hands", Title = "Hands")]
partial class Hands : Weapon
{
	public override string ViewModelPath => "";

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "" );
	}

	public override void SimulateAnimator( CitizenAnimationHelper anim )
	{
		anim.HoldType = CitizenAnimationHelper.HoldTypes.None;
		anim.Handedness = CitizenAnimationHelper.Hand.Both;
		anim.AimBodyWeight = 1.0f;
	}
	public override void OnCarryDrop( Entity dropper )
	{
	}
}
