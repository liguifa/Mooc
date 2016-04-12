using Common.Function;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using IWshRuntimeLibrary;
using Microsoft.Web.Administration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentClient.Installation
{
    public class InstallProccess
    {
        private string mServer;
        private string mPort;
        private string mSQLInstance;
        private string mUsername;
        private string mPassword;
        private string mZipFile = "install.zip";
        private string mInstallPath = Path.Combine(System.Environment.GetEnvironmentVariable("ProgramFiles"), "QXMOOC");
        private string mApplicationPoolName = "mooc";
        private string mWebSiteName = "mooc";
        private string mScheam = "http";
        private string mDestopShortcut = "QXMOOC.lnk";
        private string mShortcutIcon = "Shortcut.ico";
        private ConfigurationProcessViewModel mProccess = ConfigurationProcessViewModel.GetInstance();

        public InstallProccess(string server, string port, string sqlInstance, string username, string password)
        {
            this.mServer = server;
            this.mPort = port;
            this.mSQLInstance = sqlInstance;
            this.mUsername = username;
            this.mPassword = password;
        }

        public void Start()
        {
            Thread thread = new Thread(Install);
            thread.IsBackground = true;
            thread.Start();
        }

        private void Install()
        {

            this.mProccess.UpdateProccess("开始解压文件.", 0);
            this.Decompression();
            this.mProccess.UpdateProccess("开始配置IIS站点.", 90);
            this.ConfigWebSite();
            this.mProccess.UpdateProccess("开始创建快捷方式.", 95);
            this.CreateDestopShortcut();
            this.mProccess.UpdateProccess("安装完成.", 100);
        }

        private void Decompression()
        {
            int percent = 0;
            if (this.mZipFile == string.Empty)
            {
                this.mZipFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.mZipFile);
            }

            if (Path.GetExtension(this.mZipFile) != ".zip")
            {
                throw new Exception("安装文件不存在.");
            }

            if (!Directory.Exists(this.mInstallPath))
            {
                Directory.CreateDirectory(this.mInstallPath);
            }
            long totalSize = new FileInfo(this.mZipFile).Length;
            using (ZipInputStream s = new ZipInputStream(System.IO.File.OpenRead(this.mZipFile)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);

                    if (String.IsNullOrEmpty(fileName))
                    {
                        string dir = Path.Combine(this.mInstallPath, directoryName);
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                    }
                    else
                    {
                        if (System.IO.File.Exists(Path.Combine(this.mInstallPath, theEntry.Name)))
                        {
                            System.IO.File.Delete(Path.Combine(this.mInstallPath, theEntry.Name));
                        }
                        FileStream streamWriter = System.IO.File.Create(Path.Combine(this.mInstallPath, theEntry.Name));

                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }

                        streamWriter.Close();
                        long fileSize = new FileInfo(Path.Combine(this.mInstallPath, theEntry.Name)).Length;
                        percent = percent + (int)Math.Floor(((double)fileSize / totalSize) * 50);
                        if (percent >= 88)
                        {
                            percent = 88;
                        }
                        this.mProccess.UpdateProccess(fileName, percent);
                    }
                }
            }
        }

        private void ConfigWebSite()
        {
            IIIS iis = IISFactory.Create();
            if (iis.ExistApplicationPool(this.mApplicationPoolName))
            {
                iis.DeleteApplocationPool(this.mApplicationPoolName);
            }
            iis.CreateApplicationPool(this.mApplicationPoolName, this.mUsername, this.mPassword);
            if (iis.ExistWebSite(this.mWebSiteName))
            {
                iis.DeleteWebSite(this.mWebSiteName);
            }
            iis.CreateWebSite(this.mWebSiteName, this.mPort, this.mScheam, this.mInstallPath, this.mApplicationPoolName);
        }

        private void CreateDestopShortcut()
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), this.mDestopShortcut));
            shortcut.TargetPath = Path.Combine(System.Environment.GetEnvironmentVariable("ProgramFiles"), @"Internet Explorer\IEXPLORE.EXE");
            shortcut.Arguments = String.Format("{0}://{1}:{2}", this.mScheam, this.mServer, this.mPort);
            shortcut.WindowStyle = 1;
            shortcut.Description = "千行慕课";
            shortcut.IconLocation = Path.Combine(this.mInstallPath, this.mShortcutIcon);
            shortcut.Save();
        }
    }
}
