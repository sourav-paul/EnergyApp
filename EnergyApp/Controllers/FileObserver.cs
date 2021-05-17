using System;
using System.IO;
using System.Configuration;

namespace EnergyApp.Controllers
{
    public class FileObserver
    {
        public FileObserver()
        {
            string InputLocation = ConfigurationManager.AppSettings["test-input-directory"];
            string OutputLocation = ConfigurationManager.AppSettings["test-output-directory"];
            string ReferenceDataLocation = ConfigurationManager.AppSettings["reference-directory"];
            string GeneratorFactorMapLocation = ConfigurationManager.AppSettings["generator-factor-map-directory"];

            using var observer = new FileSystemWatcher(InputLocation);

            observer.NotifyFilter =
                                    NotifyFilters.Attributes |
                                    NotifyFilters.CreationTime |
                                    NotifyFilters.DirectoryName |
                                    NotifyFilters.FileName |
                                    NotifyFilters.LastWrite;

            observer.Changed += OnChanged;
            observer.Created += OnCreated;
            observer.Deleted += OnDeleted;
            observer.Renamed += OnRenamed;
            observer.Error += OnError;

            observer.Filter = "*.xml";
            observer.EnableRaisingEvents = true;

            Console.WriteLine("Observing XML files for runtime modifications.\n");

            Console.WriteLine("Report location               : " + InputLocation);
            Console.WriteLine("Result location               : " + OutputLocation);
            Console.WriteLine("Reference location            : " + ReferenceDataLocation);
            Console.WriteLine("Generator-Factor Map location : " + GeneratorFactorMapLocation);

            Console.WriteLine("\nPress enter to exit application.");
            Console.ReadLine();
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"\nChanged: {e.FullPath}");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"\nCreated: {e.FullPath}");
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"\nDeleted: {e.FullPath}");

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"\nRenamed:");
            Console.WriteLine($"    Old: {e.OldFullPath}");
            Console.WriteLine($"    New: {e.FullPath}");
        }

        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private static void PrintException(Exception? ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }
    }
}
