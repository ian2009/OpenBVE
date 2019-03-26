namespace OpenBve
{
	internal static partial class TrackManager
	{
		internal class SwitchEvent : GeneralEvent
		{
			/// <summary>The currently set track</summary>
			public int currentSetTrack()
			{
				return availableTracks[trackIndex];
			}

			public readonly int[] availableTracks;

			private int trackIndex;

			public SwitchEvent(int[] tracks, int initialTrack)
			{
				availableTracks = tracks;
				for (int i = 0; i < availableTracks.Length; i++)
				{
					if (availableTracks[i] == initialTrack)
					{
						trackIndex = i;
					}
				}
			}

			internal override void Trigger(int Direction, EventTriggerType TriggerType, TrainManager.Train Train, int CarIndex)
			{
				switch (TriggerType)
				{
					case EventTriggerType.FrontCarFrontAxle:
					case EventTriggerType.OtherCarFrontAxle:
						Train.Cars[CarIndex].FrontAxle.Follower.TrackIndex = currentSetTrack();
						Train.Cars[CarIndex].FrontAxle.Follower.UpdateWorldCoordinates(false);
						break;
					case EventTriggerType.RearCarRearAxle:
					case EventTriggerType.OtherCarRearAxle:
						Train.Cars[CarIndex].RearAxle.Follower.TrackIndex = currentSetTrack();
						Train.Cars[CarIndex].RearAxle.Follower.UpdateWorldCoordinates(false);
						break;
				}
			}
		}
	}
}
