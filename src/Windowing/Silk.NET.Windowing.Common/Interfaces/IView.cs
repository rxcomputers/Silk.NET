// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;

namespace Silk.NET.Windowing.Common
{
    /// <summary>
    /// Represents a window view.
    /// </summary>
    public interface IView : IViewEvents, IViewProperties, IViewFunctions
    {
        /// <summary>
        /// A handle to the underlying window.
        /// </summary>
        IntPtr Handle { get; }
        
        /// <summary>
        /// Determines whether Vulkan functions are supported on this window.
        /// </summary>
        bool IsVulkanSupported { get; }
        
        /// <summary>
        /// Determines whether the underlying platform has requested the window to close.
        /// </summary>
        bool IsClosing { get; }

        /// <summary>
        /// If true, the window has failed to reach the target framerate for multiple consecutive frames, as defined
        /// in <see cref="IWindowProperties.RunningSlowTolerance"/>. You can use this to do things such as lowering
        /// visual fidelity to increase framerates on lower-end machines.
        /// </summary>
        bool IsRunningSlowly { get; }
    }
}
