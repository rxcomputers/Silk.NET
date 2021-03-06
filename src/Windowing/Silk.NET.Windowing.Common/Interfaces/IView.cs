// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Drawing;

namespace Silk.NET.Windowing.Common
{
    /// <summary>
    /// Represents a window view.
    /// </summary>
    public interface IView : IViewProperties
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
        /// in <see cref="IViewProperties.RunningSlowTolerance"/>. You can use this to do things such as lowering
        /// visual fidelity to increase framerates on lower-end machines.
        /// </summary>
        bool IsRunningSlowly { get; }

        /// <summary>
        /// Raised when the window is resized.
        /// </summary>
        event Action<Size> Resize;

        /// <summary>
        /// Raised when the window is about to close.
        /// </summary>
        event Action Closing;

        /// <summary>
        /// Raised when the window focus changes.
        /// </summary>
        event Action<bool> FocusChanged;

        /// <summary>
        /// Raised when the window first begins to run.
        /// </summary>
        event Action Load;

        /// <summary>
        /// Raised when an update should be run.
        /// </summary>
        event Action<double> Update;

        /// <summary>
        /// Raised when a frame should be rendered.
        /// </summary>
        event Action<double> Render;

        /// <summary>
        /// Creates the window on the underlying platform.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Calls the Render event. On a multi-threaded window, this will run on an internally managed thread.
        /// </summary>
        void DoRender();

        /// <summary>
        /// Calls the Update event. On a multi-threaded window, this can run on any thread.
        /// </summary>
        void DoUpdate();

        /// <summary>
        /// Polls the underlying platform for events.
        /// </summary>
        void DoEvents();

        /// <summary>
        /// Unloads the window on the underlying platform.
        /// </summary>
        void Reset();

        /// <summary>
        /// Swaps the front and back buffers.
        /// </summary>
        void SwapBuffers();

        /// <summary>
        /// Makes the OpenGL context current on the current thread.
        /// </summary>
        void MakeCurrent();

        /// <summary>
        /// Close this window.
        /// </summary>
        void Close();

        /// <summary>
        /// Converts this point to client coordinates.
        /// </summary>
        /// <param name="point">The point to transform.</param>
        /// <returns></returns>
        Point PointToClient(Point point);

        /// <summary>
        /// Converts this point to screen coordinates.
        /// </summary>
        /// <param name="point">The point to transform.</param>
        /// <returns></returns>
        Point PointToScreen(Point point);

        /// <summary>
        /// Invokes this delegate on the window's main thread.
        /// </summary>
        /// <param name="d">The delegate to run.</param>
        /// <returns>An object returned from the delegate.</returns>
        object Invoke(Delegate d);

        /// <summary>
        /// Invokes this delegate on the window's main thread, with the provided arguments.
        /// </summary>
        /// <param name="d">The delegate to run.</param>
        /// <param name="args">The delegate's arguments.</param>
        /// <returns>An object returned from the delegate.</returns>
        object Invoke(Delegate d, params object[] args);
    }
}
