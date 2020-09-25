using System;
using System.IO;
using Refactoring.FraudDetection.Core.Infrastructure.Repository.Contracts;

namespace Refactoring.FraudDetection.Tests.Utils
{
    public static class FakeHelper
    {
        public static IFileReader CreateFakeFileMemoryReader(string filePath)
        {
            var fakeReader = new FakeFileReader(filePath);

            #region "Files on Memory"
            
            fakeReader.FilesOnMemory.Add(
                Path.Combine(Environment.CurrentDirectory, "Files", "ZeroLineFile.txt"),
                new string[] {}
            );

            fakeReader.FilesOnMemory.Add(
                Path.Combine(Environment.CurrentDirectory, "Files", "OneLineFile.txt"),
                new[] {
                    "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010"
                }
            );

            fakeReader.FilesOnMemory.Add(
                Path.Combine(Environment.CurrentDirectory, "Files", "TwoLines_FraudulentSecond.txt"),
                new[] {
                    "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                    "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689011"
                }
            );

            fakeReader.FilesOnMemory.Add(
                Path.Combine(Environment.CurrentDirectory, "Files", "ThreeLines_FraudulentSecond.txt"),
                new[] {
                    "1,1,bugs @bunny.com,123 Sesame St., New York,NY,10011,12345689010",
                    "2,1,bugs @bunny.com,123 Sesame St., New York,NY,10011,12345689011",
                    "3,2,roger @rabbit.com,1234 Not Sesame St.,Colorado,CL,10012,12345689012"
                }
            );

            fakeReader.FilesOnMemory.Add(
                Path.Combine(Environment.CurrentDirectory, "Files", "FourLines_MoreThanOneFraudulent.txt"),
                new[] {
                    "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                    "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689011",
                    "3,2,roger@rabbit.com,1234 Not Sesame St.,Colorado,CL,10012,12345689012",
                    "4,2,roger@rabbit.com,1234 Not Sesame St.,Colorado,CL,10012,12345689014"
                }
            );
            #endregion

            return fakeReader;
        }

        public static IFileReader CreateFakeFileJsonInMemoryReader(string filePath)
        {
            var fakeReader = new FakeJsonReader(filePath);

            #region "Files Json on Memory"
            fakeReader.FilesJsonOnMemory.Add(
                "ZeroLineFile.txt",
                @""
            );

            fakeReader.FilesJsonOnMemory.Add(
                "OneLineFile.txt",
                @"[{""CreditCard"":""12345689010"",""DealAddress"":{""State"":""NY"",""ZipCode"":""10011"",""Street"":""123 Sesame St."",""City"":""New York""},""DealId"":1,""Email"":""bugs@bunny.com"",""OrderId"":1}]"
            );

            fakeReader.FilesJsonOnMemory.Add(
                "TwoLines_FraudulentSecond.txt",
                @"[{""CreditCard"":""12345689010"",""DealAddress"":{""State"":""NY"",""ZipCode"":""10011"",""Street"":""123 Sesame St."",""City"":""New York""},""DealId"":1,""Email"":""bugs@bunny.com"",""OrderId"":1},{""CreditCard"":""12345689011"",""DealAddress"":{""State"":""NY"",""ZipCode"":""10011"",""Street"":""123 Sesame St."",""City"":""New York""},""DealId"":1,""Email"":""bugs@bunny.com"",""OrderId"":2}]"
            );

            fakeReader.FilesJsonOnMemory.Add(
                "ThreeLines_FraudulentSecond.txt",
                @"[{""CreditCard"":""12345689010"",""DealAddress"":{""State"":""NY"",""ZipCode"":""10011"",""Street"":""123 Sesame St."",""City"":"" New York""},""DealId"":1,""Email"":""bugs @bunny.com"",""OrderId"":1},{""CreditCard"":""12345689011"",""DealAddress"":{""State"":""NY"",""ZipCode"":""10011"",""Street"":""123 Sesame St."",""City"":"" New York""},""DealId"":1,""Email"":""bugs @bunny.com"",""OrderId"":2},{""CreditCard"":""12345689012"",""DealAddress"":{""State"":""CL"",""ZipCode"":""10012"",""Street"":""1234 Not Sesame St."",""City"":""Colorado""},""DealId"":2,""Email"":""roger @rabbit.com"",""OrderId"":3}]"
            );

            fakeReader.FilesJsonOnMemory.Add(
                "FourLines_MoreThanOneFraudulent.txt",
                @"[{""CreditCard"":""12345689010"",""DealAddress"":{""State"":""NY"",""ZipCode"":""10011"",""Street"":""123 Sesame St."",""City"":""New York""},""DealId"":1,""Email"":""bugs@bunny.com"",""OrderId"":1},{""CreditCard"":""12345689011"",""DealAddress"":{""State"":""NY"",""ZipCode"":""10011"",""Street"":""123 Sesame St."",""City"":""New York""},""DealId"":1,""Email"":""bugs@bunny.com"",""OrderId"":2},{""CreditCard"":""12345689012"",""DealAddress"":{""State"":""CL"",""ZipCode"":""10012"",""Street"":""1234 Not Sesame St."",""City"":""Colorado""},""DealId"":2,""Email"":""roger@rabbit.com"",""OrderId"":3},{""CreditCard"":""12345689014"",""DealAddress"":{""State"":""CL"",""ZipCode"":""10012"",""Street"":""1234 Not Sesame St."",""City"":""Colorado""},""DealId"":2,""Email"":""roger@rabbit.com"",""OrderId"":4}]"
            );
            #endregion

            return fakeReader;
        }
    }
}
