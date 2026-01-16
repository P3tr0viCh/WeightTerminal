using P3tr0viCh.AppUpdate;
using P3tr0viCh.Utils;
using P3tr0viCh.Utils.Extensions;
using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using WeightTerminal.Properties;

namespace WeightTerminal
{
    internal class UpdateApp: DefaultInstance<UpdateApp>
    {
        private const string GitHubOwner = "P3tr0viCh";
        private const string GitHubRepo = "WeightTerminal";
        private const string GitHubArchiveFile = "latest.zip";

        public event ProgramStatus<UpdateStatus>.StatusChangedEventHandler StatusChanged;

        private AppUpdate AppUpdate = null;

        public bool CanClose()
        {
            if (AppUpdate == null)
            {
                return true;
            }

            return AppUpdate.Status.IsIdle;
        }

        public async void Update()
        {
            Utils.Log.Info(ResourcesLog.UpdateStart);

            try
            {
                if (AppUpdate != null)
                {
                    Utils.Msg.Info(Resources.AppUpdateInfoInProgress);

                    return;
                }

                AppUpdate = new AppUpdate();

                AppUpdate.Config.LocalFile = Application.ExecutablePath;

                AppUpdate.Config.Location = Location.GitHub;

                AppUpdate.Config.GitHub.Owner = GitHubOwner;
                AppUpdate.Config.GitHub.Repo = GitHubRepo;
                AppUpdate.Config.GitHub.ArchiveFile = GitHubArchiveFile;

                AppUpdate.Status.StatusChanged += StatusChanged;

                var errorMsg = string.Empty;

                try
                {
                    AppUpdate.Check();

                    await AppUpdate.CheckLatestVersionAsync();

                    Utils.Log.Info(string.Format(ResourcesLog.UpdateVersions, 
                        AppUpdate.Versions.Local, AppUpdate.Versions.Latest));

                    if (AppUpdate.Versions.IsLatest())
                    {
                        Utils.Msg.Info(Resources.AppUpdateInfoAlreadyLatest);

                        return;
                    }

                    await AppUpdate.UpdateAsync();

                    Utils.Msg.Info(Resources.AppUpdateInfoUpdated);
                }
                catch (LocalFileWrongLocationException)
                {
                    var path = Path.Combine(Directory.GetParent(AppUpdate.Config.LocalFile).FullName,
                        AppUpdate.Versions.Local.ToString(),
                        Path.GetFileName(AppUpdate.Config.LocalFile));

                    errorMsg = string.Format(Resources.AppUpdateErrorFileWrongLocation, path);
                }
                catch (HttpRequestException e)
                {
                    Utils.Log.Error(e);

                    errorMsg = e.Message;
                }
                catch (Exception e)
                {
                    Utils.Log.Error(e);

                    errorMsg = e.Message;
                }
                finally
                {
                    AppUpdate = null;
                }

                if (!errorMsg.IsEmpty())
                {
                    Utils.Msg.Error(Resources.AppUpdateErrorInProgress, errorMsg);
                }
            }
            finally
            {
                Utils.Log.Info(ResourcesLog.UpdateDone);
            }
        }
    }
}