﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NEUVolunteer.Services
{
    public interface IPreferenceStorage
    {
        int Get(string key, int defaultValue);

        void Set(string key, int value);
    }
}