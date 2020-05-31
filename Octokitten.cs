using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace DoomRPG
{
    static class Octokitten
    {
        public static async Task<Branch[]> GetAllBranches(string author, string repository)
        {
            using (HttpClient cl = new HttpClient() { BaseAddress = new Uri("https://api.github.com"), DefaultRequestHeaders = { { "User-Agent", "DRPGSEL" } } })
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Branch[]));
                return (Branch[])serializer.ReadObject(await cl.GetStreamAsync($"repos/{author}/{repository}/branches"));
            }
        }
    }

    [DataContract]
    class Branch
    {
        [DataMember]
        public string name;
        [DataMember]
        public Commit commit;
        [DataMember]
        public bool protect;

        public Branch(string Name, Commit Commit, bool Protected)
        {
            name = Name;
            commit = Commit;
            protect = Protected;
        }
    }

    [DataContract]
    class Commit
    {
        [DataMember]
        public string sha;
        [DataMember]
        public string url;

        public Commit(string SHA, string URL)
        {
            sha = SHA;
            url = URL;
        }
    }
}
