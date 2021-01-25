using InfoNovitas.LoginSample.Model.Authors;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Repositories.Mapping
{
    public static class AuthorsMapper
    {
        /*public static Author MapToModel(this Author_GetAll_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Author()
            {
                Id = dbResult.Id,
                DateCreated = dbResult.DateCreated,
                UserCreated = new Model.Users.UserInfo()
                {
                    Id = dbResult.UserCreated.GetValueOrDefault(),
                    FullName = dbResult.UserCreatedFullName
                },
                FirstName = dbResult.FirstName,
                LastName = dbResult.LastName,
                LastModified = dbResult.LastModified,
                UserLastModified = new Model.Users.UserInfo()
                {
                    Id = dbResult.UserLastModified.GetValueOrDefault(),
                    FullName = dbResult.UserLastModifiedFullName
                },
            };
        }*/

        public static Author MapToModel(this Author_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Author()
            {
                Id = dbResult.Id,
                DateCreated = dbResult.DateCreated,
                UserCreated = dbResult.UserCreated.HasValue ? new Model.Users.UserInfo()
                {
                    Id = dbResult.UserCreated.Value,
                    FullName = dbResult.UserCreatedFullName
                }:null,
                FirstName = dbResult.FirstName,
                LastName = dbResult.LastName,
                LastModified = dbResult.LastModified,
                UserLastModified = dbResult.UserLastModified.HasValue ? new Model.Users.UserInfo()
                {
                    Id = dbResult.UserLastModified.Value,
                    FullName = dbResult.UserLastModifiedFullName
                }:null,
            };
        }

        /*public static List<Author> MapToModels(this IEnumerable<Author_GetAll_Result> dbResults)
        {
            var result = new List<Author>();
            if (dbResults == null)
                return result;
            result.AddRange(dbResults.Select(item => item.MapToModel()));
            return result;
        }*/
    }
}
