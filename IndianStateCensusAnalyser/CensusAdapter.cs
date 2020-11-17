﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace IndianStateCensusAnalyser
{
    public abstract class CensusAdapter
    {
        protected string[] GetCensusData(string csvFilePath , string dataHeaders)
        {
            string[] censusData;
            
            if(Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}
