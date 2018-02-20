﻿using JD_XI_Editor.Models.Enums.Effects.Fuzz;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect1
{
    internal class FuzzParameters : EffectParameters
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates a new instance of FuzzParameters
        /// </summary>
        public FuzzParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Type = Type.Three;
            Drive = 100;
            Presence = 127;
            Level = 70;
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            throw new System.NotImplementedException();
        }

        #region Fields

        /// <summary>
        ///     Fuzz Type
        /// </summary>
        private Type _type;

        /// <summary>
        ///     Drive
        /// </summary>
        private int _drive;

        /// <summary>
        ///     Presence
        /// </summary>
        private int _presence;

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        #endregion

        #region Properties

        /// <summary>
        ///     Fuzz Type
        /// </summary>
        public Type Type
        {
            get => _type;
            set
            {
                if (value != _type)
                {
                    _type = value;
                    NotifyOfPropertyChange(nameof(Type));
                }
            }
        }

        /// <summary>
        ///     Drive
        /// </summary>
        public int Drive
        {
            get => _drive;
            set
            {
                if (value != _drive)
                {
                    _drive = value;
                    NotifyOfPropertyChange(nameof(Drive));
                }
            }
        }

        /// <summary>
        ///     Presence
        /// </summary>
        public int Presence
        {
            get => _presence;
            set
            {
                if (value != _presence)
                {
                    _presence = value;
                    NotifyOfPropertyChange(nameof(Presence));
                }
            }
        }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level
        {
            get => _level;
            set
            {
                if (value != _level)
                {
                    _level = value;
                    NotifyOfPropertyChange(nameof(Level));
                }
            }
        }

        #endregion
    }
}