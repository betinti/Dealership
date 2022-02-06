using System.ComponentModel;

namespace Domain.Enumerations
{
    public enum ErrorType
    {
        [Description("Não Encontrado")]
        NotFound,
        [Description("Nenhum encontrado")]
        AnyFound,
        [Description("Erro ao criar")]
        CantCreate,
        [Description("Erro ao atualizar")]
        CantUpdate,
        [Description("Formatação do dado Invalida")]
        ParseError,
        [Description("FErro ao deletar")]
        CantDelete,
        [Description("FParametros inconsistentes")]
        ParameterError,
    }
}