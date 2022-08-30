using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class VRHealth : Panel
{
	public Label Label;

	public VRHealth()
	{
		Label = Add.Label( "100", "value" );
	}

	public override void Tick()
	{
		var player = Local.Pawn;
		if ( player == null ) return;

		Label.Text = $"{player.Health.CeilToInt()}";
	}
}
