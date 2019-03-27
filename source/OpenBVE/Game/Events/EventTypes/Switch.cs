namespace OpenBve
{
	internal static partial class TrackManager
	{
		/// <summary>Holds the data for a single switch</summary>
		internal class Switch
		{
			/// <summary>The currently set track</summary>
			public int currentlySetTrack()
			{
				return availableTracks[setTrack];
			}

			private int setTrack;

			public readonly int[] availableTracks;

			public Switch(int[] tracks, int initialTrack)
			{
				availableTracks = tracks;
				for (int i = 0; i < availableTracks.Length; i++)
				{
					if (availableTracks[i] == initialTrack)
					{
						setTrack = i;
					}
				}
			}
		}

		/// <summary>The switches within the game</summary>
		internal static Switch[] Switches;

		internal class SwitchEvent : GeneralEvent
		{

			private readonly int myIndex;

			private readonly int triggerDirection;

			public SwitchEvent(int idx, int direction)
			{
				myIndex = idx;
				triggerDirection = direction;
			}

			internal override void Trigger(int Direction, EventTriggerType TriggerType, TrainManager.Train Train, int CarIndex)
			{
				if (Direction != triggerDirection)
				{
					//Check traversal direction
					return;
				}

				switch (TriggerType)
				{
					case EventTriggerType.FrontCarFrontAxle:
					case EventTriggerType.OtherCarFrontAxle:
						Train.Cars[CarIndex].FrontAxle.Follower.TrackIndex = Switches[myIndex].currentlySetTrack();
						Train.Cars[CarIndex].FrontAxle.Follower.UpdateWorldCoordinates(false);
						break;
					case EventTriggerType.RearCarRearAxle:
					case EventTriggerType.OtherCarRearAxle:
						Train.Cars[CarIndex].RearAxle.Follower.TrackIndex = Switches[myIndex].currentlySetTrack();
						Train.Cars[CarIndex].RearAxle.Follower.UpdateWorldCoordinates(false);
						break;
				}
			}
		}

		internal class TrailingSwitchEvent : GeneralEvent
		{

			private readonly int myIndex;

			private readonly int toeRail;

			private readonly int triggerDirection;

			public TrailingSwitchEvent(int idx, int trackIndex, int direction)
			{
				myIndex = idx;
				toeRail = trackIndex;
				triggerDirection = direction;
			}

			internal override void Trigger(int Direction, EventTriggerType TriggerType, TrainManager.Train Train, int CarIndex)
			{
				if (Direction != triggerDirection)
				{
					//Check traversal direction
					return;
				}

				switch (TriggerType)
				{
					case EventTriggerType.FrontCarFrontAxle:
					case EventTriggerType.OtherCarFrontAxle:
						if (Interface.CurrentOptions.Derailments == false || Switches[myIndex].currentlySetTrack() == Train.Cars[CarIndex].FrontAxle.Follower.TrackIndex)
						{
							Train.Cars[CarIndex].FrontAxle.Follower.TrackIndex = toeRail;
							Train.Cars[CarIndex].FrontAxle.Follower.UpdateWorldCoordinates(false);
						}
						else
						{
							Train.Derail(CarIndex, 0);
						}
						break;
					case EventTriggerType.RearCarRearAxle:
					case EventTriggerType.OtherCarRearAxle:
						if (Interface.CurrentOptions.Derailments == false || Switches[myIndex].currentlySetTrack() == Train.Cars[CarIndex].RearAxle.Follower.TrackIndex)
						{
							Train.Cars[CarIndex].RearAxle.Follower.TrackIndex = toeRail;
							Train.Cars[CarIndex].RearAxle.Follower.UpdateWorldCoordinates(false);
						}
						else
						{
							Train.Derail(CarIndex, 0);
						}
						break;
				}
			}
		}
	}
}
