// ***********************************************************************
// Copyright (c) 2011-2014 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using System.Collections.Generic;
#if NETSTANDARD1_6
using System.Xml.Linq;
#else
using System.Xml;
#endif

namespace NUnit.Engine
{
    /// <summary>
    /// Interface implemented by all test runners.
    /// </summary>
    public interface ITestRunner : IDisposable
    {
        /// <summary>
        /// Get a flag indicating whether a test is running
        /// </summary>
        bool IsTestRunning { get; }

#if NETSTANDARD1_6
        /// <summary>
        /// Load a TestPackage for possible execution
        /// </summary>
        /// <returns>An XmlNode representing the loaded package.</returns>
        /// <remarks>
        /// This method is normally optional, since Explore and Run call
        /// it automatically when necessary. The method is kept in order
        /// to make it easier to convert older programs that use it.
        /// </remarks>
        XNode Load();
#else
        /// <summary>
        /// Load a TestPackage for possible execution
        /// </summary>
        /// <returns>An XmlNode representing the loaded package.</returns>
        /// <remarks>
        /// This method is normally optional, since Explore and Run call
        /// it automatically when necessary. The method is kept in order
        /// to make it easier to convert older programs that use it.
        /// </remarks>
        XmlNode Load();
#endif

        /// <summary>
        /// Unload any loaded TestPackage. If none is loaded,
        /// the call is ignored.
        /// </summary>
        void Unload();

#if NETSTANDARD1_6
        /// <summary>
        /// Reload the current TestPackage
        /// </summary>
        /// <returns>An XNode representing the loaded package.</returns>
        XNode Reload();
#else
        /// <summary>
        /// Reload the current TestPackage
        /// </summary>
        /// <returns>An XmlNode representing the loaded package.</returns>
        XmlNode Reload();
#endif

        /// <summary>
        /// Count the test cases that would be run under
        /// the specified filter.
        /// </summary>
        /// <param name="filter">A TestFilter</param>
        /// <returns>The count of test cases</returns>
        int CountTestCases(TestFilter filter);

#if NETSTANDARD1_6
        /// <summary>
        /// Run the tests in the loaded TestPackage and return a test result. The tests
        /// are run synchronously and the listener interface is notified as it progresses.
        /// </summary>
        /// <param name="listener">The listener that is notified as the run progresses</param>
        /// <param name="filter">A TestFilter used to select tests</param>
        /// <returns>An XNode giving the result of the test execution</returns>
        XNode Run(ITestEventListener listener, TestFilter filter);
#else
        /// <summary>
        /// Run the tests in the loaded TestPackage and return a test result. The tests
        /// are run synchronously and the listener interface is notified as it progresses.
        /// </summary>
        /// <param name="listener">The listener that is notified as the run progresses</param>
        /// <param name="filter">A TestFilter used to select tests</param>
        /// <returns>An XmlNode giving the result of the test execution</returns>
        XmlNode Run(ITestEventListener listener, TestFilter filter);
#endif

        /// <summary>
        /// Start a run of the tests in the loaded TestPackage. The tests are run
        /// asynchronously and the listener interface is notified as it progresses.
        /// </summary>
        /// <param name="listener">The listener that is notified as the run progresses</param>
        /// <param name="filter">A TestFilter used to select tests</param>
        /// <returns></returns>
        ITestRun RunAsync(ITestEventListener listener, TestFilter filter);

        /// <summary>
        /// Cancel the ongoing test run. If no  test is running, the call is ignored.
        /// </summary>
        /// <param name="force">If true, cancel any ongoing test threads, otherwise wait for them to complete.</param>
        void StopRun(bool force);

#if NETSTANDARD1_6
        /// <summary>
        /// Explore a loaded TestPackage and return information about the tests found.
        /// </summary>
        /// <param name="filter">The TestFilter to be used in selecting tests to explore.</param>
        /// <returns>An XNode representing the tests found.</returns>
        XNode Explore(TestFilter filter);
#else
        /// <summary>
        /// Explore a loaded TestPackage and return information about the tests found.
        /// </summary>
        /// <param name="filter">The TestFilter to be used in selecting tests to explore.</param>
        /// <returns>An XmlNode representing the tests found.</returns>
        XmlNode Explore(TestFilter filter);
#endif
    }
}
