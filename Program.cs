using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace tasks_sem
{
    class Program
    {

        static CandidateManagement candidateManagement = new CandidateManagement();

        static void Main(string[] args)
        {
            candidateManagement.LoadDataFromFile();


            start();

        }
        }



    }