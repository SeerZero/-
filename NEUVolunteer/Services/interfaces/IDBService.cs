﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NEUVolunteer.Models;

namespace NEUVolunteer.Services.interfaces
{
    public interface IDBService {

        bool Initialized();

        Task InitializeAsync();

        Task<IList<ActivityType>> GetActivityTypesAsync();

        Task AddApplyAsync(int applyActivityId, int applyManagerId, string gatherTime, string gatherPlace, string startTime, string endTime, int number);

        Task AddActivityInfo(string activityName, string activityPlace, string activityBrief, int typeId);

        Task<IList<ActivityInfo>> GetActivityInfosAsync();
    }

    public static class DBConstants
    {
        /// <summary>
        /// 版本键。
        /// </summary>
        public const string VersionKey =
            nameof(DBConstants) + "." + nameof(Version);

        /// <summary>
        /// 版本。
        /// </summary>
        public const int Version = 3;
    }
}
