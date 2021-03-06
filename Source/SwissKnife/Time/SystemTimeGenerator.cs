﻿using System;

namespace SwissKnife.Time
{
    /// <summary>
    /// <see cref="TimeGenerator"/> that uses local system's clock to generate time.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    [Serializable]
    public class SystemTimeGenerator : TimeGenerator
    {
        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> object that is set to the current date and time on the current computer, with the offset set to the local time's offset from Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>
        /// A date time offset whose date and time is the current local time and whose offset is the local time zone's offset from Coordinated Universal Time (UTC).
        /// </returns>
        public override DateTimeOffset LocalNow()
        {
            return DateTimeOffset.Now;
        }
    }
}
