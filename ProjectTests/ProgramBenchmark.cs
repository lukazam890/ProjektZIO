﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace ProjectTests
{

        class ProgramBenchmark
        {

            static void Main(string[] args)
            {
            var summary = BenchmarkRunner.Run<QuestionControllerPerformanceTests>();
        }

    }
}


