using InfoNovitas.LoginSample.Model.Authors;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using InfoNovitas.LoginSample.Repositories.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace InfoNovitas.LoginSample.Repositories.Authors
{
    public class AuthorRepository : IAuthorRepository
    {
        public int Add(Author item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Author item)
        {
            throw new System.NotImplementedException();
        }

        public List<Author> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Author FindBy(int key)
        {
            using (var context = new IdentityExDbEntities())
            {
                return context.Author_Get(key).SingleOrDefault().MapToModel();
            }
        }

        public Author Save(Author item)
        {
            throw new System.NotImplementedException();
        }
    }
}
