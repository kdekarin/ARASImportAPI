using System;
using ImportService.BusinessAccessLayer.ImportServiceBuisinessManagers;
using IS.BusinessAccessLayer.BusinessLogic.ImportService.Models;
using System.IO;
using System.Diagnostics;
using ImportService.BusinessAccessLayer.BusinessLogic.Models;

namespace ImportService.BusinessAccessLayer.TravelBuisinessManagers
{
    public class ImportServiceManager : IImportServiceManager
    {
        //IImportServiceDALDALManager importServiceManager;

        public ImportServiceManager()//MyCustomDbContext cutomContext
        {
            //importServiceManager = new ImportServiceFactory(cutomContext).CreateImportServiceManager();
        }

        ImportResult IImportServiceManager.CreateImportProgram(ImportSettings importRequest)
        {
            try
            {
                //Init
                string locationOfBatFile = $@"{importRequest.ImportDirectory}{importRequest.GUID}.bat";
                ImportResult res = new ImportResult()
                {
                    IsError = false,
                    ErrorReason = string.Empty,
                    GUID = importRequest.GUID
                };

                //Validation
                ValidateImportRequestSettings(importRequest, res);
                if (res.IsError == true)
                {
                    res.GUID = String.Empty;
                    return res;
                }

                //Creates Batch File
                CreateBatchFile(importRequest, locationOfBatFile);

                //Executes Batch File
                ExecuteBatchFile(importRequest, locationOfBatFile);

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void ValidateImportRequestSettings(ImportSettings importRequest, ImportResult res)
        {
            if (String.IsNullOrEmpty(importRequest.DatabaseName))
            {
                res.IsError = true; res.ErrorReason = "DatabaseName is mandatory";
                return;
            }

            if (String.IsNullOrEmpty(importRequest.ImportDirectory))
            {
                res.IsError = true; res.ErrorReason = "ImportDirectory is mandatory";
                return;
            }

            if (String.IsNullOrEmpty(importRequest.Login))
            {
                res.IsError = true; res.ErrorReason = "Login is mandatory";
                return;
            }

            if (String.IsNullOrEmpty(importRequest.ManifestFileName))
            {
                res.IsError = true; res.ErrorReason = "ManifestFileName is mandatory";
                return;
            }

            if (String.IsNullOrEmpty(importRequest.Password))
            {
                res.IsError = true; res.ErrorReason = "Password is mandatory";
                return;
            }

            if (String.IsNullOrEmpty(importRequest.ServerURL))
            {
                res.IsError = true; res.ErrorReason = "ServerURL is mandatory"; return;
            }
        }

        private static void ExecuteBatchFile(ImportSettings importRequest, string locationOfBatFile)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = locationOfBatFile;
            processInfo.ErrorDialog = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;
            processInfo.WorkingDirectory = importRequest.ImportDirectory;
            Process proc = Process.Start(processInfo);
        }

        private static void CreateBatchFile(ImportSettings importRequest, string locationOfBatFile)
        {
            string merge = String.Empty;
            if (importRequest.ShallMerge)
            {
                merge = "merge ";
            }
            string verbose = String.Empty;
            if (importRequest.ShallLogVerbose)
            {
                verbose = "verbose ";
            }
            string args = $"..\\ConsoleUpgrade.exe server=\"" + importRequest.ServerURL + "\" login=\"" + importRequest.Login + "\" database=\"" + importRequest.DatabaseName + "\" " + "password=\"" + importRequest.Password + "\" release=\"" + importRequest.Release + "\" import " + merge + verbose + "description=\"" + importRequest.Description + "\" mfFile=\"" + importRequest.ManifestFileName + "\" log=\"log/" + importRequest.GUID + ".txt\" dir=\"" + importRequest.ImportDirectory + "\"";
            StreamWriter w = new StreamWriter(locationOfBatFile);
            w.WriteLine(args);
            w.Close();
        }
    }
}