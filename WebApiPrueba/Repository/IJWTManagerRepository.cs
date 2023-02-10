using Newtonsoft.Json.Linq;
using WebApiPrueba.DataModel;

namespace WebApiPrueba.Repository
{
    public interface IJWTManagerRepository
    {
        TokensDataModel  Authenticate(UsuarioDatamodel users);
    }
}
