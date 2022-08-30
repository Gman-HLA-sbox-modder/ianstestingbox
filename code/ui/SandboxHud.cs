using Sandbox;
using Sandbox.UI;
using VrExample;

[Library]
public partial class SandboxHud : HudEntity<RootPanel>
{
	public SandboxHud()
	{
		if ( IsClient )
		{
			if ( Global.IsRunningInVR )
			{
				// Use a world panel - we're in VR
				_ = new VrExample.HealthHudEntity();
				_ = new VrExample.VRInventoryHud();
			}
			else
			{
				// Just display the HUD on-screen
				RootPanel.StyleSheet.Load( "/ui/SandboxHud.scss" );

				RootPanel.AddChild<ChatBox>();
				RootPanel.AddChild<VoiceList>();
				RootPanel.AddChild<VoiceSpeaker>();
				RootPanel.AddChild<KillFeed>();
				RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
				RootPanel.AddChild<Health>();
				RootPanel.AddChild<InventoryBar>();
				RootPanel.AddChild<CurrentTool>();
				RootPanel.AddChild<SpawnMenu>();
				RootPanel.AddChild<Crosshair>();
			}
		}
	}
}
