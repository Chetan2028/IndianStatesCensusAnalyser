using NUnit.Framework;
using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.POCO;
using Newtonsoft.Json;
using static IndianStateCensusAnalyser.CensusAnalyser;
using System.Collections.Generic;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"D:\C# Programs\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"D:\C# Programs\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"D:\C# Programs\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"D:\C# Programs\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"D:\C# Programs\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";

        IndianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// T.C -> 1.1 #Happy Test Case
        /// Givens the indian census data file when readed should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        /// <summary>
        /// T.C -> 1.2 #Sad Test Case
        /// Givens the wrong indian census data file when readed should return custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA,wrongIndianStateCensusFilePath,indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.etype);
        }

        /// <summary>
        /// T.C -> 1.3
        /// This is a Sad Test Case to verify if the type is incorrect then exception is raised
        /// Givens the wrong indian census data file type when readed should return custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.etype);
        }

        /// <summary>
        /// T.C -> 1.4
        /// Givens the indian census data file when delimiter not proper should return exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA,delimiterIndianCensusFilePath,indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.etype);
        }
        /// <summary>
        /// T.C -> 1.5
        /// Givens the indian census data file when header not proper should return exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.etype);
        }
    }
}