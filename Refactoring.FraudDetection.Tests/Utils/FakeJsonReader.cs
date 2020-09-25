using System;
using System.Collections.Generic;
using Refactoring.FraudDetection.Core.Infrastructure.Repository.Contracts;

namespace Refactoring.FraudDetection.Tests.Utils
{
    public class FakeJsonReader : IFileReader
    {
        public string Path { get; set; }

        public FakeJsonReader(string path)
        {
            Path = path;
            FilesJsonOnMemory = new Dictionary<string, string>();
        }

        public Dictionary<string, string> FilesJsonOnMemory { get; }

        public string[] ReadAllLines()
        {
            throw new NotImplementedException();
        }

        public string ReadAllText()
        {
            return FilesJsonOnMemory.GetValueOrDefault(Path);
        }
    }
}
