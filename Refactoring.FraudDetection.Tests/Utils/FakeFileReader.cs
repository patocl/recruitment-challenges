using System;
using System.Collections.Generic;
using Refactoring.FraudDetection.Core.Infrastructure.Repository.Contracts;

namespace Refactoring.FraudDetection.Tests.Utils
{
    public class FakeFileReader : IFileReader
    {
        public string Path { get; set; }

        public FakeFileReader(string path)
        {
            Path = path;
            FilesOnMemory = new Dictionary<string, string[]>();
        }

        public Dictionary<string, string[]> FilesOnMemory { get; }

        public string[] ReadAllLines() => FilesOnMemory.GetValueOrDefault(Path);

        // TODO (HG) - Need to be fixed, but for demo is ok!
        // I should Split this interface
        public string ReadAllText() => throw new NotImplementedException();
    }
}