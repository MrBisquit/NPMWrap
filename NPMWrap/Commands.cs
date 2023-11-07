using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPMWrap
{
    public static class Commands
    {
        public class Config
        {
            public bool UseYarn { get; set; } = false;
            public string Directory { get; set; } = null;
            public bool IsDebug { get; set; } = false;
            public bool WaitForExit { get; set; } = false;
        }

        public static void RunBaseInstall(Config Configuration)
        {
            if(Configuration.Directory == null)
            {
                throw new Exception("NPMWrap: Configuration invalid, Directory was null.")
                {
                    HResult = 0, // Temp
                    HelpLink = string.Empty // Temp
                };
            }

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = Configuration.UseYarn ? "yarn" : "npm",
                    Arguments = Configuration.UseYarn ? "" : "install",
                    CreateNoWindow = !Configuration.IsDebug,
                    WindowStyle = Configuration.IsDebug ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden,
                    WorkingDirectory = Configuration.Directory,
                    UseShellExecute = true
                }
            };

            process.Start();

            if(Configuration.WaitForExit)
            {
                process.WaitForExit();
            }
        }

        public static void RunBaseUpgrade(Config Configuration)
        {
            if (Configuration.Directory == null)
            {
                throw new Exception("NPMWrap: Configuration invalid, Directory was null.")
                {
                    HResult = 0, // Temp
                    HelpLink = string.Empty // Temp
                };
            }

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = Configuration.UseYarn ? "yarn" : "npm",
                    Arguments = Configuration.UseYarn ? "" : "upgrade",
                    CreateNoWindow = !Configuration.IsDebug,
                    WindowStyle = Configuration.IsDebug ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden,
                    WorkingDirectory = Configuration.Directory,
                    UseShellExecute = true
                }
            };

            process.Start();

            if (Configuration.WaitForExit)
            {
                process.WaitForExit();
            }
        }

        public static void RunInstall(string PackageName, Config Configuration)
        {
            if (Configuration.Directory == null)
            {
                throw new Exception("NPMWrap: Configuration invalid, Directory was null.")
                {
                    HResult = 0, // Temp
                    HelpLink = string.Empty // Temp
                };
            }

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = Configuration.UseYarn ? "yarn" : "npm",
                    Arguments = Configuration.UseYarn ? $"add {PackageName}" : $"install {PackageName}",
                    CreateNoWindow = !Configuration.IsDebug,
                    WindowStyle = Configuration.IsDebug ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden,
                    WorkingDirectory = Configuration.Directory,
                    UseShellExecute = true
                }
            };

            process.Start();

            if (Configuration.WaitForExit)
            {
                process.WaitForExit();
            }
        }

        public static void RunInstall(string PackageName, string PackageVersion, Config Configuration)
        {
            if (Configuration.Directory == null)
            {
                throw new Exception("NPMWrap: Configuration invalid, Directory was null.")
                {
                    HResult = 0, // Temp
                    HelpLink = string.Empty // Temp
                };
            }

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = Configuration.UseYarn ? "yarn" : "npm",
                    Arguments = Configuration.UseYarn ? $"add {PackageName}@{PackageVersion}" : $"install {PackageName}@{PackageVersion}",
                    CreateNoWindow = !Configuration.IsDebug,
                    WindowStyle = Configuration.IsDebug ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden,
                    WorkingDirectory = Configuration.Directory,
                    UseShellExecute = true
                }
            };

            process.Start();

            if (Configuration.WaitForExit)
            {
                process.WaitForExit();
            }
        }

        public static void RunUninstall(string PackageName, Config Configuration)
        {
            if (Configuration.Directory == null)
            {
                throw new Exception("NPMWrap: Configuration invalid, Directory was null.")
                {
                    HResult = 0, // Temp
                    HelpLink = string.Empty // Temp
                };
            }

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = Configuration.UseYarn ? "yarn" : "npm",
                    Arguments = Configuration.UseYarn ? $"remove {PackageName}" : $"uninstall {PackageName}",
                    CreateNoWindow = !Configuration.IsDebug,
                    WindowStyle = Configuration.IsDebug ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden,
                    WorkingDirectory = Configuration.Directory,
                    UseShellExecute = true
                }
            };

            process.Start();

            if (Configuration.WaitForExit)
            {
                process.WaitForExit();
            }
        }
    }
}
