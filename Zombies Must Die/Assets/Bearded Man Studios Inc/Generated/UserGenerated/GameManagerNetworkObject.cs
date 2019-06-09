using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0]")]
	public partial class GameManagerNetworkObject : NetworkObject
	{
		public const int IDENTITY = 3;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private uint _playerId;
		public event FieldEvent<uint> playerIdChanged;
		public Interpolated<uint> playerIdInterpolation = new Interpolated<uint>() { LerpT = 0f, Enabled = false };
		public uint playerId
		{
			get { return _playerId; }
			set
			{
				// Don't do anything if the value is the same
				if (_playerId == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_playerId = value;
				hasDirtyFields = true;
			}
		}

		public void SetplayerIdDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_playerId(ulong timestep)
		{
			if (playerIdChanged != null) playerIdChanged(_playerId, timestep);
			if (fieldAltered != null) fieldAltered("playerId", _playerId, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			playerIdInterpolation.current = playerIdInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _playerId);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_playerId = UnityObjectMapper.Instance.Map<uint>(payload);
			playerIdInterpolation.current = _playerId;
			playerIdInterpolation.target = _playerId;
			RunChange_playerId(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _playerId);

			// Reset all the dirty fields
			for (int i = 0; i < _dirtyFields.Length; i++)
				_dirtyFields[i] = 0;

			return dirtyFieldsData;
		}

		protected override void ReadDirtyFields(BMSByte data, ulong timestep)
		{
			if (readDirtyFlags == null)
				Initialize();

			Buffer.BlockCopy(data.byteArr, data.StartIndex(), readDirtyFlags, 0, readDirtyFlags.Length);
			data.MoveStartIndex(readDirtyFlags.Length);

			if ((0x1 & readDirtyFlags[0]) != 0)
			{
				if (playerIdInterpolation.Enabled)
				{
					playerIdInterpolation.target = UnityObjectMapper.Instance.Map<uint>(data);
					playerIdInterpolation.Timestep = timestep;
				}
				else
				{
					_playerId = UnityObjectMapper.Instance.Map<uint>(data);
					RunChange_playerId(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (playerIdInterpolation.Enabled && !playerIdInterpolation.current.UnityNear(playerIdInterpolation.target, 0.0015f))
			{
				_playerId = (uint)playerIdInterpolation.Interpolate();
				//RunChange_playerId(playerIdInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public GameManagerNetworkObject() : base() { Initialize(); }
		public GameManagerNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public GameManagerNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
