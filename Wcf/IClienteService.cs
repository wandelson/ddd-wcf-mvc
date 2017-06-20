using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AppService.ViewModels;

namespace Wcf
{
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        IEnumerable<ClienteViewModel> ListarTodos() ;

        [OperationContract]
        ClienteTelefoneEnderecoViewModel Criar(ClienteTelefoneEnderecoViewModel clienteTelefoneEnderecoViewModel);

    }
}
