using ProjetoModeloDDD2.DOMINIO.ENTIDADES;
using ProjetoModeloDDD2.DOMINIO.INTERFACES;
using ProjetoModeloDDD2.DOMINIO.INTERFACES.REPOSITORIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD2.INFRA.DADOS.REPOSITORIOS
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {

    }
}