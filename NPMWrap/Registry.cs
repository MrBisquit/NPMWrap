using Newtonsoft.Json;
using NPMWrap.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NPMWrap
{
    public static class Registry
    {
        public class Config
        {
            public string UserAgent { get; set; } = "NPMWrap NPM API Client for C#";
        }

        public static async Task<SearchResult> SearchPackages(string SearchTerm, Config Configuration)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(Configuration.UserAgent);
                var response = await client.GetAsync($"https://registry.npmjs.org/-/v1/search?text={SearchTerm}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    SearchResult PackagesData = JsonConvert.DeserializeObject<SearchResult>(content);
                    return PackagesData;
                }
                else
                {
                    throw new Exception("NPMWrap: Failed to fetch packages from the NPM registry, received a not OK response status code.")
                    {
                        HResult = 0, // Temp
                        HelpLink = string.Empty // Temp
                    };
                }
            }
        }

        public static async Task<RegistryPackageVersion> GetPackageVersion(string Package, Config Configuration)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(Configuration.UserAgent);
                var response = await client.GetAsync($"https://registry.npmjs.org/{Package}/latest");
                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    RegistryPackageVersion PackageData = JsonConvert.DeserializeObject<RegistryPackageVersion>(content);
                    return PackageData;
                } else
                {
                    throw new Exception("NPMWrap: Failed to fetch package data from the NPM registry, received a not OK response status code.")
                    {
                        HResult = 0, // Temp
                        HelpLink = string.Empty // Temp
                    };
                }
            }
        }

        public static async Task<RegistryPackageVersion> GetPackageVersion(string Package, string Version, Config Configuration)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(Configuration.UserAgent);
                var response = await client.GetAsync($"https://registry.npmjs.org/{Package}/{Version}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    RegistryPackageVersion PackageData = JsonConvert.DeserializeObject<RegistryPackageVersion>(content);
                    return PackageData;
                }
                else
                {
                    throw new Exception("NPMWrap: Failed to fetch package data from the NPM registry, received a not OK response status code.")
                    {
                        HResult = 0, // Temp
                        HelpLink = string.Empty // Temp
                    };
                }
            }
        }
    }
}
