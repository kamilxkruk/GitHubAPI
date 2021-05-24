using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAPI.Model.Dto
{
    public class GithubUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string RepositoryUrl { get; set; }
        public int NumberOfFollowers { get; set; }
        public int NumberOfFollowing { get; set; }
        public DateTime AccountCreationDate { get; set; }

        public override string ToString()
        {
            var properties = typeof(GithubUserDto).GetProperties();
            var resultString = "";
            foreach (PropertyInfo property in properties)
            {
                resultString += $"{property.Name}: {property.GetValue(this,null)}\n";
            }

            return resultString;
        }
    }
}
