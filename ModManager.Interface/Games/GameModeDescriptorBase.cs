﻿
using System.Collections.Generic;
namespace Nexus.Client.Games
{
	/// <summary>
	/// The base class for game mode descriptors.
	/// </summary>
	/// <remarks>
	/// This implements functionality common to all game mode descriptors.
	/// </remarks>
	public abstract class GameModeDescriptorBase : IGameModeDescriptor
	{
		#region Properties

		/// <summary>
		/// Gets the application's envrionment info.
		/// </summary>
		/// <value>The application's envrionment info.</value>
		protected IEnvironmentInfo EnvironmentInfo { get; private set; }

		/// <summary>
		/// Gets the display name of the game mode.
		/// </summary>
		/// <value>The display name of the game mode.</value>
		public abstract string Name { get; }

		/// <summary>
		/// Gets the unique id of the game mode.
		/// </summary>
		/// <value>The unique id of the game mode.</value>
		public abstract string ModeId { get; }

		/// <summary>
		/// Gets the list of possible executable files for the game.
		/// </summary>
		/// <value>The list of possible executable files for the game.</value>
		public abstract string[] GameExecutables { get; }

		/// <summary>
		/// Gets the path to which mod files should be installed.
		/// </summary>
		/// <value>The path to which mod files should be installed.</value>
		public virtual string InstallationPath
		{
			get
			{
				if (EnvironmentInfo.Settings.InstallationPaths.ContainsKey(ModeId))
					return (string)EnvironmentInfo.Settings.InstallationPaths[ModeId];
				return null;
			}
		}

		/// <summary>
		/// Gets the secondary path to which mod files should be installed.
		/// </summary>
		/// <value>The secondary path to which mod files should be installed.</value>
		public virtual string SecondaryInstallationPath
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Gets the extensions that are used by the game mode for plugin files.
		/// </summary>
		/// <value>The extensions that are used by the game mode for plugin files.</value>
		public virtual IEnumerable<string> PluginExtensions
		{
			get
			{
				return new List<string>();
			}
		}

		/// <summary>
		/// Gets a list of possible folders that should be looked for in mod archives to determine
		/// file structure.
		/// </summary>
		/// <value>A list of possible folders that should be looked for in mod archives to determine
		/// file structure.</value>
		public virtual IEnumerable<string> StopFolders
		{
			get
			{
				return new List<string>();
			}
		}

		/// <summary>
		/// Gets the path to the game executable.
		/// </summary>
		/// <value>The path to the game executable.</value>
		public string ExecutablePath
		{
			get
			{
				if (EnvironmentInfo.Settings.ExecutablePaths.ContainsKey(ModeId))
					return (string)EnvironmentInfo.Settings.ExecutablePaths[ModeId];
				return null;
			}
		}

		/// <summary>
		/// Gets the list of critical plugin names, ordered by load order.
		/// </summary>
		/// <value>The list of critical plugin names, ordered by load order.</value>
		public virtual string[] OrderedCriticalPluginNames
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Gets the list of official plugin names, ordered by load order.
		/// </summary>
		/// <value>The list of official plugin names, ordered by load order.</value>
		public virtual string[] OrderedOfficialPluginNames
		{
			get
			{
				return null;
			}
		}

        /// <summary>
        /// Gets the list of official unamanageable plugin names, ordered by load order.
        /// </summary>
        /// <value>The list of official unamanageable plugin names, ordered by load order.</value>
        public virtual string[] OrderedOfficialUnmanagedPluginNames
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the name of the required tool (if any) for the current game mode.
        /// </summary>
        /// <value>The name of the required tool (if any) for the current game mode.</value>
        public virtual string RequiredToolName 
		{ 
			get
			{
				return null;
			} 
		}

		/// <summary>
		/// Gets the list of required tools file names, ordered by load order.
		/// </summary>
		/// <value>The list of required tools file names, ordered by load order.</value>
		public virtual string[] OrderedRequiredToolFileNames 
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Gets the error message specific to a missing required tool.
		/// </summary>
		/// <value>The error message specific to a missing required tool.</value>
		public virtual string RequiredToolErrorMessage
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Gets the theme to use for this game mode.
		/// </summary>
		/// <value>The theme to use for this game mode.</value>
		public abstract Theme ModeTheme { get; }

		/// <summary>
		/// Gets the custom message for missing critical files.
		/// </summary>
		/// <value>The custom message for missing critical files.</value>
		public virtual string CriticalFilesErrorMessage
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Gets the directory where the game plugins are installed.
		/// </summary>
		/// <value>The directory where the game plugins are installed.</value>
		public abstract string PluginDirectory { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// A simple constructor that initializes the object with the given dependencies.
		/// </summary>
		/// <param name="p_eifEnvironmentInfo">The application's envrionment info.</param>
		public GameModeDescriptorBase(IEnvironmentInfo p_eifEnvironmentInfo)
		{
			EnvironmentInfo = p_eifEnvironmentInfo;
		}

		#endregion
	}
}
