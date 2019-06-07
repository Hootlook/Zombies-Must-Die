using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0]")]
	public partial class EntityNetworkObject : NetworkObject
	{
		public const int IDENTITY = 2;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private bool _isUsed;
		public event FieldEvent<bool> isUsedChanged;
		public Interpolated<bool> isUsedInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool isUsed
		{
			get { return _isUsed; }
			set
			{
				// Don't do anything if the value is the same
				if (_isUsed == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_isUsed = value;
				hasDirtyFields = true;
			}
		}

		public void SetisUsedDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_isUsed(ulong timestep)
		{
			if (isUsedChanged != null) isUsedChanged(_isUsed, timestep);
			if (fieldAltered != null) fieldAltered("isUsed", _isUsed, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			isUsedInterpolation.current = isUsedInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _isUsed);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_isUsed = UnityObjectMapper.Instance.Map<bool>(payload);
			isUsedInterpolation.current = _isUsed;
			isUsedInterpolation.target = _isUsed;
			RunChange_isUsed(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _isUsed);

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
				if (isUsedInterpolation.Enabled)
				{
					isUsedInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					isUsedInterpolation.Timestep = timestep;
				}
				else
				{
					_isUsed = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_isUsed(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (isUsedInterpolation.Enabled && !isUsedInterpolation.current.UnityNear(isUsedInterpolation.target, 0.0015f))
			{
				_isUsed = (bool)isUsedInterpolation.Interpolate();
				//RunChange_isUsed(isUsedInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public EntityNetworkObject() : base() { Initialize(); }
		public EntityNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public EntityNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
