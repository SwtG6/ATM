﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Data
{
    public interface IDataFormat
    {
        Track CreateTrack(string trackInfo);
    }
}