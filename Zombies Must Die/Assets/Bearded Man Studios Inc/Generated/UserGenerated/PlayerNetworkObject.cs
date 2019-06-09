using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0.2,0.2,0.2,0.2,0.2,0.2,0,0,0,0,0,0,0,0]")]
	public partial class PlayerNetworkObject : NetworkObject
	{
		public const int IDENTITY = 6;

		private byte[] _dirtyFields = new byte[2];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private Vector3 _position;
		public event FieldEvent<Vector3> positionChanged;
		public InterpolateVector3 positionInterpolation = new InterpolateVector3() { LerpT = 0.2f, Enabled = true };
		public Vector3 position
		{
			get { return _position; }
			set
			{
				// Don't do anything if the value is the same
				if (_position == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_position = value;
				hasDirtyFields = true;
			}
		}

		public void SetpositionDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_position(ulong timestep)
		{
			if (positionChanged != null) positionChanged(_position, timestep);
			if (fieldAltered != null) fieldAltered("position", _position, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _rotation;
		public event FieldEvent<Quaternion> rotationChanged;
		public InterpolateQuaternion rotationInterpolation = new InterpolateQuaternion() { LerpT = 0.2f, Enabled = true };
		public Quaternion rotation
		{
			get { return _rotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_rotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x2;
				_rotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetrotationDirty()
		{
			_dirtyFields[0] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_rotation(ulong timestep)
		{
			if (rotationChanged != null) rotationChanged(_rotation, timestep);
			if (fieldAltered != null) fieldAltered("rotation", _rotation, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _spine;
		public event FieldEvent<Quaternion> spineChanged;
		public InterpolateQuaternion spineInterpolation = new InterpolateQuaternion() { LerpT = 0.2f, Enabled = true };
		public Quaternion spine
		{
			get { return _spine; }
			set
			{
				// Don't do anything if the value is the same
				if (_spine == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x4;
				_spine = value;
				hasDirtyFields = true;
			}
		}

		public void SetspineDirty()
		{
			_dirtyFields[0] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_spine(ulong timestep)
		{
			if (spineChanged != null) spineChanged(_spine, timestep);
			if (fieldAltered != null) fieldAltered("spine", _spine, timestep);
		}
		[ForgeGeneratedField]
		private float _horizontal;
		public event FieldEvent<float> horizontalChanged;
		public InterpolateFloat horizontalInterpolation = new InterpolateFloat() { LerpT = 0.2f, Enabled = true };
		public float horizontal
		{
			get { return _horizontal; }
			set
			{
				// Don't do anything if the value is the same
				if (_horizontal == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x8;
				_horizontal = value;
				hasDirtyFields = true;
			}
		}

		public void SethorizontalDirty()
		{
			_dirtyFields[0] |= 0x8;
			hasDirtyFields = true;
		}

		private void RunChange_horizontal(ulong timestep)
		{
			if (horizontalChanged != null) horizontalChanged(_horizontal, timestep);
			if (fieldAltered != null) fieldAltered("horizontal", _horizontal, timestep);
		}
		[ForgeGeneratedField]
		private float _vertical;
		public event FieldEvent<float> verticalChanged;
		public InterpolateFloat verticalInterpolation = new InterpolateFloat() { LerpT = 0.2f, Enabled = true };
		public float vertical
		{
			get { return _vertical; }
			set
			{
				// Don't do anything if the value is the same
				if (_vertical == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x10;
				_vertical = value;
				hasDirtyFields = true;
			}
		}

		public void SetverticalDirty()
		{
			_dirtyFields[0] |= 0x10;
			hasDirtyFields = true;
		}

		private void RunChange_vertical(ulong timestep)
		{
			if (verticalChanged != null) verticalChanged(_vertical, timestep);
			if (fieldAltered != null) fieldAltered("vertical", _vertical, timestep);
		}
		[ForgeGeneratedField]
		private float _cameraVertical;
		public event FieldEvent<float> cameraVerticalChanged;
		public InterpolateFloat cameraVerticalInterpolation = new InterpolateFloat() { LerpT = 0.2f, Enabled = true };
		public float cameraVertical
		{
			get { return _cameraVertical; }
			set
			{
				// Don't do anything if the value is the same
				if (_cameraVertical == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x20;
				_cameraVertical = value;
				hasDirtyFields = true;
			}
		}

		public void SetcameraVerticalDirty()
		{
			_dirtyFields[0] |= 0x20;
			hasDirtyFields = true;
		}

		private void RunChange_cameraVertical(ulong timestep)
		{
			if (cameraVerticalChanged != null) cameraVerticalChanged(_cameraVertical, timestep);
			if (fieldAltered != null) fieldAltered("cameraVertical", _cameraVertical, timestep);
		}
		[ForgeGeneratedField]
		private bool _isShooting;
		public event FieldEvent<bool> isShootingChanged;
		public Interpolated<bool> isShootingInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool isShooting
		{
			get { return _isShooting; }
			set
			{
				// Don't do anything if the value is the same
				if (_isShooting == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x40;
				_isShooting = value;
				hasDirtyFields = true;
			}
		}

		public void SetisShootingDirty()
		{
			_dirtyFields[0] |= 0x40;
			hasDirtyFields = true;
		}

		private void RunChange_isShooting(ulong timestep)
		{
			if (isShootingChanged != null) isShootingChanged(_isShooting, timestep);
			if (fieldAltered != null) fieldAltered("isShooting", _isShooting, timestep);
		}
		[ForgeGeneratedField]
		private bool _isUsing;
		public event FieldEvent<bool> isUsingChanged;
		public Interpolated<bool> isUsingInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool isUsing
		{
			get { return _isUsing; }
			set
			{
				// Don't do anything if the value is the same
				if (_isUsing == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x80;
				_isUsing = value;
				hasDirtyFields = true;
			}
		}

		public void SetisUsingDirty()
		{
			_dirtyFields[0] |= 0x80;
			hasDirtyFields = true;
		}

		private void RunChange_isUsing(ulong timestep)
		{
			if (isUsingChanged != null) isUsingChanged(_isUsing, timestep);
			if (fieldAltered != null) fieldAltered("isUsing", _isUsing, timestep);
		}
		[ForgeGeneratedField]
		private bool _isAiming;
		public event FieldEvent<bool> isAimingChanged;
		public Interpolated<bool> isAimingInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool isAiming
		{
			get { return _isAiming; }
			set
			{
				// Don't do anything if the value is the same
				if (_isAiming == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x1;
				_isAiming = value;
				hasDirtyFields = true;
			}
		}

		public void SetisAimingDirty()
		{
			_dirtyFields[1] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_isAiming(ulong timestep)
		{
			if (isAimingChanged != null) isAimingChanged(_isAiming, timestep);
			if (fieldAltered != null) fieldAltered("isAiming", _isAiming, timestep);
		}
		[ForgeGeneratedField]
		private bool _isJumping;
		public event FieldEvent<bool> isJumpingChanged;
		public Interpolated<bool> isJumpingInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool isJumping
		{
			get { return _isJumping; }
			set
			{
				// Don't do anything if the value is the same
				if (_isJumping == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x2;
				_isJumping = value;
				hasDirtyFields = true;
			}
		}

		public void SetisJumpingDirty()
		{
			_dirtyFields[1] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_isJumping(ulong timestep)
		{
			if (isJumpingChanged != null) isJumpingChanged(_isJumping, timestep);
			if (fieldAltered != null) fieldAltered("isJumping", _isJumping, timestep);
		}
		[ForgeGeneratedField]
		private bool _isGrounded;
		public event FieldEvent<bool> isGroundedChanged;
		public Interpolated<bool> isGroundedInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool isGrounded
		{
			get { return _isGrounded; }
			set
			{
				// Don't do anything if the value is the same
				if (_isGrounded == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x4;
				_isGrounded = value;
				hasDirtyFields = true;
			}
		}

		public void SetisGroundedDirty()
		{
			_dirtyFields[1] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_isGrounded(ulong timestep)
		{
			if (isGroundedChanged != null) isGroundedChanged(_isGrounded, timestep);
			if (fieldAltered != null) fieldAltered("isGrounded", _isGrounded, timestep);
		}
		[ForgeGeneratedField]
		private uint _ownerNetId;
		public event FieldEvent<uint> ownerNetIdChanged;
		public Interpolated<uint> ownerNetIdInterpolation = new Interpolated<uint>() { LerpT = 0f, Enabled = false };
		public uint ownerNetId
		{
			get { return _ownerNetId; }
			set
			{
				// Don't do anything if the value is the same
				if (_ownerNetId == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x8;
				_ownerNetId = value;
				hasDirtyFields = true;
			}
		}

		public void SetownerNetIdDirty()
		{
			_dirtyFields[1] |= 0x8;
			hasDirtyFields = true;
		}

		private void RunChange_ownerNetId(ulong timestep)
		{
			if (ownerNetIdChanged != null) ownerNetIdChanged(_ownerNetId, timestep);
			if (fieldAltered != null) fieldAltered("ownerNetId", _ownerNetId, timestep);
		}
		[ForgeGeneratedField]
		private Vector3 _cameraAxis;
		public event FieldEvent<Vector3> cameraAxisChanged;
		public InterpolateVector3 cameraAxisInterpolation = new InterpolateVector3() { LerpT = 0f, Enabled = false };
		public Vector3 cameraAxis
		{
			get { return _cameraAxis; }
			set
			{
				// Don't do anything if the value is the same
				if (_cameraAxis == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x10;
				_cameraAxis = value;
				hasDirtyFields = true;
			}
		}

		public void SetcameraAxisDirty()
		{
			_dirtyFields[1] |= 0x10;
			hasDirtyFields = true;
		}

		private void RunChange_cameraAxis(ulong timestep)
		{
			if (cameraAxisChanged != null) cameraAxisChanged(_cameraAxis, timestep);
			if (fieldAltered != null) fieldAltered("cameraAxis", _cameraAxis, timestep);
		}
		[ForgeGeneratedField]
		private int _selectedWeapon;
		public event FieldEvent<int> selectedWeaponChanged;
		public Interpolated<int> selectedWeaponInterpolation = new Interpolated<int>() { LerpT = 0f, Enabled = false };
		public int selectedWeapon
		{
			get { return _selectedWeapon; }
			set
			{
				// Don't do anything if the value is the same
				if (_selectedWeapon == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[1] |= 0x20;
				_selectedWeapon = value;
				hasDirtyFields = true;
			}
		}

		public void SetselectedWeaponDirty()
		{
			_dirtyFields[1] |= 0x20;
			hasDirtyFields = true;
		}

		private void RunChange_selectedWeapon(ulong timestep)
		{
			if (selectedWeaponChanged != null) selectedWeaponChanged(_selectedWeapon, timestep);
			if (fieldAltered != null) fieldAltered("selectedWeapon", _selectedWeapon, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			positionInterpolation.current = positionInterpolation.target;
			rotationInterpolation.current = rotationInterpolation.target;
			spineInterpolation.current = spineInterpolation.target;
			horizontalInterpolation.current = horizontalInterpolation.target;
			verticalInterpolation.current = verticalInterpolation.target;
			cameraVerticalInterpolation.current = cameraVerticalInterpolation.target;
			isShootingInterpolation.current = isShootingInterpolation.target;
			isUsingInterpolation.current = isUsingInterpolation.target;
			isAimingInterpolation.current = isAimingInterpolation.target;
			isJumpingInterpolation.current = isJumpingInterpolation.target;
			isGroundedInterpolation.current = isGroundedInterpolation.target;
			ownerNetIdInterpolation.current = ownerNetIdInterpolation.target;
			cameraAxisInterpolation.current = cameraAxisInterpolation.target;
			selectedWeaponInterpolation.current = selectedWeaponInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _position);
			UnityObjectMapper.Instance.MapBytes(data, _rotation);
			UnityObjectMapper.Instance.MapBytes(data, _spine);
			UnityObjectMapper.Instance.MapBytes(data, _horizontal);
			UnityObjectMapper.Instance.MapBytes(data, _vertical);
			UnityObjectMapper.Instance.MapBytes(data, _cameraVertical);
			UnityObjectMapper.Instance.MapBytes(data, _isShooting);
			UnityObjectMapper.Instance.MapBytes(data, _isUsing);
			UnityObjectMapper.Instance.MapBytes(data, _isAiming);
			UnityObjectMapper.Instance.MapBytes(data, _isJumping);
			UnityObjectMapper.Instance.MapBytes(data, _isGrounded);
			UnityObjectMapper.Instance.MapBytes(data, _ownerNetId);
			UnityObjectMapper.Instance.MapBytes(data, _cameraAxis);
			UnityObjectMapper.Instance.MapBytes(data, _selectedWeapon);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_position = UnityObjectMapper.Instance.Map<Vector3>(payload);
			positionInterpolation.current = _position;
			positionInterpolation.target = _position;
			RunChange_position(timestep);
			_rotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			rotationInterpolation.current = _rotation;
			rotationInterpolation.target = _rotation;
			RunChange_rotation(timestep);
			_spine = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			spineInterpolation.current = _spine;
			spineInterpolation.target = _spine;
			RunChange_spine(timestep);
			_horizontal = UnityObjectMapper.Instance.Map<float>(payload);
			horizontalInterpolation.current = _horizontal;
			horizontalInterpolation.target = _horizontal;
			RunChange_horizontal(timestep);
			_vertical = UnityObjectMapper.Instance.Map<float>(payload);
			verticalInterpolation.current = _vertical;
			verticalInterpolation.target = _vertical;
			RunChange_vertical(timestep);
			_cameraVertical = UnityObjectMapper.Instance.Map<float>(payload);
			cameraVerticalInterpolation.current = _cameraVertical;
			cameraVerticalInterpolation.target = _cameraVertical;
			RunChange_cameraVertical(timestep);
			_isShooting = UnityObjectMapper.Instance.Map<bool>(payload);
			isShootingInterpolation.current = _isShooting;
			isShootingInterpolation.target = _isShooting;
			RunChange_isShooting(timestep);
			_isUsing = UnityObjectMapper.Instance.Map<bool>(payload);
			isUsingInterpolation.current = _isUsing;
			isUsingInterpolation.target = _isUsing;
			RunChange_isUsing(timestep);
			_isAiming = UnityObjectMapper.Instance.Map<bool>(payload);
			isAimingInterpolation.current = _isAiming;
			isAimingInterpolation.target = _isAiming;
			RunChange_isAiming(timestep);
			_isJumping = UnityObjectMapper.Instance.Map<bool>(payload);
			isJumpingInterpolation.current = _isJumping;
			isJumpingInterpolation.target = _isJumping;
			RunChange_isJumping(timestep);
			_isGrounded = UnityObjectMapper.Instance.Map<bool>(payload);
			isGroundedInterpolation.current = _isGrounded;
			isGroundedInterpolation.target = _isGrounded;
			RunChange_isGrounded(timestep);
			_ownerNetId = UnityObjectMapper.Instance.Map<uint>(payload);
			ownerNetIdInterpolation.current = _ownerNetId;
			ownerNetIdInterpolation.target = _ownerNetId;
			RunChange_ownerNetId(timestep);
			_cameraAxis = UnityObjectMapper.Instance.Map<Vector3>(payload);
			cameraAxisInterpolation.current = _cameraAxis;
			cameraAxisInterpolation.target = _cameraAxis;
			RunChange_cameraAxis(timestep);
			_selectedWeapon = UnityObjectMapper.Instance.Map<int>(payload);
			selectedWeaponInterpolation.current = _selectedWeapon;
			selectedWeaponInterpolation.target = _selectedWeapon;
			RunChange_selectedWeapon(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _position);
			if ((0x2 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _rotation);
			if ((0x4 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _spine);
			if ((0x8 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _horizontal);
			if ((0x10 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _vertical);
			if ((0x20 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _cameraVertical);
			if ((0x40 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _isShooting);
			if ((0x80 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _isUsing);
			if ((0x1 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _isAiming);
			if ((0x2 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _isJumping);
			if ((0x4 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _isGrounded);
			if ((0x8 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _ownerNetId);
			if ((0x10 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _cameraAxis);
			if ((0x20 & _dirtyFields[1]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _selectedWeapon);

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
				if (positionInterpolation.Enabled)
				{
					positionInterpolation.target = UnityObjectMapper.Instance.Map<Vector3>(data);
					positionInterpolation.Timestep = timestep;
				}
				else
				{
					_position = UnityObjectMapper.Instance.Map<Vector3>(data);
					RunChange_position(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[0]) != 0)
			{
				if (rotationInterpolation.Enabled)
				{
					rotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					rotationInterpolation.Timestep = timestep;
				}
				else
				{
					_rotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_rotation(timestep);
				}
			}
			if ((0x4 & readDirtyFlags[0]) != 0)
			{
				if (spineInterpolation.Enabled)
				{
					spineInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					spineInterpolation.Timestep = timestep;
				}
				else
				{
					_spine = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_spine(timestep);
				}
			}
			if ((0x8 & readDirtyFlags[0]) != 0)
			{
				if (horizontalInterpolation.Enabled)
				{
					horizontalInterpolation.target = UnityObjectMapper.Instance.Map<float>(data);
					horizontalInterpolation.Timestep = timestep;
				}
				else
				{
					_horizontal = UnityObjectMapper.Instance.Map<float>(data);
					RunChange_horizontal(timestep);
				}
			}
			if ((0x10 & readDirtyFlags[0]) != 0)
			{
				if (verticalInterpolation.Enabled)
				{
					verticalInterpolation.target = UnityObjectMapper.Instance.Map<float>(data);
					verticalInterpolation.Timestep = timestep;
				}
				else
				{
					_vertical = UnityObjectMapper.Instance.Map<float>(data);
					RunChange_vertical(timestep);
				}
			}
			if ((0x20 & readDirtyFlags[0]) != 0)
			{
				if (cameraVerticalInterpolation.Enabled)
				{
					cameraVerticalInterpolation.target = UnityObjectMapper.Instance.Map<float>(data);
					cameraVerticalInterpolation.Timestep = timestep;
				}
				else
				{
					_cameraVertical = UnityObjectMapper.Instance.Map<float>(data);
					RunChange_cameraVertical(timestep);
				}
			}
			if ((0x40 & readDirtyFlags[0]) != 0)
			{
				if (isShootingInterpolation.Enabled)
				{
					isShootingInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					isShootingInterpolation.Timestep = timestep;
				}
				else
				{
					_isShooting = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_isShooting(timestep);
				}
			}
			if ((0x80 & readDirtyFlags[0]) != 0)
			{
				if (isUsingInterpolation.Enabled)
				{
					isUsingInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					isUsingInterpolation.Timestep = timestep;
				}
				else
				{
					_isUsing = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_isUsing(timestep);
				}
			}
			if ((0x1 & readDirtyFlags[1]) != 0)
			{
				if (isAimingInterpolation.Enabled)
				{
					isAimingInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					isAimingInterpolation.Timestep = timestep;
				}
				else
				{
					_isAiming = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_isAiming(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[1]) != 0)
			{
				if (isJumpingInterpolation.Enabled)
				{
					isJumpingInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					isJumpingInterpolation.Timestep = timestep;
				}
				else
				{
					_isJumping = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_isJumping(timestep);
				}
			}
			if ((0x4 & readDirtyFlags[1]) != 0)
			{
				if (isGroundedInterpolation.Enabled)
				{
					isGroundedInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					isGroundedInterpolation.Timestep = timestep;
				}
				else
				{
					_isGrounded = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_isGrounded(timestep);
				}
			}
			if ((0x8 & readDirtyFlags[1]) != 0)
			{
				if (ownerNetIdInterpolation.Enabled)
				{
					ownerNetIdInterpolation.target = UnityObjectMapper.Instance.Map<uint>(data);
					ownerNetIdInterpolation.Timestep = timestep;
				}
				else
				{
					_ownerNetId = UnityObjectMapper.Instance.Map<uint>(data);
					RunChange_ownerNetId(timestep);
				}
			}
			if ((0x10 & readDirtyFlags[1]) != 0)
			{
				if (cameraAxisInterpolation.Enabled)
				{
					cameraAxisInterpolation.target = UnityObjectMapper.Instance.Map<Vector3>(data);
					cameraAxisInterpolation.Timestep = timestep;
				}
				else
				{
					_cameraAxis = UnityObjectMapper.Instance.Map<Vector3>(data);
					RunChange_cameraAxis(timestep);
				}
			}
			if ((0x20 & readDirtyFlags[1]) != 0)
			{
				if (selectedWeaponInterpolation.Enabled)
				{
					selectedWeaponInterpolation.target = UnityObjectMapper.Instance.Map<int>(data);
					selectedWeaponInterpolation.Timestep = timestep;
				}
				else
				{
					_selectedWeapon = UnityObjectMapper.Instance.Map<int>(data);
					RunChange_selectedWeapon(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (positionInterpolation.Enabled && !positionInterpolation.current.UnityNear(positionInterpolation.target, 0.0015f))
			{
				_position = (Vector3)positionInterpolation.Interpolate();
				//RunChange_position(positionInterpolation.Timestep);
			}
			if (rotationInterpolation.Enabled && !rotationInterpolation.current.UnityNear(rotationInterpolation.target, 0.0015f))
			{
				_rotation = (Quaternion)rotationInterpolation.Interpolate();
				//RunChange_rotation(rotationInterpolation.Timestep);
			}
			if (spineInterpolation.Enabled && !spineInterpolation.current.UnityNear(spineInterpolation.target, 0.0015f))
			{
				_spine = (Quaternion)spineInterpolation.Interpolate();
				//RunChange_spine(spineInterpolation.Timestep);
			}
			if (horizontalInterpolation.Enabled && !horizontalInterpolation.current.UnityNear(horizontalInterpolation.target, 0.0015f))
			{
				_horizontal = (float)horizontalInterpolation.Interpolate();
				//RunChange_horizontal(horizontalInterpolation.Timestep);
			}
			if (verticalInterpolation.Enabled && !verticalInterpolation.current.UnityNear(verticalInterpolation.target, 0.0015f))
			{
				_vertical = (float)verticalInterpolation.Interpolate();
				//RunChange_vertical(verticalInterpolation.Timestep);
			}
			if (cameraVerticalInterpolation.Enabled && !cameraVerticalInterpolation.current.UnityNear(cameraVerticalInterpolation.target, 0.0015f))
			{
				_cameraVertical = (float)cameraVerticalInterpolation.Interpolate();
				//RunChange_cameraVertical(cameraVerticalInterpolation.Timestep);
			}
			if (isShootingInterpolation.Enabled && !isShootingInterpolation.current.UnityNear(isShootingInterpolation.target, 0.0015f))
			{
				_isShooting = (bool)isShootingInterpolation.Interpolate();
				//RunChange_isShooting(isShootingInterpolation.Timestep);
			}
			if (isUsingInterpolation.Enabled && !isUsingInterpolation.current.UnityNear(isUsingInterpolation.target, 0.0015f))
			{
				_isUsing = (bool)isUsingInterpolation.Interpolate();
				//RunChange_isUsing(isUsingInterpolation.Timestep);
			}
			if (isAimingInterpolation.Enabled && !isAimingInterpolation.current.UnityNear(isAimingInterpolation.target, 0.0015f))
			{
				_isAiming = (bool)isAimingInterpolation.Interpolate();
				//RunChange_isAiming(isAimingInterpolation.Timestep);
			}
			if (isJumpingInterpolation.Enabled && !isJumpingInterpolation.current.UnityNear(isJumpingInterpolation.target, 0.0015f))
			{
				_isJumping = (bool)isJumpingInterpolation.Interpolate();
				//RunChange_isJumping(isJumpingInterpolation.Timestep);
			}
			if (isGroundedInterpolation.Enabled && !isGroundedInterpolation.current.UnityNear(isGroundedInterpolation.target, 0.0015f))
			{
				_isGrounded = (bool)isGroundedInterpolation.Interpolate();
				//RunChange_isGrounded(isGroundedInterpolation.Timestep);
			}
			if (ownerNetIdInterpolation.Enabled && !ownerNetIdInterpolation.current.UnityNear(ownerNetIdInterpolation.target, 0.0015f))
			{
				_ownerNetId = (uint)ownerNetIdInterpolation.Interpolate();
				//RunChange_ownerNetId(ownerNetIdInterpolation.Timestep);
			}
			if (cameraAxisInterpolation.Enabled && !cameraAxisInterpolation.current.UnityNear(cameraAxisInterpolation.target, 0.0015f))
			{
				_cameraAxis = (Vector3)cameraAxisInterpolation.Interpolate();
				//RunChange_cameraAxis(cameraAxisInterpolation.Timestep);
			}
			if (selectedWeaponInterpolation.Enabled && !selectedWeaponInterpolation.current.UnityNear(selectedWeaponInterpolation.target, 0.0015f))
			{
				_selectedWeapon = (int)selectedWeaponInterpolation.Interpolate();
				//RunChange_selectedWeapon(selectedWeaponInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[2];

		}

		public PlayerNetworkObject() : base() { Initialize(); }
		public PlayerNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public PlayerNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
